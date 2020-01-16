using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static string input; // Входная строка
        static List<string> list = new List<string>();
        static int pos = 1;
        static char currentNotation = '9'; // текущая система счисления
        static char[] numbers = "0123456789ABCDEF".ToCharArray(); // алфавит
        static char[] notations = "3AE".ToCharArray(); // системы счисления (4, 11, 15)
        static char[] variables = "abcdefghijklmnopqrstuvwxyz".ToCharArray(); // переменные
        static char[] operations = "*/+-=".ToCharArray(); // операции

        /// <summary>
        /// Получить первый символ
        /// </summary>
        /// <returns></returns>
        static char ReadChar()
        {
            return input[0];
        }
        /// <summary>
        /// Удаляем первый символ
        /// </summary>
        static void Next()
        {
            input = input.Substring(1);
        }
        /// <summary>
        /// S -> PE
        /// </summary>
        static void S()
        {
            Console.WriteLine("S -> PE");
            list.Add("");//list.Add("result: ");
            list.Add("");
            P();
            E();
        }
        /// <summary>
        /// P -> IA=X
        /// </summary>
        static void P()
        {
            Console.WriteLine("P -> IA=X");
            I();
            A();
            string rule = "";
            char result = ReadChar();
            if (result == '=')
            {
                rule = "=";
            }
            if (rule == "")
                throw new Exception();
            Console.WriteLine("P -> I" + rule);
            switch (rule)
            {
                case "=": Next(); break;
            }
            X();
        }
        /// <summary>
        /// I -> var
        /// </summary>
        static void I()
        {
            string rule = "";
            char result = ReadChar();
            // I - переменная?
            foreach (char ch in variables)
            {
                if (result == ch)
                {
                    rule = "var";
                    break;
                }
            }
            if (rule == "")
                throw new Exception();
            Console.WriteLine("I -> " + rule);
            switch (rule)
            {
                case "var": Next(); break;
            }
        }
        /// <summary>
        /// A -> I | null
        /// </summary>
        static void A()
        {
            string rule = "";
            char result = ReadChar();
            // A is = ?
            if (result == '=')
            {
                rule = "null";
            }
            // A - переменная?
            else
            {
                foreach (char ch in variables)
                {
                    if (result == ch)
                    {
                        rule = "I";
                        break;
                    }
                }
            }
            if (rule == "")
                throw new Exception();
            Console.WriteLine("A -> " + rule);
            switch (rule)
            {
                case "I": Next(); break;
                case "null": break;
            }
        }
        /// <summary>
        /// X -> P | null
        /// </summary>
        static void X()
        {
            string rule = "";
            char result = ReadChar();
            // X - переменная?
            foreach (char ch in variables)
            {
                // Если X -> переменная
                if (result == ch)
                {
                    rule = "P";
                    break;
                }
            }
            // X - унарный минус?
            if (result == '-')
            {
                rule = "null";
            }
            // X - число или скобка?
            else
            {
                foreach (char ch in numbers)
                {
                    if (result == '(' || result == ch || ch == '-')
                    {
                        rule = "null";
                        break;
                    }
                }
            }
            if (rule == "")
                throw new Exception();
            Console.WriteLine("X -> " + rule);
            switch (rule)
            {
                case "P": P(); break;
                case "null": break;
            }
        }
        /// <summary>
        /// E -> MTF
        /// </summary>
        static void E()
        {
            Console.WriteLine("E -> MTF");
            M();
            T();
            F();
        }
        /// <summary>
        /// M -> - | null
        /// </summary>
        static void M()
        {
            string rule = "";
            char result = ReadChar();
            // M is - ?
            if (result == '-')
            {
                rule = "-";
            }
            // M - число или скобка?
            else
            {
                foreach (char ch in numbers)
                {
                    if (result == '(' || result == ch)
                    {
                        rule = "null";
                        break;
                    }
                }
            }
            if (rule == "")
                throw new Exception();
            Console.WriteLine("M -> " + rule);
            switch (rule)
            {
                case "-": Next(); break;
                case "null": break;
            }
        }
        /// <summary>
        /// T -> QxJY | (E)
        /// </summary>
        static void T()
        {
            string rule = "";
            char result = ReadChar();
            // T - число ?
            foreach (char ch in numbers)
            {
                // Если T -> (E)
                if (result == '(')
                {
                    rule = "(E)";
                    // Если узел дерева не конечный
                    if (pos < list.Count - 1)
                    {
                        pos++;
                    }
                    // Иначе создаем узел
                    else
                    {
                        list.Add("");
                        pos++;
                    }
                    break;
                }
                // Если T -> число
                if (result == ch)
                {
                    rule = "QxJY";
                    break;
                }
            }
            if (rule == "")
                throw new Exception();
            Console.WriteLine("T -> " + rule);
            switch (rule)
            {
                case "QxJY":
                    Q();
                    result = ReadChar();
                    if (result == 'x')
                    {
                        rule = "x";
                    }
                    if (rule == "")
                        throw new Exception();
                    Console.WriteLine("T -> Q" + rule);
                    switch (rule)
                    {
                        case "x": Next(); break;
                    }
                    J();
                    Y(); break;
                case "(E)": Next(); E(); Next(); break;
            }
        }
        /// <summary>
        /// Q -> not
        /// </summary>
        static void Q()
        {
            string rule = "";
            char result = ReadChar();
            // Q - префикс системы счисления?
            foreach (char ch in notations)
            {
                if (result == ch)
                {
                    rule = "not";
                    currentNotation = result;
                    list[pos] += result.ToString();
                    break;
                }
            }
            if (rule == "")
                throw new Exception();
            Console.WriteLine("Q -> " + rule);
            switch (rule)
            {
                case "not": Next(); break;
            }
        }
        /// <summary>
        /// J -> num
        /// </summary>
        static void J()
        {
            string rule = "";
            char result = ReadChar();
            // J - число?
            foreach (char ch in numbers)
            {
                // Если число есть в алфавите и оно попадает в заданную систему счисления
                if (result == ch && Array.IndexOf(numbers, result) <= Array.IndexOf(numbers, currentNotation))
                {
                    rule = "num";
                    list[pos] += result.ToString();
                    break;
                }
            }
            if (rule == "")
                throw new Exception();
            Console.WriteLine("J -> " + rule);
            switch (rule)
            {
                case "num": Next(); break;
            }
        }
        /// <summary>
        /// Y -> JY | null
        /// </summary>
        static void Y()
        {
            string rule = "";
            char result = ReadChar();
            // Y - число?
            foreach (char ch in numbers)
            {
                // Если Y -> переменная
                if (result == ch)
                {
                    rule = "JY";
                    break;
                }
            }
            // Y - скобка или окончание или операция?
            foreach (char ch in operations)
            {
                if (result == ')' || result == '$' || result == ch)
                {
                    rule = "null";
                    break;
                }
            }
            if (rule == "")
                throw new Exception();
            Console.WriteLine("Y -> " + rule);
            switch (rule)
            {
                case "JY": J(); Y(); break;
                case "null": break;
            }
        }
        /// <summary>
        /// F -> E | null
        /// </summary>
        static void F()
        {
            string rule = "";
            char? result = ReadChar();
            // F - скобка или окончание?
            if (result == ')' || result == '$')
            {
                rule = "null";
                result = null;
                //Console.WriteLine(list[pos]); // Вывод на экран последнего узла
                //list[pos] = Calculation(list[pos]); // Вычисляем результат последнего узла
                pos--; // Переходим на предпоследний узел
                list[pos] += list[pos + 1]; // Помещаем вычисленные результаты в предпоследний узел из последнего
                list.RemoveAt(pos + 1); // Удаляем последний узел
            }
            // F - операция?
            else
            {
                foreach (char ch in operations)
                {
                    if (result == ch)
                    {
                        rule = "E";
                        list[pos] += result.ToString();
                        break;
                    }
                }
            }
            if (rule == "")
                throw new Exception();
            Console.WriteLine("F -> " + result + rule);
            switch (rule)
            {
                case "E": Next(); E(); break; // F -> +E
                case "null": break; // F -> null
            }
        }
        /// <summary>
        /// Вычисления с учетом приоритетности операций (рекурсия)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string Calculation(string str)
        {
            const int sizeI = 2;
            const int sizeJ = 2;
            char[,] operationsPriority = new char[sizeI, sizeJ] { { '*', '/' }, { '+', '-' } }; // Массив с приоритетностью знаков
            for (int i = 0; i < sizeI; i++)
                for (int j = 0; j < sizeJ; j++)
                {
                    int result = str.IndexOf(operationsPriority[i, j]); // Находим индекс приоритетного знака
                    if (result != -1)
                    {
                        // Строка до индекса найденного знака с ближайшим индексом знака слева от найденного (если есть)
                        string start = str.Substring(0, result);
                        int startIndex = start.LastIndexOfAny(operations);
                        // Строка после индекса найденного знака с ближайшим индексом знака справа от найденного (если есть)
                        string end = str.Substring(result + 1);
                        int endIndex = end.IndexOfAny(operations);
                        // Преобразуем в элементарное выражение приоритетную операцию из всего выражения
                        string simpleExpression = "";
                        // Если слева и справа есть знаки
                        if (startIndex != -1 && endIndex != -1)
                            simpleExpression = str.Substring(result - startIndex, result + 1 + endIndex);
                        // Если только справа есть знак
                        else if (startIndex == -1 && endIndex != -1)
                            simpleExpression = str.Substring(0, result + 1 + endIndex);
                        // Если только слева есть знак
                        else if (startIndex != -1 && endIndex == -1)
                            simpleExpression = str.Substring(result - startIndex);
                        // Если знаков справа и слева больше нет
                        else
                            simpleExpression = str;
                        string expressionResult = SimpleAriphmetic(simpleExpression, str[result]); // Вычисляем элементарную операцию
                        str = str.Replace(simpleExpression, expressionResult); // Заменяем элементарную операцию на результат
                        str = Calculation(str); // Рекурсия
                    }
                }
            return str;
        }
        /// <summary>
        /// Элементарные вычисления
        /// </summary>
        /// <param name="simpleExpression"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        static string SimpleAriphmetic(string simpleExpression, char sign)
        {
            int result = 0;
            int signIndex = simpleExpression.IndexOf(sign);
            int a = Convert.ToInt32(simpleExpression.Substring(0, signIndex));
            int b = Convert.ToInt32(simpleExpression.Substring(signIndex + 1));
            if (sign == '*')
                result = a * b;
            else if (sign == '/')
                result = a / b;
            else if (sign == '+')
                result = a + b;
            else if (sign == '-')
                result = a - b;
            return result.ToString();
        }
        /// <summary>
        /// Главная функция
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите выражение(я): ");
                string[] inputs = Console.ReadLine().Split(';', '\n');
                if (inputs[inputs.Length - 1] == "")
                {
                    inputs = inputs.Where(i => i != "").ToArray();
                }
                for (int i = 0; i < inputs.Length; i++)
                {
                    list.Clear();
                    pos = 1;
                    input = inputs[i] + '$';
                    input = input.Replace(" ", "");
                    try
                    {
                        S();
                        Console.WriteLine((ReadChar() == '$') ? "Accepted" : "Rejected");
                        //Console.WriteLine(list[0]);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Rejected");
                    }
                }
            }           
        }
    }
}
