package app.classes.analysis;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Класс лексического анализа
 */
public class Lexer {
    // Используемые символы
    private static final String operators = "+-*/(){}=<>!&|,;";
    private static final String letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private static final String digits = "0123456789";
    // Используемые операторы
    private static final Map<String, Token.Type> operatorsMap;
    static {
        operatorsMap = new HashMap<>();
        // Арифметические
        operatorsMap.put("+", Token.Type.PLUS);
        operatorsMap.put("-", Token.Type.MINUS);
        operatorsMap.put("*", Token.Type.STAR);
        operatorsMap.put("/", Token.Type.SLASH);
        // Разделители
        operatorsMap.put(";", Token.Type.SEMICOLON);
        operatorsMap.put(",", Token.Type.COMMA);
        // Присвоения
        operatorsMap.put("=", Token.Type.EQ);
        // Выражения
        operatorsMap.put("{", Token.Type.LBRACE);
        operatorsMap.put("}", Token.Type.RBRACE);
        operatorsMap.put("(", Token.Type.LPAREN);
        operatorsMap.put(")", Token.Type.RPAREN);
        // Сравнения
        operatorsMap.put("<", Token.Type.LT);
        operatorsMap.put(">", Token.Type.GT);
        operatorsMap.put("==", Token.Type.EQEQ);
        operatorsMap.put("!=", Token.Type.EXCLEQ);
        operatorsMap.put("<=", Token.Type.LTEQ);
        operatorsMap.put(">=", Token.Type.GTEQ);
        // Логические
        operatorsMap.put("&&", Token.Type.AMPAMP);
        operatorsMap.put("||", Token.Type.BARBAR);
        operatorsMap.put("!", Token.Type.EXCL);
    }
    // Поля
    private String input;
    private int length;
    private int line;
    private int pos;
    private List<Token> tokens = new ArrayList<>();

    /**
     * Конструктор
     * 
     * @param input входной поток
     * @throws Exception ошибка токенизации символа
     */
    public Lexer(String input) throws Exception {
        this.input = input;
        this.length = input.length();
        tokenize();
    }

    /**
     * Получить символ на relativePosition
     * 
     * @param relativePosition относительная позиция (от глобального положения
     *                         каретки)
     * @return возвращает символ
     */
    private char peek(int relativePosition) {
        final int position = pos + relativePosition;
        if (position >= length)
            return '\0';
        return input.charAt(position);
    }

    /**
     * Смещение каретки вперед
     * 
     * @return возвращает символ после смещения
     */
    private char next() {
        pos++;
        if ("\r\n\t\0".indexOf(peek(0)) != -1)
            line++;
        return peek(0);
    }

    /**
     * Токенизация int
     */
    private void tokenizeInt() {
        final StringBuilder buffer = new StringBuilder();
        char current = peek(0);
        while (true) {
            // Символ - не цифра?
            if (digits.indexOf(current) == -1)
                break;
            buffer.append(current);
            current = next();
        }
        tokens.add(new Token(Token.Type.INT, buffer.toString()));
    }

    /**
     * Токенизация комментария
     */
    private void tokenizeComment() {
        final StringBuilder buffer = new StringBuilder();
        char current = peek(0);
        while ("\r\n\t\0".indexOf(current) == -1) {
            buffer.append(current);
            current = next();
        }
        tokens.add(new Token(Token.Type.COMMENT, buffer.toString()));
    }

    /**
     * Токенизация оператора
     * 
     * @throws Exception выбрасывает ошибку токенизации
     */
    private void tokenizeOperator() throws Exception {
        char current = peek(0);
        if (current == '/') {
            if (peek(1) == '/') {
                next();
                next();
                tokenizeComment();
                return;
            }
        }
        final StringBuilder buffer = new StringBuilder();
        while (true) {
            final String text = buffer.toString();
            if (!operatorsMap.containsKey(text + current)) {
                if (!text.isEmpty()) {
                    tokens.add(new Token(operatorsMap.get(text), text));
                    return;
                } else
                    throw new Exception("Ошибка токенизации: строка " + line + " позиция " + pos + 
                    ": неопознанный оператор\n" + printTokens());
            }
            buffer.append(current);
            current = next();
        }
    }

