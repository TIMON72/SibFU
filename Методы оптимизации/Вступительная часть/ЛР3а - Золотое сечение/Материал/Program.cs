using System;
using System.Linq.Expressions;

namespace ConsoleApp1
{
    class Program
    {
        static Tuple<double, int> Bisection(double l, double a0, double b0, Func<double, double> F)
        {
            int k = 0;
            double a = 0;
            double b = 0;
            double x = 0;
            double y = 0;
            double z = 0;
            double L = 0;
            // Step 1
            a = a0;
            b = b0;
            // Step 2
            k = 0;
            // Step 3
            x = (a + b) / 2;
            L = b - a;
            do
            {
                // step 4
                y = a + L / 4;
                z = b - L / 4;
                // Step 5
                if (F(y) < F(x))
                {
                    b = x;
                    x = y;
                }
                // Step 6
                else if (F(z) < F(x))
                {
                    a = x;
                    x = z;
                }
                else
                {
                    a = y;
                    b = z;
                }
                // Step 7
                L = Math.Abs(b - a);
                k++;
            } while (L > l);
            return new Tuple<double, int>(x, --k);
        }
        static void Main(string[] args)
        {
            Expression<Func<double, double>> E = x => 5 * Math.Pow(x, 2) - 2 * x + 1;
            Func<double, double> F = E.Compile();
            Tuple<double, int> result = Bisection(0.01, -6, 6, F);
            Console.WriteLine(
                "Minimum of {0} on interval [{1},{2}] with eps {3} is {4} calculated by {5} steps.",
                E.ToString(),
                (-6).ToString(), (6).ToString(), (0.01).ToString(), result.Item1.ToString(), result.Item2.ToString()
            );
        }
    }
}
