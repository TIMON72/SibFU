package app.classes;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import app.classes.exceptions.SemanticException;
import app.classes.exceptions.SyntaxException;

public class Parser {
    // Поля
    private List<Token> tokens;
    private int size;
    // Переменные
    private int globalPos;
    private ArrayList<Function> functions = new ArrayList<>();
    private Map<String, Integer> functionsPos = new HashMap<String, Integer>();
    private Map<String, Expression> variables = new HashMap<String, Expression>();

    /**
     * Конструктор
     * 
     * @param tokens список токенов
     */
    public Parser(List<Token> tokens) {
        this.tokens = tokens;
        size = tokens.size();
    }

    /**
     * Получить токен на relativePosition
     * 
     * @param relativePosition относительная позиция токена к глобальной
     * @return токен на текущей глобальной позиции или null, если достигнут конец
     *         списка токенов
     */
    private Token get(int relativePosition) {
        final int position = globalPos + relativePosition;
        if (position >= size)
            return null;
        return tokens.get(position);
    }

    /**
     * Совпадение типа токена с типом текущего токена
     * 
     * @param compared сравниваемый тип токена
     * @return true или false
     */
    private boolean isTypeMatch(Token.Type compared) {
        Token current = get(0);
        if (current == null || compared != current.getType())
            return false;
        globalPos++;
        return true;
    }

