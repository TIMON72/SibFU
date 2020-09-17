using System;
using System.Collections.Generic;

namespace NVersionProgram.Algorithms
{
    class FletcherReevesMethod
    {
        static Func<Point, double> Func;

        static Func<Point, double, Point, double> FuncExtremum;

        static Point GradFunc(Point p)
        {
            double dx = 0.001;
            double dy = 0.001;
            double derX = (Func(new Point(p.X + dx, p.Y)) - Func(p)) / dx;
            double derY = (Func(new Point(p.X, p.Y + dy)) - Func(p)) / dy;
            return new Point(derX, derY);
        }
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
            double x;// = 0;
            double y;// = 0;
            double Fy;// = 0;
            double z;// = 0;
            double Fz;// = 0;
            //double length;// = 0;
            int k;// = 0;
            // Step 1
            //length = b - a;
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
        /// Метод Флетчера-Ривса
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="eps"></param>
        public static Point Run(Point x0, Func<Point, double> func, Func<Point, double, Point, double> funcExtremum, 
            double eps1 = 0.1, double eps2 = 0.15, int M = 10)
        {
            Func = func;
            FuncExtremum = funcExtremum;
            List<Point> x = new List<Point>
            {
                x0
            };
            List<Point> d = new List<Point>
            {
                null
            };
            List<double> beta = new List<double>();
            List<double> t = new List<double>();
            int reiteration = 0; // для шага 11 отслеживание повторения условия для k и k - 1
            // Шаг 1
            Point gradF;// = GradFunc(x0); // ???
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
                    return x[k];
                }
                // б
                // Шаг 5
                if (k >= M)
                {
                    // а
                    return x[k];
                }
                // б
                if (k == 0)
                {
                    // Шаг 6
                    d[0] = -1 * gradF; // !!! ошибка в алгоритме - нигде не сказано о переходе на шаг 9
                }
                else
                {
                    // Шаг 7
                    beta.Add(0);
                    beta[k - 1] = Math.Pow(GradFunc(x[k]).GetLength(), 2) / Math.Pow(GradFunc(x[k - 1]).GetLength(), 2);
                    // Шаг 8
                    d.Add(null);
                    d[k] = -1 * GradFunc(x[k]) + beta[k - 1] * d[k - 1];
                }
                // Шаг 9
                t.Add(0);
                t[k] = FindExtremum(x[k], d[k]); // Поиск параметра t методом Фибоначчи

                // Шаг 10
                x.Add(null);
                x[k + 1] = x[k] + t[k] * d[k];
                // Шаг 11
                // а
                if ((x[k + 1] - x[k]).GetLength() < eps2 && Func(x[k + 1]) - Func(x[k]) < eps2)
                {
                    reiteration++;
                    if (reiteration == 2) // j - 1 тоже соответствовало данному условию
                    {
                        return x[k];
                    }
                }
                else
                {
                    k++;
                    continue;
                }
            }
        }
    }
}
