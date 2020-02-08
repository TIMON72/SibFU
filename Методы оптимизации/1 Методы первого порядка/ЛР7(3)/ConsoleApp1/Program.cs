using System;
using System.Collections.Generic;
using System.Diagnostics;
using MathNet.Numerics;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Function
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static double Func(Point p) => //Math.Pow(p.X, 2) + p.X * p.Y + Math.Pow(p.Y, 2);
        //Math.Pow(p.X, 2) + 5 * p.X * p.Y + Math.Pow(p.Y, 2);
        4 * p.X + 2 * p.Y + Math.Pow(p.X, 2) + Math.Pow(p.Y, 2) + 5;
        /// <summary>
        /// Градиент функции в точке
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static Point GradFunc(Point p)
        {
            //double derX = 2 * p.X + 5 * p.Y;
            //double derY = 5 * p.X + 2 * p.Y;
            double dx = 0.001;
            double dy = 0.001;
            double derX = (Func(new Point(p.X + dx, p.Y)) - Func(p)) / dx;
            double derY = (Func(new Point(p.X, p.Y + dy)) - Func(p)) / dy;
            return new Point(derX, derY);
        }
        /// <summary>
        /// Вывести результат в консоль
        /// </summary>
        /// <param name="resultPoint"></param>
        /// <param name="steps"></param>
        static void PrintResult(Point resultPoint, int steps)
        {
            double result = Func(resultPoint);
            Console.WriteLine("X = " + resultPoint.X + "; Y = " + resultPoint.Y);
            Console.WriteLine("Результат: {0:F10}", result);
            Console.WriteLine("Точность: {0:F10}", Math.Abs(Func(new Point(0, 0)) - result));
            Console.WriteLine("Количество шагов: {0}", steps);
        }
        /// <summary>
        /// Метод покоординатного спуска
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="eps"></param>
        static void Run(Point x00, double eps = 0.0, double eps1 = 0.1, double eps2 = 0.15, int M = 10)
        {
            // !!! Параметр eps = 0 не нужен в алгоритме
            int reiteration = 0; // для шага 11 отслеживание повторения условия для j и j - 1
            int steps = 0;
            // Шаг 1
            int n = 2;
            if (M % n == 1)
            {
                Console.WriteLine("Вы вабрали M не кратное n");
                return;
            }
            List<List<Point>> x = new List<List<Point>>();
            x.Add(new List<Point>(n + 1));
            x[0].Add(x00); //x[0,0] = x00
            Point gradF = GradFunc(x[0][0]);
            // Шаг 2
            int j = 0;
            int k = 0; // k <= n - 1
            List<Point> e = new List<Point> { null, new Point(1, 0), new Point(0, 1) };
            List<double> t = new List<double>();
            // Шаг 3
            step3:
            if (j >= M)
            {
                PrintResult(x[j][0], steps); // x[j][k]
                return;
            }
            // Шаг 4
            k = 0;
            // Шаг 5
            step5:
            // б
            if (k > n - 1)
            {
                x.Add(new List<Point> { null });
                x[j + 1][0] = x[j][n]; //!!! ошибка в алгоритме, там написано x[j + 1][k] = x[j][n]
                j++;
                //steps++;
                goto step3;
            }
            // Шаг 6
            gradF = GradFunc(x[j][k]);
            // Шаг 7
            if (gradF.GetLength() <= eps1) // || gradF(x[j,k]) || <= eps1
            {
                PrintResult(x[j][k], steps);
                return;
            }
            // Шаг 8
            t.Add(0.5); // t[k] = 0.5
            x[j].Add(null); // t[j][k+1] = null
            while (true)
            {
                // Шаг 9
                double der = 0;
                if (k + 1 == 1) //dF(p)/dx
                {
                    double dx = 0.001;
                    der = (Func(new Point(x[j][k].X + dx, x[j][k].Y)) - Func(x[j][k])) / dx;
                    //der = 2 * x[j][k].X + 5 * x[j][k].Y;
                }
                else if (k + 1 == n) // dF(p)/dy
                {
                    double dy = 0.001;
                    der = (Func(new Point(x[j][k].X, x[j][k].Y + dy)) - Func(x[j][k])) / dy;
                    //der = 5 * x[j][k].X + 2 * x[j][k].Y;
                }
                x[j][k + 1] = x[j][k] - t[k] * der * e[k + 1];
                // Шаг 10
                if (Func(x[j][k + 1]) - Func(x[j][k]) < 0)
                {
                    break;
                }
                else
                {
                    t[k] = t[k] / 2;
                    continue;
                }
            }
            // Шаг 11
            if ((x[j][k + 1] - x[j][k]).GetLength() < eps2 && Math.Abs(Func(x[j][k + 1]) - Func(x[j][k])) < eps2)
            {
                reiteration++;
                if (reiteration == 2) // j - 1 тоже соответствовало данному условию
                {
                    PrintResult(x[j][k + 1], steps);
                    return;
                }
            }
            else
            {
                reiteration = 0;
            }
            k++;
            steps++;
            goto step5;
        }
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("НЕ ТЕСТ");
            Console.WriteLine("Берем стандартные параметры");
            sw.Reset();
            sw.Start();
            Run(new Point(4, 5));
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 1");
            Console.WriteLine("Берем стандартные параметры");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10));
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 2");
            Console.WriteLine("Увеличиваем eps1");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0, 0.5);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 3");
            Console.WriteLine("Уменьшаем eps1");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0, 0.01);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 4");
            Console.WriteLine("Увеличиваем eps2");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0, 0.1, 0.5);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 5");
            Console.WriteLine("Уменьшаем eps2");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0, 0.1, 0.01);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 6");
            Console.WriteLine("Уменьшаем M");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0, 0.1, 0.15, 4);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 7");
            Console.WriteLine("Увеличиваем M");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0, 0.1, 0.15, 20);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