    /**
     * Задать функцию F
     * 
     * @return фуекцию
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    private Function setFunction() throws SyntaxException, SemanticException {
        Token current = get(0);
        String funcVar = "";
        HashMap<String, Expression> funcArgs = new HashMap<>();
        ArrayList<Statement> funcStates = new ArrayList<>();
        if (isTypeMatch(Token.Type.DEF)) {
            current = get(-1);
            if (!isTypeMatch(Token.Type.VAR)) {
                throw new SyntaxException(
                        String.format("Ожидался \"VAR\" после \"def\": %s", current.getFullPosition()));
            }
            current = get(-1);
            funcVar = current.getText();
            if (!isTypeMatch(Token.Type.LPAREN)) {
                throw new SyntaxException(
                        String.format("Ожидалась \"(\" после \"%s\": %s", funcVar, current.getFullPosition()));
            }
            while (true) {
                current = get(-1);
                String var = get(0).getText();
                if (isTypeMatch(Token.Type.VAR)) {
                    current = get(-1);
                    Expression expr = new Expression();
                    funcArgs.put(var, expr);
                    variables.put(current.getText(), expr);
                } else if (isTypeMatch(Token.Type.RPAREN)) {
                    break;
                } else {
                    throw new SyntaxException(
                            String.format("Ожидался \"VAR\" или \")\": %s", current.getFullPosition()));
                }
            }
            current = get(-1);
            if (!isTypeMatch(Token.Type.LBRACE)) {
                throw new SyntaxException(
                        String.format("Ожидалась \"{\" после \"def ...(...)\": %s", current.getFullPosition()));
            }
            functionsPos.put(funcVar, globalPos);
            while (true) {
                Statement state = setStatement();
                if (state == null)
                    break;
                funcStates.add(state);
            }
            current = get(-1);
            if (!isTypeMatch(Token.Type.RBRACE)) {
                throw new SyntaxException(String.format("Ожидалась \"}\" после \"%s\": %s", current.getText(),
                        current.getFullPosition()));
            }
            return new Function(funcVar, funcArgs, variables, funcStates);
        }
        return null;
    }

    /**
     * Задать оператор S
     * 
     * @return оператор
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    private Statement setStatement() throws SyntaxException, SemanticException {
        if (isTypeMatch(Token.Type.COMMENT)) {
            globalPos++;
            globalPos--;
        }
        if (isTypeMatch(Token.Type.VAR)) {
            if (isTypeMatch(Token.Type.EQ)) {
                return setAssignmentStatement();
            }
            if (isTypeMatch(Token.Type.LPAREN)) {
                return setFunctionCallStatement();
            }
        }
        if (isTypeMatch(Token.Type.PRINT)) {
            return setPrintStatement();
        }
        if (isTypeMatch(Token.Type.IF)) {
            return setConditionalStatement();
        }
        if (isTypeMatch(Token.Type.WHILE)) {
            return setPrecyclicStatement();
        }
        if (isTypeMatch(Token.Type.DO)) {
            return setPostcyclicStatement();
        }
        if (isTypeMatch(Token.Type.RETURN))
            return setReturnableStatement();
        return null;
    }

    /**
     * Задать оператор присваивания
     * 
     * @return оператор
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    private Statement setAssignmentStatement() throws SyntaxException, SemanticException {
        Statement state = null;
        Token current = get(-2);
        String var = current.getText();
        Expression expr = setExpression();
        state = new Statement(var, "=", expr);
        variables.put(var, expr);
        return state;
    }

    /**
     * Задать оператор вызова функции
     * 
     * @return оператор
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    private Statement setFunctionCallStatement() throws SyntaxException, SemanticException {
        Token current = get(-2);
        String funcVar = current.getText();
        Map<String, Expression> args = new HashMap<String, Expression>();
        ArrayList<Statement> states = new ArrayList<>();
        Function calledFunc = null;
        try {
            calledFunc = functions.stream().filter(f -> f.getFunctionVariable().equals(funcVar)).findFirst().get();
        } catch (Exception ex) {
            throw new SemanticException(
                    String.format("Функция \"%s\" не объявлена: %s", funcVar, current.getFullPosition()));
        }
        String funcName = calledFunc.getName();
        for (Map.Entry<String, Expression> entry : calledFunc.getArguments().entrySet()) {
            current = get(0);
            String var = current.getText();
            if (isTypeMatch(Token.Type.RPAREN))
                break;
            Expression expr = null;
            if (isTypeMatch(Token.Type.VAR))
                expr = variables.get(var);
            else
                expr = setExpression();
            args.put(entry.getKey(), expr);
        }
        int currentGlobalPos = globalPos; // запоминаем текущую позицию
        Map<String, Expression> oldVariables = variables; // запоминаем переменные до вызова
        globalPos = functionsPos.get(funcVar); // перемещаемся на позицию объявления функции после "("
        variables = args;
        while (true) {
            current = get(0);
            Statement state = setStatement();
            if (state == null)
                break;
            states.add(state);
        }
        globalPos = currentGlobalPos; // возврат на запомненную позицию
        variables = oldVariables; // возврат к запомненным переменным
        Statement state = new Statement(funcName, funcVar, args, states);
        current = get(-1);
        if (!isTypeMatch(Token.Type.RPAREN)) {
            throw new SyntaxException(
                    String.format("Ожидалась \")\" после \"%s\": %s", current.getText(), current.getFullPosition()));
        }
        return state;
    }

    /**
     * Задать оператор печати print(E)
     * 
     * @return оператор
     * @throws SemanticException семантическая ошибка
     * @throws SyntaxException   синтаксическая ошибка
     */
    private Statement setPrintStatement() throws SemanticException, SyntaxException {
        Token current = get(-1);
        if (!isTypeMatch(Token.Type.LPAREN)) {
            throw new SyntaxException(String.format("Ожидалась \"(\" после \"print\": %s", current.getFullPosition()));
        }
        Statement state;
        current = get(-1);
        Expression expr = setExpression();
        try {
            state = new Statement("print", expr);
        } catch (SemanticException se) {
            throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
        }
        current = get(-1);
        if (!isTypeMatch(Token.Type.RPAREN)) {
            throw new SyntaxException(
                    String.format("Ожидалась \")\" вместо \"%s\": %s", current.getText(), current.getFullPosition()));
        }
        return state;
    }

