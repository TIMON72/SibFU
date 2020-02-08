using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Функция для одномерной минимизации
        /// </summary>
        /// <param name="p"></param>
        /// <param name="t"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        static double FuncExtremum(Point p, double t, Point d) => Math.Pow(p.Y + t * d.Y, 2) + 6 * Math.Pow(p.X + t * d.X, 2) + 5 * (p.X + t * d.X) + 2 * (p.Y + t * d.Y) + 1;
        /// <summary>
        /// Поиск экстремума методом одномерной минимизации (золотого сечения)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        static double FindExtremum(Point p, Point d)
        {
            double a = p.X + 100; // Левая граница по X начальной точки
            double b = p.X - 100; // Правая граница по X начальной точки
            double eps = 0.01;
            double x = 0;
            double y = 0;
            double Fy = 0;
            double z = 0;
            double Fz = 0;
            double length = 0;
            int k = 0;
            // Step 1
            length = b - a;
            // Step 2
            k = 0;
            // Step 3
            y = a + ((3 - Math.Sqrt(5)) / 2) * (b - a);
            z = a + b - y;
            while (true)
            {
                // Step 4
                Fy = FuncExtremum(p, y, d);
                Fz = FuncExtremum(p, z, d);
                // Step 5
                if (Fy <= Fz)
                {
                    // a = a;
                    b = z;
                    z = y;
                    y = a + b - y;
                }
                else
                {
                    a = y;
                    // b = b;
                    y = z;
                    z = a + b - z;
                }
                // Step 6
                double delta = Math.Abs(a - b);
                if (delta <= eps)
                {
                    x = (a + b) / 2;
                    break;
                }
                else
                {
                    k++;
                }
            }
            return x;
        }
        /// <summary>
        /// Function
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static double Func(Point p) => Math.Pow(p.Y, 2) + 6 * Math.Pow(p.X, 2) + 5 * p.X + 2 * p.Y + 1;
        /// <summary>
        /// Ранг матрицы
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        static int Rang(List<Point> listMatrix)
        {
            // Конвертируем список в матрицу
            int n = listMatrix.Count - 1;
            int m = 2;
            double[,] matrix = new double[n, m];
            for (int l = 0; l < n; l++)
            {
                matrix[l, m - 2] = listMatrix[l + 1].X;
                matrix[l, m - 1] = listMatrix[l + 1].Y;
            }
            // Ищем ранг с помощью модифицированного метода Гаусса
            const double EPS = 1E-9;
            int rang = Math.Max(n, m);
            bool[] line_used = new bool[n];
            for (int i = 0; i < m; ++i)
            {
                int j;
                for (j = 0; j < n; ++j)
                    if (!line_used[j] && Math.Abs(matrix[j, i]) > EPS)
                        break;
                if (j == n)
                    --rang;
                else
                {
                    line_used[j] = true;
                    for (int p = i + 1; p < m; ++p)
                        matrix[j, p] /= matrix[j, i];
                    for (int k = 0; k < n; ++k)
                        if (k != j && Math.Abs(matrix[k, i]) > EPS)
                            for (int p = i + 1; p < m; ++p)
                                matrix[k, p] -= matrix[j, p] * matrix[k, i];
                }
            }
            return rang;
        }
        /// <summary>
        /// Метод Пауэлла
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="eps"></param>
        static void Run(Point x0, double eps = 0.01)
        {
            Point resultPoint;
            // Step 1
            int n = 2;
            List<Point> d = new List<Point>();
            d.Add(null);
            d.Add(new Point(1, 0));
            d.Add(new Point(0, 1));
            d[0] = d[n];
            List<Point> x = new List<Point>();
            x.Add(x0);
            List<Point> y = new List<Point>();
            y.Add(x[0]); // y[0] = x[0];
            int i = 0;
            int k = 0;
            while (true)
            {
                // Step 2
                y.Add(null); // y[i + 1]
                double t = 0;
                t = FindExtremum(y[i], d[i]); // Поиск параметра t методом Фибоначчи
                y[i + 1] = y[i] + t * d[i];
                // Step 3
                // a
                if (i < n - 1)
                {
                    i++;
                    continue; // goto Step 2
                }
                // b
                else if (i == n - 1)
                {
                    if (y[n] == y[0])
                    {
                        resultPoint = y[n];
                        break; // y[n]
                    }
                    else
                    {
                        i++;
                        continue; // goto Step 2
                    }
                }
                // c
                else if (i == n)
                {
                    if (y[n + 1] == y[1])
                    {
                        resultPoint = y[n + 1];
                        break; // y[n + 1]
                    }
                    // goto Step 4
                }
                // Step 4
                x.Add(null);
                x[k + 1] = y[n + 1];
                // a
                if ((x[k + 1] - x[k]).GetLength() < eps)
                {
                    resultPoint = x[k + 1];
                    break; // x[k + 1]
                }
                // b
                else
                {
                    List<Point> d_v = new List<Point>();
                    for (int j = 0; j < d.Count; j++)
                        d_v.Add(null);
                    d_v[0] = d_v[n] = y[n + 1] - y[1];
                    for (int j = 1; j < n; j++) // !!! n - 1
                        d_v[j] = d[j + 1];
                    if (Rang(d_v) == n)
                    {
                        for (int j = 0; j < d_v.Count; j++)
                            d[j] = d_v[j];
                        k++;
                        i = 0;
                        y.Clear();
                        y.Add(x[1]); //y[0] = x[1];
                        continue;  // goto Step 2
                    }
                    else
                    {
                        // d[j] = d[j]
                        k++;
                        i = 0;
                        y.Clear();
                        y.Add(x[1]); //y[0] = x[1];
                        continue;  // goto Step 2
                    }
                }
            }
            double result = Func(resultPoint);
            Console.WriteLine("Результат: {0:F10}", result);
            Console.WriteLine("Точность: {0:F10}", Math.Abs(Func(new Point(-0.4166666666, -1)) - result));
            Console.WriteLine("Количество шагов: {0}", k);
        }
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Тест 1");
            Console.WriteLine("Берем стандартные параметры");
            sw.Reset();
            sw.Start();
            Run(new Point(0, 0));
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 2");
            Console.WriteLine("Ухудшаем точность в 10 раз");
            sw.Reset();
            sw.Start();
            Run(new Point(0, 0), 0.1);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 3");
            Console.WriteLine("Улучшаем точность в 10 раз");
            sw.Reset();
            sw.Start();
            Run(new Point(0, 0), 0.001);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 4");
            Console.WriteLine("Берем другую точку");
            sw.Reset();
            sw.Start();
            Run(new Point(8, 9));
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