    /**
     * Токенизация ключевого слова
     */
    private void tokenizeKeyword() {
        final StringBuilder buffer = new StringBuilder();
        char current = peek(0);
        while (true) {
            if ((letters.indexOf(current) == -1) && (digits.indexOf(current) == -1)) {
                break;
            }
            buffer.append(current);
            current = next();
        }
        final String keyword = buffer.toString();
        Token.Type keywordType = null;
        switch (keyword) {
            case "print":
                keywordType = Token.Type.PRINT;
                break;
            case "if":
                keywordType = Token.Type.IF;
                break;
            case "else":
                keywordType = Token.Type.ELSE;
                break;
            case "while":
                keywordType = Token.Type.WHILE;
                break;
            case "do":
                keywordType = Token.Type.DO;
                break;
            case "def":
                keywordType = Token.Type.DEF;
                break;
            case "return":
                keywordType = Token.Type.RETURN;
                break;
            case "struct":
                keywordType = Token.Type.STRUCT;
                break;
            default:
                keywordType = Token.Type.VAR;
                break;
        }
        tokens.add(new Token(keywordType, keyword));
    }

    /**
     * Токенизация boolean
     */
    private void tokenizeBool() {
        final StringBuilder buffer = new StringBuilder();
        int startPos = pos;
        char current = peek(0);
        while (true) {
            if (letters.indexOf(current) == -1) {
                break;
            }
            buffer.append(current);
            current = next();
        }
        String boolStr = buffer.toString();
        if (!boolStr.equals("true") && !boolStr.equals("false")) {
            pos = startPos;
            tokenizeKeyword();
        } else
            tokens.add(new Token(Token.Type.BOOL, boolStr));
    }

    /**
     * Токенизация string
     * 
     * @throws Exception
     */
    private void tokenizeString() throws Exception {
        next(); // Пропускаем открывающую "
        final StringBuilder buffer = new StringBuilder();
        char current = peek(0);
        while (true) {
            if (current == '\\') {
                current = next();
                switch (current) {
                    case '"':
                        current = next();
                        buffer.append('"');
                        continue;
                    case 'n':
                        current = next();
                        buffer.append('\n');
                        continue;
                    case 't':
                        current = next();
                        buffer.append('\t');
                        continue;
                }
                buffer.append('\\');
                continue;
            }
            if (current == '"')
                break;
            else if ("\r\n\t\0 ".indexOf(peek(1)) != -1)
                
                throw new Exception("Ошибка токенизации: строка " + line + " позиция " + pos + 
                ": ожидалась закрывающая кавычка\n" + printTokens());
            buffer.append(current);
            current = next();
        }
        next(); // Пропускаем закрывающую "

        tokens.add(new Token(Token.Type.STRING, buffer.toString()));
    }

    /**
     * Токенизация
     * 
     * @return возвращает список токенов
     * @throws Exception выбрасывает ошибку токенизации
     */
    private List<Token> tokenize() throws Exception {
        while (pos < length) {
            final char current = peek(0);
            // Текущий символ - цифра?
            if (digits.indexOf(current) != -1)
                tokenizeInt();
            // Текущий символ - оператор?
            else if (operators.indexOf(current) != -1)
                tokenizeOperator();
            // Текущий символ - буква?
            else if (letters.indexOf(current) != -1) {
                if (current == 't' || current == 'f')
                    tokenizeBool();
                else
                    tokenizeKeyword();
            }
            // Текущий символ - " ?
            else if (current == '"')
                tokenizeString();
            // Текущий символ - пробел или переход на строку?
            else if ("\r\n\t\0 ".indexOf(current) != -1)
                next();
            else
                throw new Exception(
                        "Ошибка токенизации: строка " + line + " позиция " + pos + 
                        ": неопознанный символ\n" + printTokens());
        }
        return tokens;
    }

    /**
     * Вывод токенов в консоль
     * 
     * @return возвращает список токенов
     */
    public String printTokens() {
        String result = "";
        if (tokens.size() != 0)
            for (Token t : tokens)
                result += t.toString() + '\n';
        return result;
    }
}