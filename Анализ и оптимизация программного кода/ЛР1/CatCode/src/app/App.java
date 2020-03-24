package app;

import java.awt.Desktop;
import java.io.File;
import java.util.Scanner;
import tests.LexerTests;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner scan = new Scanner(System.in);
        int option = 0;
        String input = "";
        while (!"4".equals(input)) {
            System.out.flush();
            System.out.println("1. Запуск тестов");
            System.out.println("2. Открыть документацию");
            System.out.println("3. Открыть ChangeLog");
            System.out.println("4. Выход");
            System.out.print("Выберите пункт меню: ");
            input = scan.next();
            try {
                option = Integer.parseInt(input);
            } catch (Exception e) {
                e.printStackTrace();
            }
            switch (option) {
                case 1:
                    LexerTests lt = new LexerTests();
                    lt.printTokensTest();
                    break;
                case 2:
                    try {
                        String url = "docs/html/index.html";
                        File file = new File(url);
                        Desktop.getDesktop().browse(file.toURI());
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                    break;
                case 3:
                    try {
                        String url = "CHANGELOG.md";
                        File file = new File(url);
                        Desktop.getDesktop().browse(file.toURI());
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
            }
            if (option != 4) {
                System.out.println("Нажмите ENTER чтобы продолжить");
                System.in.read();
            }
        }
        scan.close();
    }
}