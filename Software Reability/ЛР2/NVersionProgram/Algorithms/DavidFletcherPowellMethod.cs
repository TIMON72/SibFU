using System;
using System.Collections.Generic;

namespace NVersionProgram.Algorithms
{
    class DavidFletcherPowellMethod
    {
        static Func<Point, double> Func;

        static Func<Point, double, Point, double> FuncExtremum;

        /// <summary>
        /// Градиент функции в точке
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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
            double x = 0;
            double y;// = 0;
            double Fy = 0;
            double z;// = 0;
            double Fz = 0;
            double length;// = 0;
            int k;// = 0;
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
        /// Метод Дэвидона-Флетчера-Пауэлла
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="eps"></param>
        public static Point Run(Point x0, Func<Point, double> func, Func<Point, double, Point, double> funcExtremum, 
            double eps1 = 0.1, double eps2 = 0.15, int M = 10)
        {
            Func = func;
            FuncExtremum = funcExtremum;
            int reiteration = 0;
            List<Point> x = new List<Point>
            {
                x0
            };
            List<Point> d_x = new List<Point>
            {
                null
            };
            List<Point> d_g = new List<Point>
            {
                null
            };
            List<Matrix> A = new List<Matrix>();
            List<Matrix> A_c = new List<Matrix>();
            List<Point> d = new List<Point>();
            List<double> t = new List<double>();
            // Шаг 1
            Point gradF;// = GradFunc(x0); // !!! ненужная операция
            // Шаг 2
            int k = 0;
            A.Add(new Matrix(new Point[] { new Point(1, 0), new Point(0, 1) })); // A[0]
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
                // Шаг 5
                // а
                if (k >= M)
                {
                    return x[k];
                }
                // б
                if (k != 0)
                {
                    // Шаг 6
                    d_g.Add(null);
                    d_g[k - 1] = GradFunc(x[k]) - GradFunc(x[k - 1]);
                    // Шаг 7
                    d_x.Add(null);
                    d_x[k - 1] = x[k] - x[k - 1];
                    // Шаг 8
                    Matrix m1 = Matrix.Transpose(new Matrix(d_x[k - 1])) * new Matrix(d_x[k - 1]);
                    Matrix m2 = new Matrix(d_x[k - 1]) * Matrix.Transpose(new Matrix(d_g[k - 1]));
                    Matrix m3 = A[k - 1] * Matrix.Transpose(new Matrix(d_g[k - 1])) * new Matrix(d_g[k - 1]) * A[k - 1];
                    Matrix m4 = new Matrix(d_g[k - 1]) * A[k - 1] * Matrix.Transpose(new Matrix(d_g[k - 1]));
                    Matrix m5 = m1 / m2;
                    Matrix m6 = m3 / m4;
                    Matrix m7 = m5 - m6;
                    A_c.Add(null);
                    A_c[k - 1] = m7;
                    // Шаг 9
                    A.Add(null);
                    A[k] = A[k - 1] + A_c[k - 1];
                }
                // Шаг 10
                d.Add(null);
                d[k] = -1 * A[k] * gradF;
                // Шаг 11
                t.Add(0);
                t[k] = FindExtremum(x[k], d[k]); // !!! не сказано, что подставлять d[k]
                // Шаг 12
                x.Add(null);
                x[k + 1] = x[k] + t[k] * d[k]; // !!! тут тоже можно заменить на d[k]
                // Шаг 13
                // а
                if ((x[k + 1] - x[k]).GetLength() < eps2 && Math.Abs(Func(x[k + 1]) - Func(x[k])) < eps2)
                {
                    reiteration++;
                    if (reiteration == 2) // j - 1 тоже соответствовало данному условию
                    {
                        return x[k];
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
    }
}