    /**
     * Задать оператор возврата return E
     * 
     * @return оператор
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    private Statement setReturnableStatement() throws SyntaxException, SemanticException {
        Token current = get(-1);
        Statement state;
        current = get(-1);
        Expression expr = setExpression();
        try {
            state = new Statement("return", expr);
        } catch (SemanticException se) {
            throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
        }
        return state;
    }

    /**
     * Задать условный оператор if (E) {S+} else {S+}
     * 
     * @return оператор
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    private Statement setConditionalStatement() throws SyntaxException, SemanticException {
        Token current = get(-1);
        Expression expr = null;
        Statement ifState = null;
        ArrayList<Statement> ifStates = new ArrayList<>();
        Statement elseState = null;
        ArrayList<Statement> elseStates = new ArrayList<>();
        if (isTypeMatch(Token.Type.LPAREN)) {
            expr = setExpression();
            current = get(-1);
            if (!((Object) expr.getResult() instanceof Boolean)) {
                throw new SemanticException(
                        String.format("Ожидался класс \"Boolean\" вместо \"%s\" результата выражения \"%s\": %s",
                                expr.getResult().getClass(), current.getText(), current.getFullPosition()));
            }
            if (isTypeMatch(Token.Type.RPAREN)) {
                current = get(-1);
                if (isTypeMatch(Token.Type.LBRACE)) {
                    while (true) {
                        ifState = setStatement();
                        if (ifState == null)
                            break;
                        ifStates.add(ifState);
                    }
                    current = get(-1);
                    if (isTypeMatch(Token.Type.RBRACE)) {
                        current = get(-1);
                        if (isTypeMatch(Token.Type.ELSE)) {
                            current = get(-1);
                            if (isTypeMatch(Token.Type.LBRACE)) {
                                while (true) {
                                    elseState = setStatement();
                                    if (elseState == null)
                                        break;
                                    elseStates.add(elseState);
                                }
                                current = get(-1);
                                if (!isTypeMatch(Token.Type.RBRACE)) {
                                    throw new SyntaxException(String.format("Ожидалась \"}\" после \"%s\": %s",
                                            current.getText(), current.getFullPosition()));
                                }
                            } else {
                                throw new SyntaxException(
                                        String.format("Ожидалась \"{\" после \"else\": %s", current.getFullPosition()));
                            }
                        }
                    } else {
                        throw new SyntaxException(String.format("Ожидалась \"}\" после \"%s\": %s", current.getText(),
                                current.getFullPosition()));
                    }
                } else {
                    throw new SyntaxException(
                            String.format("Ожидалась \"{\" после \"if (...)\": %s", current.getFullPosition()));
                }
            } else {
                throw new SyntaxException(String.format("Ожидалась \")\" после \"%s\": %s", current.getText(),
                        current.getFullPosition()));
            }
        } else {
            throw new SyntaxException(String.format("Ожидалась \"(\" после \"if\": %s", current.getFullPosition()));
        }
        Statement state;
        state = new Statement(expr, ifStates, elseStates);
        return state;
    }

    /**
     * Задать предциклический оператор while (E) {S+}
     * 
     * @return оператор
     * @throws SemanticException семантическая ошибка
     * @throws SyntaxException   синтаксическая ошибка
     */
    private Statement setPrecyclicStatement() throws SemanticException, SyntaxException {
        Token current = get(-1);
        Expression expr = null;
        Statement state = null;
        int whileExprPos = -1;
        Expression whileExpr = null;
        ArrayList<Statement> states = new ArrayList<>();
        if (isTypeMatch(Token.Type.LPAREN)) {
            whileExprPos = globalPos;
            whileExpr = setExpression();
            expr = whileExpr;
            while (true) {
                current = get(-1);
                if (!((Object) whileExpr.getResult() instanceof Boolean)) {
                    throw new SemanticException(
                            String.format("Ожидался класс \"Boolean\" вместо \"%s\" результата выражения \"%s\": %s",
                                    whileExpr.getResult().getClass(), current.getText(), current.getFullPosition()));
                }
                if (isTypeMatch(Token.Type.RPAREN)) {
                    current = get(-1);
                    if (isTypeMatch(Token.Type.LBRACE)) {
                        while (true) {
                            state = setStatement();
                            if (state == null)
                                break;
                            states.add(state);
                        }
                        current = get(-1);
                        if (isTypeMatch(Token.Type.RBRACE)) {
                            current = get(-1);
                        } else {
                            throw new SyntaxException(String.format("Ожидалась \"}\" после \"%s\": %s",
                                    current.getText(), current.getFullPosition()));
                        }
                    } else {
                        throw new SyntaxException(
                                String.format("Ожидалась \"{\" после \"while (...)\": %s", current.getFullPosition()));
                    }
                } else {
                    throw new SyntaxException(String.format("Ожидалась \")\" после \"%s\": %s", current.getText(),
                            current.getFullPosition()));
                }
                if (!(Boolean) whileExpr.getResult())
                    break;
                globalPos = whileExprPos;
                whileExpr = setExpression();
            }
        } else {
            throw new SyntaxException(String.format("Ожидалась \"(\" после \"while\": %s", current.getFullPosition()));
        }
        state = new Statement(expr, states);
        return state;
    }

