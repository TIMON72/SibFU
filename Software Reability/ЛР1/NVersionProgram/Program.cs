using System;
using System.Collections.Generic;
using System.Linq;
using NVersionProgram.Algorithms;

namespace NVersionProgram
{
    class Program
    {
        static double Func(Point p) => 2 * Math.Pow(p.X, 2) + p.X * p.Y + Math.Pow(p.Y, 2);
        static double FuncExtremum(Point p, double t, Point d) =>
            2 * Math.Pow(p.X + t * d.X, 2) + (p.X + t * d.X) * (p.Y + t * d.Y) + Math.Pow(p.Y + t * d.Y, 2);
        /// <summary>
        /// Вычисление выхода метода
        /// </summary>
        /// <param name="input">входные аргументы (строка)</param>
        /// <param name="versionNum">версия метода</param>
        /// <returns>значение выхода</returns>
        static double CalculateMethodOutput(string input, int versionNum)
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
                    Console.WriteLine("Метод покоординатного спуска вернул: {0}", result);
                    break;
                case 1:
                    p = FletcherReevesMethod.Run(p, Func, FuncExtremum, eps1, eps2, M);
                    result = p.X;
                    Console.WriteLine("Метод Флетчера-Ривса вернул: {0}", result);
                    break;
                case 2:
                    p = DavidFletcherPowellMethod.Run(p, Func, FuncExtremum, eps1, eps2, M);
                    result = p.X;
                    Console.WriteLine("Метод ДФП вернул: {0}", result);
                    break;
                default:
                    break;
            }
            //
            return (double)result;
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
        
        static void Main()
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
            Console.WriteLine("Результаты вычислений функции {0} (координата точки X минимума функции)\n",
                "F = 2 * x^2 + x * y + y^2");
            for (int i = 0; i < versionCount; i++)
            {
                List<double> outputsMethodList = new List<double>();
                for (int j = 0; j < inputs.Length; j++)
                {
                    // Вычисляем выход i версии метода поиска минимума функции
                    double outputMethod = CalculateMethodOutput(inputs[j], i);
                    outputsMethodList.Add(outputMethod);
                }
                // Находим медиану среди результатов
                double medianOutput = CalculateMedianMethodOutput(outputsMethodList);
                Console.WriteLine("Медиана выходов: {0}", medianOutput);
                outputsList.Add(medianOutput);
            }
            // Проводим усредненное голосование
            output = (outputsList.Sum() / versionCount).ToString();
            Console.WriteLine("\nРезультат усредненного голосования: {0}", output);
        }
    }
}
