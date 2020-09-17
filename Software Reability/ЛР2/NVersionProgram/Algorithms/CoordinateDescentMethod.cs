using System;
using System.Collections.Generic;

namespace NVersionProgram.Algorithms
{
    class CoordinateDescentMethod
    {
        static Func<Point, double> Func;

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
        /// Метод покоординатного спуска
        /// </summary>
        /// <param name="x0"></param>
        /// <param name="eps"></param>
        public static Point Run(Point x00, Func<Point, double> func, double eps1 = 0.1, double eps2 = 0.15, int M = 10)
        {
            Func = func;
            // !!! Параметр eps = 0 не нужен в алгоритме
            int reiteration = 0; // для шага 11 отслеживание повторения условия для j и j - 1
            int steps = 0;
            // Шаг 1
            int n = 2;
            if (M % n == 1)
            {
                Console.WriteLine("Вы вабрали M не кратное n");
                return null;
            }
            List<List<Point>> x = new List<List<Point>>
            {
                new List<Point>(n + 1)
            };
            x[0].Add(x00); //x[0,0] = x00
            Point gradF;// = GradFunc(x[0][0]);
            // Шаг 2
            int j = 0;
            int k;// = 0; // k <= n - 1
            List<Point> e = new List<Point> { null, new Point(1, 0), new Point(0, 1) };
            List<double> t = new List<double>();
        // Шаг 3
        step3:
            if (j >= M)
            {
                return x[j][0];
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
                return x[j][k];
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
                }
                else if (k + 1 == n) // dF(p)/dy
                {
                    double dy = 0.001;
                    der = (Func(new Point(x[j][k].X, x[j][k].Y + dy)) - Func(x[j][k])) / dy;
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
                    return x[j][k + 1];
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
    }
}
