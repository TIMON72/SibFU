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
        /// Метод Марквардта
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="eps"></param>
        static void Run(Point x0, double eps1 = 0.1, int M = 10)
        {
            List<Point> x = new List<Point>();
            x.Add(x0);
            List<double> mu = new List<double>();
            mu.Add(20);
            Matrix E = new Matrix(new Point[] { new Point (1, 0), new Point (0, 1) });
            List<Point> d = new List<Point>();
            List<double> t = new List<double>();
            // Шаг 1
            Point gradF = GradFunc(x0); // !!! ненужная операция
            Matrix H = Create_H(x0); // !!! ненужная операция
            // Шаг 2
            int k = 0;
            mu[k] = mu[0];
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
                step7:
                Matrix X = H + mu[k] * E;
                // Шаг 8
                X = Matrix.Inverse(X);
                // Шаг 9
                d.Add(null);
                d[k] = -1 * X * gradF;
                // Шаг 10
                x.Add(null);
                x[k + 1] = x[k] + d[k]; //!!! можно было и так записать вместо того, что предлагает алгоритм
                // Шаг 11
                if (Func(x[k + 1]) < Func(x[k]))
                {
                    // а
                    // Шаг 12
                    mu.Add(0);
                    mu[k + 1] = mu[k] / 2; //!!! в алгоритме увеличивают k и затем пишут mu[k+1], а нужно
                    // увеличить k в конце
                    k++;
                    // goto Шаг 3
                }
                else
                {
                    // б
                    // Шаг 13
                    mu[k] = 2 * mu[k];
                    goto step7;
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
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 4");
            Console.WriteLine("Уменьшим M");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0.1, 4);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 5");
            Console.WriteLine("Увеличим M");
            sw.Reset();
            sw.Start();
            Run(new Point(10, 10), 0.1, 20);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
