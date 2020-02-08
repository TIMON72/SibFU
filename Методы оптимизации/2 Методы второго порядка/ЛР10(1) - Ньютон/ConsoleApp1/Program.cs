using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Функция
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static double Func(Point p) => Math.Pow(p.Y, 2) + 6 * Math.Pow(p.X, 2) + 5 * p.X + 2 * p.Y + 1;
            //2 * Math.Pow(p.X, 2) + p.X * p.Y + Math.Pow(p.Y, 2);
        /// <summary>
        /// Первая производная F'x
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static double Derrivate_dx(Point p)
        {
            double dx = 0.001;
            return (Func(new Point(p.X + dx, p.Y)) - Func(p)) / dx;
        }
        /// <summary>
        /// Первая производная F'y
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static double Derrivate_dy(Point p)
        {
            double dy = 0.001;
            return (Func(new Point(p.X, p.Y + dy)) - Func(p)) / dy;
        }
        /// <summary>
        /// Вторая производная F''x
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static double Derrivate2_dxdx(Point p)
        {
            double dx = 0.001;
            return (Derrivate_dx(new Point(p.X + dx, p.Y)) - Derrivate_dx(p)) / dx;
        }
        /// <summary>
        /// Смешанная производная F''xy
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static double Derrivate2_dxdy(Point p)
        {
            double dx = 0.001;
            return (Derrivate_dy(new Point(p.X + dx, p.Y)) - Derrivate_dy(p)) / dx;
        }
        /// <summary>
        /// Вторая производная F''y
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static double Derrivate2_dydy(Point p)
        {
            double dy = 0.001;
            return (Derrivate_dy(new Point(p.X, p.Y + dy)) - Derrivate_dy(p)) / dy;
        }
        /// <summary>
        /// Смешанная производная F''yx
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static double Derrivate2_dydx(Point p)
        {
            double dy = 0.001;
            return (Derrivate_dx(new Point(p.X, p.Y + dy)) - Derrivate_dx(p)) / dy;
        }
        /// <summary>
        /// Создать матрицу Гессе
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static Matrix Create_H(Point p)
        {
            Matrix m = new Matrix();
            m.Element[0, 0] = Derrivate2_dxdx(p);
            m.Element[0, 1] = Derrivate2_dxdy(p);
            m.Element[1, 0] = Derrivate2_dydx(p);
            m.Element[1, 1] = Derrivate2_dydy(p);
            return m;
        }
        /// <summary>
        /// Градиент функции в точке
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        static Point GradFunc(Point p)
        {
            double derX = Derrivate_dx(p);
            double derY = Derrivate_dy(p);
            return new Point(derX, derY);
        }
        /// <summary>
        /// Функция для поиска экстремума
        /// </summary>
        /// <param name="p"></param>
        /// <param name="t"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        static double FuncExtremum(Point p, double t, Point d) => Math.Pow(p.Y + t * d.Y, 2) + 
            6 * Math.Pow(p.X + t * d.X, 2) + 5 * (p.X + t * d.X) + 2 * (p.Y + t * d.Y) + 1;
            //2 * Math.Pow(p.X + t * d.X, 2) + (p.X + t * d.X) * (p.Y + t * d.Y) + Math.Pow(p.Y + t * d.Y, 2);
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
            double eps = 0.001;
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
        /// Вывести результат в консоль
        /// </summary>
        /// <param name="resultPoint"></param>
        /// <param name="steps"></param>
        static void PrintResult(Point resultPoint, int steps)
        {
            double result = Func(resultPoint);
            Console.WriteLine("X = " + resultPoint.X + "; Y = " + resultPoint.Y);
            Console.WriteLine("F(x,y) = {0:F10}", result);
            Console.WriteLine("Точность: {0:F10}", Math.Abs(Func(new Point(-0.4164, -1)) - result));
            Console.WriteLine("Количество шагов: {0}", steps);
        }
        /// <summary>
        /// Метод Ньютона
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="eps"></param>
        static void Run(Point x0, double eps1 = 0.1, double eps2 = 0.15, int M = 10)
        {
            int reiteration = 0;
            List<Point> x = new List<Point>();
            x.Add(x0);
            List<Point> d = new List<Point>();
            List<double> t = new List<double>();
            // Шаг 1
            Point gradF = GradFunc(x0); // !!! ненужная операция
            Matrix H = Create_H(x0); // !!! ненужная операция
            // Шаг 2
            int k = 0;
            while (true)
            {
                // Шаг 3
                gradF = GradFunc(x[k]);
                // Шаг 4
                if (gradF.GetLength() < eps1)
                {
                    // а
                    PrintResult(x[k], k);
                    return;
                }
                // б
                // Шаг 5
                // а
                if (k >= M)
                {
                    PrintResult(x[k], k);
                    return;
                }
                // б
                // Шаг 6
                H = Create_H(x[k]);
                // Шаг 7
                H = Matrix.Inverse(H);
                // Шаг 8
                double delta1 = Matrix.Determinant(new Matrix(H.Element[0, 0]));
                double delta2 = Matrix.Determinant(H);
                if (delta1 > 0 && delta2 > 0)
                {
                    // а
                    // Шаг 9
                    d.Add(null);
                    d[k] = -1 * H * gradF;
                    t.Add(0);
                    t[k] = 1;
                }
                else
                {
                    // б
                    d.Add(null);
                    d[k] = -1 * gradF;
                    t.Add(0);
                    t[k] = FindExtremum(x[k], d[k]); // !!! непонятная инструкция для t[k]
                }
                // Шаг 10
                x.Add(null);
                x[k + 1] = x[k] + t[k] * d[k];
                // Шаг 11
                // а
                if ((x[k + 1] - x[k]).GetLength() < eps2 && Math.Abs(Func(x[k + 1]) - Func(x[k])) < eps2)
                {
                    reiteration++;
                    if (reiteration == 2) // j - 1 тоже соответствовало данному условию
                    {
                        PrintResult(x[k + 1], k);
                        return;
                    }
                }
                // б
                else
                {
                    reiteration = 0;
                    k++;
                    continue;
                }
            }
        }
        /// <summary>
        /// Главная функция
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            //Console.WriteLine("Тест 0");
            //Console.WriteLine("Берем стандартные параметры");
            //sw.Reset();
            //sw.Start();
            //Run(new Point(0.5, 1));
            //sw.Stop();
            Console.WriteLine("Тест 1");
            Console.WriteLine("Берем стандартные параметры");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10));
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 2");
            Console.WriteLine("Увеличим eps1");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0.5);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 3");
            Console.WriteLine("Уменьшим eps1");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0.01);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 4");
            Console.WriteLine("Увеличим eps2");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0.1, 0.5);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 5");
            Console.WriteLine("Уменьшим eps2");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0.1, 0.01);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 6");
            Console.WriteLine("Уменьшим M");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0.1, 0.15, 4);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 7");
            Console.WriteLine("Увеличим M");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0.1, 0.15, 20);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
