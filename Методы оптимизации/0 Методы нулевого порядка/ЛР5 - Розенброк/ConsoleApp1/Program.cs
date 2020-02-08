using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Function
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        static double Func(Point p) => Math.Pow(p.Y, 2) + 6 * Math.Pow(p.X, 2) + 5 * p.X + 2 * p.Y + 1;

        static double Run(Point x, double eps = 0.01, double alpha = 2, double beta = -0.5)
        {
            // Step 1
            int N = 3; // Макс. число неудачных шагов
            int k = 0; // Счетчик шагов
            int i = 0; // i-ое направление
            Point[] d = { new Point(1, 0), new Point(0, 1) };  // Векторы направлений
            double[] delta = { 1, 2 }; // Длина шага
            int n = delta.Length - 1; // Количество направлений (n = размер массива векторов, если начинать отсчет с 1)
            int size = n + 1; // Размер всех массивов в данном пространстве
            Point[] y = new Point[size + 1]; // Точки смещения
            y[0] = x; // Начальная точка смещения (совпадает с начальной точкой)
            Point x_next = x; // Следующая точка
            step2:
            while (true)
            {
                // Step 2
                // a
                if (Func(y[i] + d[i] * delta[i]) < Func(y[i]))
                {
                    y[i + 1] = y[i] + d[i] * delta[i];
                    delta[i] = delta[i] * alpha;
                }
                // b
                else
                {
                    y[i + 1] = y[i];
                    delta[i] = delta[i] * beta;
                }
                // Step 3
                // a
                if (i < n)
                {
                    i++;
                    continue;  // Переход к Step 2
                }
                // b
                else //if (i == n)
                {
                    // b.1
                    if (Func(y[n + 1]) < Func(y[0]))
                    {
                        y[0] = y[n + 1];
                        i = 0;
                        continue;  // Переход к Step 2
                    }
                    // b.2
                    else
                    {
                        // b.2.1
                        int l = 0; // Счетчик неудачных шагов
                        if (Func(y[n + 1]) < Func(x))
                        {
                            l = 0;
                            break;  // Переход к Step 4
                        }
                        // b.2.2
                        else
                        {
                            l++;
                            if (l < N)
                            {
                                bool end = true;
                                for (int j = 0; j < size; j++)
                                {
                                    if (Math.Abs(delta[j]) > eps)
                                    {
                                        y[0] = y[n + 1];
                                        i = 0;
                                        end = false;
                                        break;
                                    }
                                }
                                if (end)
                                {
                                    double result = Func(x);
                                    Console.WriteLine("Результат: {0}", result);
                                    Console.WriteLine("Точность: {0:F10}", Math.Abs(Func(new Point(-0.4166666666, -1)) - result));
                                    Console.WriteLine("Количество шагов: {0}", k);
                                    return result;
                                }
                                else
                                    continue;  // Переход к Step 2
                            }
                            else
                            {
                                break; // Переход к Step 4
                            }
                        }
                    }
                }
            }
            // Step 4
            x_next = y[n + 1];
            // a
            if ((x_next - x).GetLength() <= eps) // || x[k+1] - x[x] || <= eps
            {
                x = x_next;
                double result = Func(x);
                Console.WriteLine("Результат: {0}", result);
                Console.WriteLine("Точность: {0:F10}", Math.Abs(Func(new Point(-0.4166666666, -1)) - result));
                Console.WriteLine("Количество шагов: {0}", k);
                return result;
            }
            // b
            else
            {
                double[] lambda = new double[size];
                for (int j = 0; j < size; j++)
                {
                    lambda[j] = (x_next - x) * d[j];
                }
                Point[] a = new Point[size];
                for (int j = 0; j < size; j++)
                {
                    Point sum = lambda[j] * d[j];
                    for (int m = j + 1; m < size; m++)
                    {
                        sum +=lambda[m] * d[m];
                    }
                    a[j] = sum;
                }
                Point[] b = new Point[size];
                Point[] d_v = new Point[size];
                b[0] = a[0];
                d_v[0] = b[0] / b[0].GetLength();
                for (int j = 1; j < size; j++)
                {
                    Point sum = a[j] * d_v[0] * d_v[0];
                    for (int m = 1; m < size - 1; m++)
                    {
                        sum += a[j] * d_v[m] * d_v[m];
                    }
                    b[j] = a[j] - sum;
                    d_v[j] = b[j] / b[j].GetLength();
                }
                for (int j = 0; j < size; j++)
                {
                    d[j] = d_v[j];
                }
                delta = new double[] { 1, 2 };
                k++;
                x = y[0];
                i = 0;
                goto step2; // Переход на шаг 2
            }
        }
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch(); // Timer for algorithm's speed
            Console.WriteLine("Тест 1");
            Console.WriteLine("Берем стандартные параметры");
            sw.Reset();
            sw.Start();
            Run(new Point(0, 0));
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 2");
            Console.WriteLine("Уменьшаем точность");
            sw.Reset();
            sw.Start();
            Run(new Point(0, 0), 0.001);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 3");
            Console.WriteLine("Увеличиваем точность");
            sw.Reset();
            sw.Start();
            Run(new Point(0, 0), 0.1);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 4");
            Console.WriteLine("Увеличиваем коэффициент растяжения");
            sw.Reset();
            sw.Start();
            Run(new Point(0, 0), 0.01, 3);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 5");
            Console.WriteLine("Уменьшаем коэффициент растяжения");
            sw.Reset();
            sw.Start();
            Run(new Point(0, 0), 0.01, 1.1);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 6");
            Console.WriteLine("Увеличиваем коэффициент сжатия");
            sw.Reset();
            sw.Start();
            Run(new Point(0, 0), 0.01, 2, -0.1);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.WriteLine("Тест 7");
            Console.WriteLine("Уменьшаем коэффициент сжатия");
            sw.Reset();
            sw.Start();
            Run(new Point(0, 0), 0.01, 2, -0.9);
            sw.Stop();
            Console.WriteLine("Скорость алгоритма: {0} ms\n", sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
