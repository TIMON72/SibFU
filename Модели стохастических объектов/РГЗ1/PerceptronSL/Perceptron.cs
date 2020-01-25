using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PerceptronSL
{
    public static class Perceptron
    {
        static int w0 = 7;
        static int[] num0 = new int[] { 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1 };
        static int[] num1 = new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 };
        static int[] num2 = new int[] { 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
        static int[] num3 = new int[] { 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1 };
        static int[] num4 = new int[] { 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1 };
        static int[] num5 = new int[] { 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1 };
        static int[] num6 = new int[] { 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
        static int[] num7 = new int[] { 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 };
        static int[] num8 = new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
        static int[] num9 = new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1 };
        // Тестовая выборка
        static int[] num00 = new int[] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1 };
        static int[] num01 = new int[] { 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1 };
        static int[] num02 = new int[] { 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1 };
        static int[] num10 = new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1 };
        static int[] num11 = new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 };
        static int[] num12 = new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0 };
        static int[] num20 = new int[] { 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
        static int[] num21 = new int[] { 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1 };
        static int[] num22 = new int[] { 1, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1 };
        static int[] num30 = new int[] { 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1 };
        static int[] num31 = new int[] { 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1 };
        static int[] num32 = new int[] { 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0 };
        static int[] num40 = new int[] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1 };
        static int[] num41 = new int[] { 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1 };
        static int[] num42 = new int[] { 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0 };
        static int[] num50 = new int[] { 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 1, 1 };
        static int[] num51 = new int[] { 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1 };
        static int[] num52 = new int[] { 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1 };
        static int[] num60 = new int[] { 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
        static int[] num61 = new int[] { 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
        static int[] num62 = new int[] { 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1 };
        static int[] num70 = new int[] { 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 };
        static int[] num71 = new int[] { 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0 };
        static int[] num72 = new int[] { 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 };
        static int[] num80 = new int[] { 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
        static int[] num81 = new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1 };
        static int[] num82 = new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0 };
        static int[] num90 = new int[] { 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1 };
        static int[] num91 = new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1 };
        static int[] num92 = new int[] { 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1 };
        static int[][] numbers = new int[][] { num0, num1, num2, num3, num4, num5, num6, num7, num8, num9 };
        static int[][] testNumbers = new int[][] { num00, num01, num02, num10, num11, num12, num20, num21,
            num22, num30, num31, num32, num40, num41, num42, num50, num51, num52, num60, num61, num62, num70,
            num71, num72, num80, num81, num82, num90, num91, num92 };
        static int[,] weights = new int[numbers.Length, numbers[0].Length];

        /// <summary>
        /// Обучение персептрона (Teaching равномерное, ExperienceTeaching нет)
        /// </summary>
        public static string Teaching(int n)
        {
            bool success;
            do
            {
                success = true;
                // Тренировка сети
                int counter = 0; // Счетчик массива numbers
                int expNum = 0; // Ожидаемое текущее число число
                for (int i = 0; i < n; i++)
                {
                    // Если получилось НЕ число expNum
                    if (counter != expNum)
                    {
                        // Если сеть выдала True/Да/1, то наказываем ее
                        if (Comparison(numbers[counter], expNum, false))
                            Decrease(numbers[counter], expNum);
                    }
                    // Если получилось число expNum
                    else
                    {
                        // Если сеть выдала False/Нет/0, то показываем, что эта цифра - то, что нам нужно
                        if (!Comparison(numbers[counter], expNum, false))
                            Increase(numbers[counter], expNum);
                    }
                    counter++;
                    // Чередуем числа для равномерного обучения
                    if (counter > 9)
                        counter = 0;
                    // Если обучение провело 10000 итераций на текущем числе, то переключаем на следующее число
                    if (i > 99999 && i % 100000 == 0)
                        expNum++;
                }
                // Проверяем корректность обучения
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (!Comparison(numbers[i], i, false))
                        success = false;
                }
            } while (!success);
            return TestTeaching();
        }
        public static double ExperienceTeaching(int n, int errors_size)
        {
            double[] errors = new double[errors_size];
            Random rnd = new Random();
            for (int k = 0; k < errors_size; k++)
            {
                bool success;
                do
                {
                    success = true;
                    // Тренировка сети
                    int num = rnd.Next(0, 10); // Выбираем случайно число
                    int expNum = rnd.Next(0, 10); // Ожидаемое текущее число число
                    for (int i = 0; i < n; i++)
                    {
                        // Если получилось НЕ число expNum
                        if (num != expNum)
                        {
                            // Если сеть выдала True/Да/1, то наказываем ее
                            if (Comparison(numbers[num], expNum, false))
                                Decrease(numbers[num], expNum);
                        }
                        // Если получилось число expNum
                        else
                        {
                            // Если сеть выдала False/Нет/0, то показываем, что эта цифра - то, что нам нужно
                            if (!Comparison(numbers[num], expNum, false))
                                Increase(numbers[num], expNum);
                        }
                    }
                    // Проверяем корректность обучения
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (!Comparison(numbers[i], i, false))
                            success = false;
                    }
                } while (!success);
                errors[k] = TestExperienceTeaching(); // записываем ошибку k-ой обученной нейросети
            }
            return errors.Sum() / errors_size;
        }
        /// <summary>
        /// Тестирование обученной нейросети
        /// </summary>
        /// <returns></returns>
        static string TestTeaching()
        {
            string answer = "";
            int expNum = 0;
            int j = 0;
            int counter = 0;
            double wrong = 0;
            do
            {
                if (!Comparison(testNumbers[j], expNum, false))
                {
                    wrong++;
                    answer += "testing num" + expNum.ToString() + counter.ToString() + "... false\n";
                }
                else
                {
                    answer += "testing num" + expNum.ToString() + counter.ToString() + "... true\n";
                }
                j++;
                counter++;
                if (j % 3 == 0)
                {
                    expNum++;
                    counter = 0;
                }
            } while (expNum != 10);
            double error = wrong / testNumbers.Length * 100;
            answer += "Ошибка: " + error + "%\n";
            return answer;
        }
        static double TestExperienceTeaching()
        {
            int expNum = 0;
            int j = 0;
            int counter = 0;
            double wrong = 0;
            do
            {
                if (!Comparison(testNumbers[j], expNum, false))
                {
                    wrong++;
                }
                j++;
                counter++;
                if (j % 3 == 0)
                {
                    expNum++;
                    counter = 0;
                }
            } while (expNum != 10);
            double error = wrong / testNumbers.Length;
            return error;
        }
        /// <summary>
        /// Запуск персептрона
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        static public string Run(Rectangle[,] matrix)
        {
            int[] input = Sensing(matrix); // Этап 1 - восприятие сенсорами входных данных
            bool[] probabilityNumbers = Association(input); // Этап 2 - Ассоциация входных данных с собственными (которые получены в результате обучения)
            string answer = Reaction(probabilityNumbers); // Этап 3 - Реакция на полученный результат
            return answer;
        }
        /// <summary>
        /// Преобразование входных данных в сигналы для персептрона
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        static int[] Sensing(Rectangle[,] matrix)
        {
            int[] input = new int[matrix.GetLength(0) * matrix.GetLength(1)];
            w0 = input.Length / 2;
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j].Fill == Brushes.Black)
                        input[counter] = 1;
                    else
                        input[counter] = 0;
                    counter++;
                }
            return input;
        }
        /// <summary>
        /// Ассоциация входных сигналов с данными обученного персептрона
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static bool[] Association(int[] input)
        {
            bool[] probabilityNumbers = new bool[numbers.Length];
            int maxSumWeight = w0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int sumWeight = Comparison(input, i, true);
                if (sumWeight > maxSumWeight)
                {
                    probabilityNumbers = new bool[numbers.Length];
                    probabilityNumbers[i] = true;
                    maxSumWeight = sumWeight;
                }
                else if (sumWeight == maxSumWeight)
                {
                    probabilityNumbers[i] = true;
                }
                else
                {
                    probabilityNumbers[i] = false;
                }
            }
            return probabilityNumbers;
        }
        /// <summary>
        /// Реакция персептрона на результат
        /// </summary>
        /// <param name="probabilityNumbers"></param>
        /// <returns></returns>
        static string Reaction(bool[] probabilityNumbers)
        {   
            string answer = "Это число похоже на ";
            for (int i = 0; i < probabilityNumbers.Length; i++)
            {
                if (probabilityNumbers[i])
                    answer = answer + i + "; ";
            }
            return answer;
        }
        /// <summary>
        /// Cопоставление входного числа с ожидаемым
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expNum"></param>
        /// <param name="returnSumW"></param>
        /// <returns></returns>
        static dynamic Comparison(int[] input, int expNum, bool returnSumW)
        {
            // Рассчитываем взвешенную сумму
            var sumW = 0;
            for (int i = 0; i < input.Length; i++)
                sumW += input[i] * weights[expNum, i];
            // Превышен ли порог ? (Да - сеть думает, что это expNum.Нет - сеть думает, что это другая цифра)
            if (returnSumW)
            {
                if (sumW >= w0)
                    return sumW;
                else
                    return 0;
            }
            else
                return sumW >= w0;
        }
        /// <summary>
        /// Уменьшение веса, если персептрон ошибся и сказал true
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expNum"></param>
        static void Decrease(int[] input, int expNum)
        {
            for (int i = 0; i < input.Length; i++)
                // Возбужденный ли вход
                if (input[i] == 1)
                    // Уменьшаем связанный с ним вес на единицу
                    weights[expNum, i]--;
        }
        /// <summary>
        /// Увеличение веса, если персептрон ошибся и сказал false
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expNum"></param>
        static void Increase(int[] input, int expNum)
        {
            for (int i = 0; i < input.Length; i++)
                // Возбужденный ли вход
                if (input[i] == 1)
                    // Увеличиваем связанный с ним вес на единицу
                    weights[expNum, i]++;
        }
    }
}
