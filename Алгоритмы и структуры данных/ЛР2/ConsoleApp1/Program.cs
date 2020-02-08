using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static Stopwatch sw = new Stopwatch();
        /// <summary>
        /// Ф-ция вычисления среднего арифметического числового массива
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static float ArithmeticalMean(int[] arr)
        {
            int sum = 0;
            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                sum += arr[i];
            }
            float arrAM = (float)sum / size;
            return arrAM;
        }
        /// <summary>
        /// Ф-ция вычисления медианы числового массива
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static float Median(int[] arr)
        {
            Array.Sort(arr);
            float average = (float)arr.Sum() / 2;
            int size = arr.Length;
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += arr[i];
                if (sum >= average)
                {
                    if (size % 2 != 0)
                        return arr[i - 1];
                    else
                        return (float)(arr[i - 1] + arr[i - 2]) / 2;
                }
            }
            return -1;
        }
        /// <summary>
        /// Ф-ция поиска k-ой порядковой статистики
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        static int SearchOrderStatistic(int[] arr, int k, int l, int r)
        {
            int i = l;
            int j = r;
            int s, m, tmp;
            if (l == r)
                return arr[r];
            s = (l + r) / 2;
            m = arr[s];
            while (i < j)
            {
                while (arr[i] < m)
                    i++;
                while (arr[j] > m)
                    j--;
                if (i < j)
                {
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                }
            }
            if (k <= j)
                return SearchOrderStatistic(arr, k, l, j);
            else
                return SearchOrderStatistic(arr, k, j + 1, r);
        }
        /// <summary>
        /// Главная ф-ция
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            FileStream file = new FileStream("./files/array.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string text;
            string[] arrString;
            int[] arrInt;
            bool inspection = false;
            while (!reader.EndOfStream)
            {
                text = reader.ReadLine();
                arrString = text.Split(' ');
                arrInt = new int[arrString.Length];
                Console.Write("Массив: ");
                for (int i = 0; i < arrString.Length; i++)
                {
                    arrInt[i] = Convert.ToInt16(arrString[i]);
                    Console.Write(arrInt[i] + " ");
                }
                Console.WriteLine();
                sw.Start();
                Console.WriteLine("Среднее арифметическое: " + ArithmeticalMean(arrInt));
                sw.Stop();
                Console.WriteLine("Скорость алгоритма поиска среднего арифметического: " + 
                    sw.ElapsedMilliseconds + " ms");
                sw.Restart();
                Console.WriteLine("Медиана: " + Median(arrInt));
                sw.Stop();
                Console.WriteLine("Скорость алгоритма поиска медианы: " +
                    sw.ElapsedMilliseconds + " ms");
                Console.WriteLine();
            }
            Console.Write("Введите массив: ");
            text = Console.ReadLine();
            arrString = text.Split(' ');
            arrInt = new int[arrString.Length];
            for (int i = 0; i < arrString.Length; i++)
            {
                inspection = false;
                while (!inspection)
                {
                    try
                    {
                        arrInt[i] = Convert.ToInt16(arrString[i]);
                        inspection = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Введите число!");
                        break;
                    }
                }
                Console.Write(arrInt[i] + " ");
            }
            int k = 0;
            while (!inspection)
            {
                try
                {
                    Console.Write("Введите k для поиска k-ой порядковой статистики: ");
                    k = Convert.ToInt16(Console.ReadLine());
                    inspection = true;
                    if (k < 0 || k >= arrInt.Length)
                    {
                        Console.WriteLine("Введите k >= 0 или k < размера массива");
                        inspection = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число!");
                }
            }
            sw.Restart();
            int result = SearchOrderStatistic(arrInt, k, 0, arrInt.Length - 1);
            sw.Stop();
            Console.WriteLine("Элемент k-ой порядковой статистики: {0}", result);
            Console.WriteLine("Скорость алгоритма поиска k-ой порядковой статистики: " +
                sw.ElapsedMilliseconds + " ms");
            Console.ReadKey();
        }
    }
}