    /**
     * Задать постциклический оператор do {S+} while (E)
     * 
     * @return оператор
     * @throws SemanticException семантическая ошибка
     * @throws SyntaxException   синтаксическая ошибка
     */
    private Statement setPostcyclicStatement() throws SemanticException, SyntaxException {
        Token current = get(-1);
        Expression expr = null;
        Statement state = null;
        Expression whileExpr = null;
        ArrayList<Statement> states = new ArrayList<>();
        int whileExprPos = globalPos;
        do {
            current = get(-1);
            if (isTypeMatch(Token.Type.LBRACE)) {
                while (true) {
                    state = setStatement();
                    if (state == null)
                        break;
                    states.add(state);
                }
                current = get(-1);
                if (isTypeMatch(Token.Type.RBRACE)) {
                    current = get(-1);
                    if (isTypeMatch(Token.Type.WHILE)) {
                        current = get(-1);
                        if (isTypeMatch(Token.Type.LPAREN)) {
                            current = get(-1);
                            whileExpr = setExpression();
                            if (expr == null)
                                expr = whileExpr;
                            if (!((Object) whileExpr.getResult() instanceof Boolean)) {
                                throw new SemanticException(String.format(
                                        "Ожидался класс \"Boolean\" вместо \"%s\" результата выражения \"%s\": %s",
                                        whileExpr.getResult().getClass(), current.getText(),
                                        current.getFullPosition()));
                            }
                            if (isTypeMatch(Token.Type.RPAREN)) {
                                if (!(Boolean) whileExpr.getResult())
                                    break;
                                globalPos = whileExprPos;
                            } else {
                                throw new SyntaxException(String.format("Ожидалась \")\" после \"%s\": %s",
                                        current.getText(), current.getFullPosition()));
                            }
                        } else {
                            throw new SyntaxException(String.format("Ожидалась \"(\" после \"while\": %s",
                                    current.getText(), current.getFullPosition()));
                        }
                    } else {
                        throw new SyntaxException(String.format("Ожидался \"while\" после \"}\": %s", current.getText(),
                                current.getFullPosition()));
                    }
                } else {
                    throw new SyntaxException(String.format("Ожидалась \"}\" после \"%s\": %s", current.getText(),
                            current.getFullPosition()));
                }

            } else {
                throw new SyntaxException(String.format("Ожидалась \"{\" после \"do\": %s", current.getFullPosition()));
            }
        } while (true);
        state = new Statement(states, expr);
        return state;
    }

    /**
     * Задать выражение E
     * 
     * @return выражение
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    private Expression setExpression() throws SyntaxException, SemanticException {
        return setLogicalAdditionExpression();
    }

    /**
     * Задать выражение логического сложения E||E
     * 
     * @return выражение
     * @throws SemanticException семантическая ошибка
     * @throws SyntaxException   синтаксическая ошибка
     */
    private Expression setLogicalAdditionExpression() throws SemanticException, SyntaxException {
        Token current = get(0);
        Expression expr = setLogicalMultiplicationExpression();
        while (true) {
            if (isTypeMatch(Token.Type.BARBAR)) {
                try {
                    current = get(0);
                    expr = new Expression("||", expr, setLogicalMultiplicationExpression());
                } catch (SemanticException se) {
                    throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
                }
                continue;
            }
            break;
        }
        return expr;
    }

