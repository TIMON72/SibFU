using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Function F(x)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static double Func(double x) => 5 * Math.Pow(x, 2) + 1;
        //static double Func1(double x) => 5 * Math.Pow(x, 2) - 1;
        /// <summary>
        /// Algorithm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        static double Algorithm(double a, double b, double delta)
        {
            int k;
            double x = 0;
            double Fx = 0;
            double y = 0;
            double Fy = 0;
            double z = 0;
            double Fz = 0;
            double length = 0;
            // Step 1
            // a = a;
            // b = b;
            // delta = delta;
            // Step 2
            k = 0;
            // Step 3
            x = (a + b) / 2;
            Fx = Func(x);
            length = b - a;
            while (true)
            {
                // step 4
                Fx = Func(x);
                y = a + length / 4;
                Fy = Func(y);
                z = b - length / 4;
                Fz = Func(z);
                // Step 5
                if (Fy < Fx)
                {
                    b = x;
                    // a = a;
                    x = y;
                }
                // Step 6
                else
                {
                    if (Fz < Fx)
                    {
                        a = x;
                        // b = b;
                        x = z;
                    }
                    else
                    {
                        a = y;
                        b = z;
                        // x = x;
                    }
                }
                // Step 7
                length = Math.Abs(b - a);
                if (length <= delta)
                {
                    Console.WriteLine("Total steps: {0}", k);
                    break;
                }
                k++;
            }
            return x;
        }
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Initializing variables
            double x = 0;
            double Fx = Func(x);
            Stopwatch sw = new Stopwatch(); // Timer for algorithm's speed
            sw.Start();
            x = Algorithm(-6, 6, 0.01);
            sw.Stop();
            Console.WriteLine("a = {0}; b = {1}; delta = {2}", -6, 6, 0.01);
            Console.WriteLine("x = {0}", x);
            Console.WriteLine("F(x) = {0}", Func(x));
            Console.WriteLine("Accuracy: {0:F10}", Math.Abs(Func(0.2) - Func(x)));
            Console.WriteLine("Algorithm's speed: {0} ms", sw.ElapsedMilliseconds);
            Console.WriteLine();
            sw.Start();
            x = Algorithm(-6, 6, 0.1);
            sw.Stop();
            Console.WriteLine("a = {0}; b = {1}; delta = {2}", -6, 6, 0.1);
            Console.WriteLine("x = {0}", x);
            Console.WriteLine("F(x) = {0}", Func(x));
            Console.WriteLine("Accuracy: {0:F10}", Math.Abs(Func(0.2) - Func(x)));
            Console.WriteLine("Algorithm's speed: {0} ms", sw.ElapsedMilliseconds);
            Console.WriteLine();
            sw.Start();
            x = Algorithm(-6, 6, 0.001);
            sw.Stop();
            Console.WriteLine("a = {0}; b = {1}; delta = {2}", -6, 6, 0.001);
            Console.WriteLine("x = {0}", x);
            Console.WriteLine("F(x) = {0}", Func(x));
            Console.WriteLine("Accuracy: {0:F10}", Math.Abs(Func(0.2) - Func(x)));
            Console.WriteLine("Algorithm's speed: {0} ms", sw.ElapsedMilliseconds);
            Console.WriteLine();
            sw.Start();
            x = Algorithm(-12, -1, 0.01);
            sw.Stop();
            Console.WriteLine("a = {0}; b = {1}; delta = {2}", -12, -1, 0.01);
            Console.WriteLine("x = {0}", x);
            Console.WriteLine("F(x) = {0}", Func(x));
            //Console.WriteLine("Accuracy: {0:F10}", Math.Abs(Func(0.2) - Func(x)));
            Console.WriteLine("Algorithm's speed: {0} ms", sw.ElapsedMilliseconds);
            Console.WriteLine();
            sw.Start();
            x = Algorithm(12, 45, 0.01);
            sw.Stop();
            Console.WriteLine("a = {0}; b = {1}; delta = {2}", 12, 45, 0.01);
            Console.WriteLine("x = {0}", x);
            Console.WriteLine("F(x) = {0}", Func(x));
            //Console.WriteLine("Accuracy: {0:F10}", Math.Abs(Func(0.2) - Func(x)));
            Console.WriteLine("Algorithm's speed: {0} ms", sw.ElapsedMilliseconds);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
