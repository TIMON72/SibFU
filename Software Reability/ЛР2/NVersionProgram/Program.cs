using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NVersionProgram.Algorithms;

namespace NVersionProgram
{
    class Program
    {
        static bool[] IsError = new bool[] { true, false, false }; // ввод ошибки в версии
        static readonly int D = 5000; // во сколько максимально раз увеличить значение выхода (случайно)
        static double Func(Point p) => 2 * Math.Pow(p.X, 2) + p.X * p.Y + Math.Pow(p.Y, 2);
        static double FuncExtremum(Point p, double t, Point d) =>
            2 * Math.Pow(p.X + t * d.X, 2) + (p.X + t * d.X) * (p.Y + t * d.Y) + Math.Pow(p.Y + t * d.Y, 2);
        /// <summary>
        /// Вычисление выхода метода
        /// </summary>
        /// <param name="input">входные аргументы (строка)</param>
        /// <param name="versionNum">версия метода</param>
        /// <returns>значение выхода</returns>
        static double CalculateMethodOutput(string input, int versionNum, bool isLog)
        {
            //
            double? result = null;
            // Парсинг входных данных
            string[] args = input.Split(" ");
            Point p = new Point(double.Parse(args[0]), double.Parse(args[1]));
            double eps1 = double.Parse(args[2]);
            double eps2 = double.Parse(args[3]);
            int M = int.Parse(args[4]);
            // Выбор алгоритма и вычисление
            switch (versionNum)
            {
                case 0:
                    p = CoordinateDescentMethod.Run(p, Func, eps1, eps2, M);
                    result =-p.X;
                    if (isLog)
                        Console.WriteLine("Метод покоординатного спуска вернул: {0}", result);
                    break;
                case 1:
                    p = FletcherReevesMethod.Run(p, Func, FuncExtremum, eps1, eps2, M);
                    result = p.X;
                    if (isLog)
                        Console.WriteLine("Метод Флетчера-Ривса вернул: {0}", result);
                    break;
                case 2:
                    p = DavidFletcherPowellMethod.Run(p, Func, FuncExtremum, eps1, eps2, M);
                    result = p.X;
                    if (isLog)
                        Console.WriteLine("Метод ДФП вернул: {0}", result);
                    break;
                default:
                    break;
            }
            //
            return (double)result;
        }
        /// <summary>
        /// Добавление ошибки в результаты выходов
        /// </summary>
        /// <param name="outputs">Список выходов</param>
        private static void AddError(ref List<double> outputs)
        {
            Random rnd = new Random();
            for (int i = 0; i < outputs.Count; i++)
                outputs[i] += outputs[i] * rnd.Next(1, D);
            Console.WriteLine("Результат после добавления ошибок:");
            for (int i = 0; i < outputs.Count; i++)
                Console.WriteLine(outputs[i]);
        }
        /// <summary>
        /// Вычисление медианы выходов метода
        /// </summary>
        /// <param name="outputsList">список выходов</param>
        /// <returns>значение медианы</returns>
        static double CalculateMedianMethodOutput(List<double> outputsList)
        {
            outputsList.Sort();
            int size = outputsList.Count;
            if (size % 2 != 0)
                return outputsList[size / 2];
            else
                return (outputsList[(size - 1) / 2] + outputsList[size / 2]) / 2.0;
        }
        /// <summary>
        /// Проверка программы на корректность
        /// </summary>
        /// <param name="result">Результат для проверки</param>
        private static void Check(double result)
        {
            IsError = new bool[] { false, false, false };
            double expectedResult = Run(false);
            double deviation = Math.Abs(expectedResult - result);
            //double deviation = Math.Abs(Math.Abs(expectedResult - result) / expectedResult);
            Console.WriteLine("Отклонение от истинного результата: " + deviation);
        }
        /// <summary>
        /// Запуск программы
        /// </summary>
        /// <param name="isLog">Вывод в консоль</param>
        /// <returns></returns>
        static double Run(bool isLog)
        {
            // Параметры
            string[] inputs = new string[]
            {
                "10 10 0,1 0,1 10",
                "5 5 0,15 0,15 10",
                "50 50 0,2 0,2 20",
                "-5 -5 0,1 0,1 10",
                "-10 -10 0,15 0,15 10"
            };
            int versionCount = 3;
            string output;
            List<double> outputsList = new List<double>();
            // Вычисляем выходы каждой версии
            if (isLog)
                Console.WriteLine("Результаты вычислений функции {0} (координата точки X минимума функции)\n",
                    "F = 2 * x^2 + x * y + y^2");
            for (int i = 0; i < versionCount; i++)
            {
                List<double> outputsMethodList = new List<double>();
                for (int j = 0; j < inputs.Length; j++)
                {
                    // Вычисляем выход i версии метода поиска минимума функции
                    double outputMethod = CalculateMethodOutput(inputs[j], i, isLog);
                    outputsMethodList.Add(outputMethod);
                }
                if (IsError[i])
                    AddError(ref outputsMethodList);
                // Находим медиану среди результатов
                double medianOutput = CalculateMedianMethodOutput(outputsMethodList);
                if (isLog)
                    Console.WriteLine("Медиана выходов: {0}\n", medianOutput);
                outputsList.Add(medianOutput);
            }
            // Проводим усредненное голосование
            output = (outputsList.Sum() / versionCount).ToString();
            if (isLog)
                Console.WriteLine("\nРезультат усредненного голосования: {0}", output);
            return double.Parse(output);
        }
        /// <summary>
        /// Главный метод
        /// </summary>
        static void Main()
        {
            double result = Run(true);
            Check(result);
        }
    }
}
