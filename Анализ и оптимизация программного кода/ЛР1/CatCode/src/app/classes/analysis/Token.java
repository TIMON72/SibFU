package app.classes.analysis;

/**
 * Класс токенов лексера
 */
public class Token {
    /**
     * Перечисление типов токена
     */
    public static enum Type {
        // Типы данных (int, bool, string)
        INT, BOOL, STRING,
        // Ключевые слова (keyword)
        PRINT, IF, ELSE, WHILE, DO, DEF, RETURN, STRUCT, VAR,
        // Коммментарии
        COMMENT,
        // Операторы (operator)
        PLUS, // +
        MINUS, // -
        STAR, // *
        SLASH, // /
        SEMICOLON, // ;
        COMMA, // ,
        EQ, // =
        LBRACE, // {
        RBRACE, // }
        LPAREN, // (
        RPAREN, // )
        LT, // <
        GT, // >
        EQEQ, // ==
        EXCLEQ, // !=
        LTEQ, // <=
        GTEQ, // >=
        BARBAR, // ||
        AMPAMP, // &&
        EXCL, // !
    }

    private Token.Type type;
    private String text;

    /**
     * Конструктор
     * 
     * @param type тип токена
     * @param text содержимое токена
     */
    public Token(Token.Type type, String text) {
        this.type = type;
        this.text = text;
    }

    /**
     * Получить тип токена
     * 
     * @return тип токена
     */
    public Token.Type getType() {
        return type;
    }

    /**
     * Задать тип токена
     * 
     * @param type тип токена
     */
    public void setType(Token.Type type) {
        this.type = type;
    }

    /**
     * Получить содержимое токена
     * 
     * @return содержимое токена
     */
    public String getText() {
        return text;
    }

    /**
     * Задать содержимое токена
     * 
     * @param text содержимое токена
     */
    public void setText(String text) {
        this.text = text;
    }

    /**
     * Перегрузка {@link java.lang.Object#toString()}
     */
    @Override
    public String toString() {
        return type.toString() + ' ' + text;
    }
}