    /**
     * Задать выражение логического умножения E&&E
     * 
     * @return выражение
     * @throws SemanticException семантическая ошибка
     * @throws SyntaxException   синтаксическая ошибка
     */
    private Expression setLogicalMultiplicationExpression() throws SemanticException, SyntaxException {
        Token current = get(0);
        Expression expr = setEqualityExpression();
        while (true) {
            if (isTypeMatch(Token.Type.AMPAMP)) {
                try {
                    current = get(0);
                    expr = new Expression("&&", expr, setEqualityExpression());
                } catch (SemanticException se) {
                    throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
                }
                continue;
            }
            break;
        }
        return expr;
    }

    /**
     * Задать выражение равенства E==E (E!=E)
     * 
     * @return выражение
     * @throws SemanticException семантическая ошибка
     * @throws SyntaxException   синтаксическая ошибка
     */
    private Expression setEqualityExpression() throws SemanticException, SyntaxException {
        Token current = get(0);
        Expression expr = setComparisonExpression();
        if (isTypeMatch(Token.Type.EQEQ)) {
            try {
                current = get(0);
                expr = new Expression("==", expr, setComparisonExpression());
            } catch (SemanticException se) {
                throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
            }
            return expr;
        }
        if (isTypeMatch(Token.Type.EXCLEQ)) {
            try {
                current = get(0);
                expr = new Expression("!=", expr, setComparisonExpression());
            } catch (SemanticException se) {
                throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
            }
            return expr;
        }
        return expr;
    }

    /**
     * Задать выражение сравнения E>E E>=E E<E E<=E
     * 
     * @return выражение
     * @throws SemanticException семантическая ошибка
     * @throws SyntaxException   синтаксическая ошибка
     */
    private Expression setComparisonExpression() throws SemanticException, SyntaxException {
        Token current = get(0);
        Expression expr = setAdditionExpression();
        while (true) {
            if (isTypeMatch(Token.Type.GT)) {
                try {
                    current = get(0);
                    expr = new Expression(">", expr, setAdditionExpression());
                } catch (SemanticException se) {
                    throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
                }
                continue;
            }
            if (isTypeMatch(Token.Type.GTEQ)) {
                try {
                    current = get(0);
                    expr = new Expression(">=", expr, setAdditionExpression());
                } catch (SemanticException se) {
                    throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
                }
                continue;
            }
            if (isTypeMatch(Token.Type.LT)) {
                try {
                    current = get(0);
                    expr = new Expression("<", expr, setAdditionExpression());
                } catch (SemanticException se) {
                    throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
                }
                continue;
            }
            if (isTypeMatch(Token.Type.LTEQ)) {
                try {
                    current = get(0);
                    expr = new Expression("<=", expr, setAdditionExpression());
                } catch (SemanticException se) {
                    throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
                }
                continue;
            }
            break;
        }
        return expr;
    }

