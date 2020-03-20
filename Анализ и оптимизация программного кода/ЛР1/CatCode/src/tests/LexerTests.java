package tests;

import static org.junit.Assert.assertEquals;

import org.junit.Assert;
import org.junit.Test;

import app.classes.analysis.Lexer;

public class LexerTests {

    @Test
    public void printTokensTest() throws Exception {
        // Тест 1
        var expr = "2 + 2";
        var actual = new Lexer(expr).printTokens();
        var expected = "INT 2\nPLUS +\nINT 2\n";
        assertEquals("Ошибка в тесте 1", actual, expected);
        System.out.println("Тест 1\n" + expr + "\n" + actual);
        // Тест 2
        expr = "def main(a, b) { return; }";
        actual = new Lexer(expr).printTokens();
        expected = "DEF def\nVAR main\nLPAREN (\nVAR a\nCOMMA ,\nVAR b\nRPAREN )\n"
                + "LBRACE {\nRETURN return\nSEMICOLON ;\nRBRACE }\n";
        assertEquals("Ошибка в тесте 2", actual, expected);
        System.out.println("Тест 2\n" + expr + "\n" + actual);
        // Тест 3
        expr = "a = 2; b = \"2\";";
        actual = new Lexer(expr).printTokens();
        expected = "VAR a\nEQ =\nINT 2\nSEMICOLON ;\nVAR b\nEQ =\nSTRING 2\n" + "SEMICOLON ;\n";
        assertEquals("Ошибка в тесте 3", actual, expected);
        System.out.println("Тест 3\n" + expr + "\n" + actual);
        // Тест 4
        expr = "true trues ffalse false";
        actual = new Lexer(expr).printTokens();
        expected = "BOOL true\nVAR trues\nVAR ffalse\nBOOL false\n";
        assertEquals("Ошибка в тесте 4", actual, expected);
        System.out.println("Тест 4\n" + expr + "\n" + actual);
        // Тест 5
        expr = "Привет";
        try {
            actual = new Lexer(expr).printTokens();
            Assert.fail("Ошибка в тесте 5");
        } catch (Exception e) {
            Assert.assertTrue(e.toString(), true);
            System.out.println("Тест 5\n" + expr + "\n" + e.toString());
        }
        // Тест 6
        expr = "def (a) { &a = 5 }";
        try {
            actual = new Lexer(expr).printTokens();
            Assert.fail("Ошибка в тесте 6");
        } catch (Exception e) {
            Assert.assertTrue(e.toString(), true);
            System.out.println("Тест 6\n" + expr + "\n" + e.toString());
        }
        // Тест 7
        expr = "a1 = 1b";
        actual = new Lexer(expr).printTokens();
        expected = "VAR a1\nEQ =\nINT 1\nVAR b\n";
        assertEquals("Ошибка в тесте 7", actual, expected);
        System.out.println("Тест 7\n" + expr + "\n" + actual);
        // Тест 8
        expr = "// Comment комментарий";
        actual = new Lexer(expr).printTokens();
        expected = "COMMENT  Comment комментарий\n";
        assertEquals("Ошибка в тесте 8", actual, expected);
        System.out.println("Тест 8\n" + expr + "\n" + actual);
        // Тест 9
        expr = "\"text\" DEF";
        actual = new Lexer(expr).printTokens();
        expected = "STRING text\nVAR DEF\n";
        assertEquals("Ошибка в тесте 9", actual, expected);
        System.out.println("Тест 9\n" + expr + "\n" + actual);
        // Тест 10
        expr = "a = \"text12{\"true}\"";
        try {
            actual = new Lexer(expr).printTokens();
            Assert.fail("Ошибка в тесте 10");
        } catch (Exception e) {
            Assert.assertTrue(e.toString(), true);
            System.out.println("Тест 10\n" + expr + "\n" + e.toString());
        }
    }
}