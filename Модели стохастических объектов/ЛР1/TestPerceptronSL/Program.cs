using System;

namespace TestPerceptronSL
{
    class Program
    {
        // Инициализация весов сети
        static int[,] weights = new int[10, 15];

        // Порог функции активации
        static int w0 = 100;

        static void Main(string[] args)
        {
            // Цифры (Обучающая выборка)
            var num0 = "111101101101111".ToCharArray();
            var num1 = "001001001001001".ToCharArray();
            var num2 = "111001111100111".ToCharArray();
            var num3 = "111001111001111".ToCharArray();
            var num4 = "101101111001001".ToCharArray();
            var num5 = "111100111001111".ToCharArray();
            var num6 = "111100111101111".ToCharArray();
            var num7 = "111001001001001".ToCharArray();
            var num8 = "111101111101111".ToCharArray();
            var num9 = "111101111001111".ToCharArray();

            // Список всех вышеуказанных цифр
            char[][] numbers = { num0, num1, num2, num3, num4, num5, num6, num7, num8, num9 };

            // Искаженные цифры (Тестовая выборка)
            var num11 = "001001001001000".ToCharArray();
            var num41 = "111001111001001".ToCharArray();
            var num51 = "111100111000111".ToCharArray();
            var num52 = "111100010001111".ToCharArray();
            var num53 = "111100011001111".ToCharArray();
            var num54 = "110100111001111".ToCharArray();
            var num55 = "110100111001011".ToCharArray();
            var num56 = "111100101001111".ToCharArray();

            int counter = 0;
            int expectedNum = 0;

            // Тренировка сети
            for (int i = 0; i < 100000; i++)
            {
                // Если получилось НЕ число expectedNumber
                if (counter != expectedNum)
                {
                    // Если сеть выдала True/Да/1, то наказываем ее
                    if (Comparison(numbers[counter], expectedNum)) Decrease(numbers[counter], expectedNum);
                }
                // Если получилось число expectedNumber
                else
                {
                    // Если сеть выдала False/Нет/0, то показываем, что эта цифра - то, что нам нужно
                    if (!Comparison(numbers[counter], expectedNum)) Increase(numbers[counter], expectedNum);
                }
                counter++;
                // Чередуем числа для равномерного обучения
                if (counter > 9)
                    counter = 0;
                // Если обучение провело 10000 итераций на текущем числе, то переключаем на следующее число
                if (i > 9999 && i % 10000 == 0)
                    expectedNum++;
            }

            // Вывод значений весов
            Console.WriteLine("Полученные веса после обучения:");
            for (int i = 0; i < weights.GetLength(0); i++)
            {
                Console.Write(i + ": ");
                for (int j = 0; j < weights.GetLength(1); j++)
                    Console.Write("{0}, ", weights[i, j]);
                Console.WriteLine();
            }

            // Прогон по обучающей выборке
            Console.WriteLine("Результат обучения:");
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                    Console.WriteLine("{0} это {1}? {2}", j, i, Comparison(numbers[j], i));
                Console.WriteLine();
            }

            // Прогон по тестовой выборке
            Console.WriteLine("Испытания по тестовой выборке:");
            Console.WriteLine("Узнал 5? " + Comparison(num5, 5));
            Console.WriteLine("Узнал 1? " + Comparison(num1, 1));
            Console.WriteLine("Узнал 1 - 1? " + Comparison(num11, 1));
            Console.WriteLine("Узнал 4 - 1? " + Comparison(num41, 4));
            Console.WriteLine("Узнал 5 - 1? " + Comparison(num51, 5));
            Console.WriteLine("Узнал 5 - 2? " + Comparison(num52, 5));
            Console.WriteLine("Узнал 5 - 3? " + Comparison(num53, 5));
            Console.WriteLine("Узнал 5 - 4? " + Comparison(num54, 5));
            Console.WriteLine("Узнал 5 - 5? " + Comparison(num55, 5));
            Console.WriteLine("Узнал 5 - 6? " + Comparison(num56, 5));

            Console.ReadKey();
        }

        // Является ли данное число expectedNumber
        static bool Comparison(char[] currentNumber, int expectedNumber)
        {
            // Рассчитываем взвешенную сумму
            var net = 0;
            for (int i = 0; i < 15; i++)
            {
                net += int.Parse(currentNumber[i].ToString()) * weights[expectedNumber, i];
            }
            // Превышен ли порог? (Да - сеть думает, что это expectedNumber. Нет - сеть думает, что это другая цифра)
            return net >= w0;
        }

        // Уменьшение значений весов, если сеть ошиблась и выдала 1
        static void Decrease(char[] currentNum, int expectedNum)
        {
            for (int i = 0; i < 15; i++)
            {
                // Возбужденный ли вход
                if (int.Parse(currentNum[i].ToString()) == 1)
                {
                    // Уменьшаем связанный с ним вес на единицу
                    weights[expectedNum, i]--;
                }
            }
        }

        // Увеличение значений весов, если сеть ошиблась и выдала 0
        static void Increase(char[] currentNum, int expectedNum)
        {
            for (int i = 0; i < 15; i++)
            {
                // Возбужденный ли вход
                if (int.Parse(currentNum[i].ToString()) == 1)
                {
                    // Увеличиваем связанный с ним вес на единицу
                    weights[expectedNum, i]++;
                }
            }
        }
    }
}
