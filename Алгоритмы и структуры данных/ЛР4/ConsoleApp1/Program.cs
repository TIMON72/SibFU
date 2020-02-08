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
        static int counterOfReshuffles = 0;
        static int counterOfСomparisons = 0;

        /// <summary>
        /// Ф-ция отображения массива на консоль
        /// </summary>
        /// <param name="arr"></param>
        static void ShowArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
        /// <summary>
        /// Ф-ция шшейкерной сортировки
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] ShakerSort(int[] arr)
        {
            int left = 0; // левая граница
            int right = arr.Length - 1; // правая граница
            do
            {
                //Сдвигаем к концу массива "тяжелые элементы"
                for (int i = left; i < right; i++)
                {
                    counterOfСomparisons++;
                    if (arr[i] > arr[i + 1])
                    {
                        arr[i] ^= arr[i + 1];
                        arr[i + 1] ^= arr[i];
                        arr[i] ^= arr[i + 1];
                        counterOfReshuffles++;
                    }
                }
                right--; // уменьшаем правую границу
                //Сдвигаем к началу массива "легкие элементы"
                for (int i = right; i > left; i--)
                {
                    counterOfСomparisons++;
                    if (arr[i] < arr[i - 1])
                    {
                        arr[i] ^= arr[i - 1];
                        arr[i - 1] ^= arr[i];
                        arr[i] ^= arr[i - 1];
                        counterOfReshuffles++;
                    }
                }
                left++; // увеличиваем левую границу
            } while (left <= right);
            return arr;
        }
        /// <summary>
        /// Ф-ция быстрой сортировки
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        static int[] QuickSort(int[] arr, int left, int right)
        {
            int temp;
            int x = arr[left + (right - left) / 2]; //запись эквивалентна (left+right)/2, но не вызввает переполнения на больших данных
            int i = left;
            int j = right;
            while (i <= j)
            {
                while (arr[i] < x)
                {
                    i++;
                    counterOfСomparisons++;
                }
                while (arr[j] > x)
                {
                    j--;
                    counterOfСomparisons++;
                }
                counterOfСomparisons++;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                    counterOfReshuffles++;
                }
            }
            counterOfСomparisons++;
            if (i < right)
                QuickSort(arr, i, right);
            counterOfСomparisons++;
            if (left < j)
                QuickSort(arr, left, j);
            return arr;
        }
        /// <summary>
        /// Главная ф-ция
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            FileStream file = new FileStream("./files/array.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            while (!reader.EndOfStream)
            {
                string text = reader.ReadLine();
                string[] arrString = text.Split(' ');
                int[] arrInt = new int[arrString.Length];
                Console.Write("Массив: ");
                for (int i = 0; i < arrString.Length; i++)
                {
                    arrInt[i] = Convert.ToInt16(arrString[i]);
                    Console.Write(arrInt[i] + " ");
                }
                Console.WriteLine();
                counterOfReshuffles = 0;
                counterOfСomparisons = 0;
                int[] sortedArrInt;
                Array.Copy(arrInt, sortedArrInt = new int[arrInt.Length], arrInt.Length);
                sw.Restart();
                sortedArrInt = ShakerSort(sortedArrInt);
                sw.Stop();
                Console.Write("Шейкерная сортировка: ");
                ShowArray(sortedArrInt);
                Console.WriteLine();
                Console.WriteLine("Скорость алгоритма: " +
                    sw.ElapsedMilliseconds + " ms");
                Console.WriteLine("Количество перестановок: " +
                    counterOfReshuffles);
                Console.WriteLine("Количество сравнений: " +
                    counterOfСomparisons);
                counterOfReshuffles = 0;
                counterOfСomparisons = 0;
                Array.Copy(arrInt, sortedArrInt = new int[arrInt.Length], arrInt.Length);
                sw.Restart();
                sortedArrInt = QuickSort(sortedArrInt, 0, sortedArrInt.Length - 1);
                sw.Stop();
                Console.Write("Быстрая сортировка: ");
                ShowArray(sortedArrInt);
                Console.WriteLine();
                Console.WriteLine("Скорость алгоритма: " +
                    sw.ElapsedMilliseconds + " ms");
                Console.WriteLine("Количество перестановок: " +
                    counterOfReshuffles);
                Console.WriteLine("Количество сравнений: " +
                    counterOfСomparisons);
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