    /**
     * Задать выражение сложения E+E (вычитание E-E)
     * 
     * @return выражение
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    private Expression setAdditionExpression() throws SyntaxException, SemanticException {
        Token current = get(0);
        Expression expr = setMultiplicationExpression();
        while (true) {
            if (isTypeMatch(Token.Type.PLUS)) {
                try {
                    current = get(0);
                    expr = new Expression("+", expr, setMultiplicationExpression());
                } catch (SemanticException se) {
                    throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
                }
                continue;
            }
            if (isTypeMatch(Token.Type.MINUS)) {
                try {
                    current = get(0);
                    expr = new Expression("-", expr, setMultiplicationExpression());
                } catch (SemanticException se) {
                    throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
                }
                continue;
            }
            break;
        }
        return expr;
    }

    /**
     * Задать выражение умножения Е*Е (деление Е/E)
     * 
     * @return
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    private Expression setMultiplicationExpression() throws SyntaxException, SemanticException {
        Token current = get(0);
        Expression expr = setNegationExpression();
        while (true) {
            if (isTypeMatch(Token.Type.STAR)) {
                try {
                    current = get(0);
                    expr = new Expression("*", expr, setNegationExpression());
                } catch (SemanticException se) {
                    throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
                }
                continue;
            }
            if (isTypeMatch(Token.Type.SLASH)) {
                try {
                    current = get(0);
                    expr = new Expression("/", expr, setNegationExpression());
                } catch (SemanticException se) {
                    throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
                }
                continue;
            }
            break;
        }
        return expr;
    }

    /**
     * Задать выражение отрицания -E !E
     * 
     * @return отрицание выражения
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    private Expression setNegationExpression() throws SyntaxException, SemanticException {
        Token current = get(0);
        Expression expr;
        if (isTypeMatch(Token.Type.EXCL)) {
            try {
                current = get(0);
                expr = new Expression("!", setEnclosingExpression());
            } catch (SemanticException se) {
                throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
            }
            return expr;
        }
        if (isTypeMatch(Token.Type.MINUS)) {
            try {
                current = get(0);
                expr = new Expression("-", setEnclosingExpression());
            } catch (SemanticException se) {
                throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
            }
            return expr;
        }
        if (isTypeMatch(Token.Type.PLUS)) {
            return setEnclosingExpression();
        }
        return setEnclosingExpression();
    }

    /**
     * Задать заключающее выражение (E)
     * 
     * @return заключенное выражение
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    private Expression setEnclosingExpression() throws SyntaxException, SemanticException {
        if (isTypeMatch(Token.Type.LPAREN)) {
            Token current = get(0);
            Expression expr;
            try {
                current = get(0);
                expr = new Expression("(", setExpression(), ")");
            } catch (SemanticException se) {
                throw new SemanticException(String.format("%s: %s", se.getMessage(), current.getFullPosition()));
            }
            if (isTypeMatch(Token.Type.RPAREN)) {
                current = get(0);
            } else
                throw new SyntaxException(
                        String.format("Ожидалась \")\" вместо %s: %s", current.getText(), current.getFullPosition()));
            return expr;
        }
        return setPrimitiveExpression();
    }

    /**
     * Задать примитивное выражение E
     * 
     * @return примитивное выражение
     * @throws NumberFormatException ошибка конвертации числа
     * @throws SyntaxException       синтаксическая ошибка
     * @throws SemanticException
     */
    private Expression setPrimitiveExpression() throws NumberFormatException, SyntaxException, SemanticException {
        Token current = get(0);
        if (current == null)
            return null;
        if (isTypeMatch(Token.Type.INT)) {
            Expression expr = new Expression(Integer.parseInt(current.getText()));
            return expr;
        }
        if (isTypeMatch(Token.Type.BOOL)) {
            Expression expr = new Expression(Boolean.parseBoolean(current.getText()));
            return expr;
        }
        if (isTypeMatch(Token.Type.STRING)) {
            Expression expr = new Expression(current.getText());
            return expr;
        }
        if (isTypeMatch(Token.Type.VAR)) {
            String var = current.getText();
            Expression expr = null;
            if (variables.get(var) != null)
                expr = variables.get(var);
            else
                throw new SemanticException(
                        String.format("Переменная \"%s\" не инициализирована: %s", var, current.getFullPosition()));
            return expr;
        }
        throw new SyntaxException(
                String.format("Неизвестное выражение \"%s\": %s", current.getText(), current.getFullPosition()));
    }

    /**
     * Парсинг
     * 
     * @return операторы
     * @throws SyntaxException   синтаксическая ошибка
     * @throws SemanticException семантическая ошибка
     */
    public List<Function> parse() throws SyntaxException, SemanticException {
        Expression.resetCounter();
        Statement.resetCounter();
        Function.resetCounter();
        while (true) {
            Function func = setFunction();
            if (func == null)
                break;
            functions.add(func);
            variables.clear();
        }
        return functions;
    }

    /**
     * Печать операторов
     * 
     * @return список операторов в формате строки
     */
    public String printFunctions() {
        String result = "";
        if (tokens.size() != 0)
            for (Function f : functions)
                if (f != null)
                    result += f.printFunction();
        return result;
    }
}