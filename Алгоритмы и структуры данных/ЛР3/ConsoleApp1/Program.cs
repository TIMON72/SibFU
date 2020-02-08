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
        /// Ф-ция сортировки прямым выбором
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] DirectSelectionSort(int[] arr)
        {
            int pos = 0;
            do
            {
                int min = pos;
                for (int i = pos + 1; i < arr.Length; i++)
                {
                    counterOfСomparisons++;
                    if (arr[i] < arr[min])
                    {
                        min = i;
                    }
                }
                if (arr[pos] != arr[min])
                {
                    int temp = arr[pos];
                    arr[pos] = arr[min];
                    arr[min] = temp;
                    counterOfReshuffles++;
                }
                pos++;
            } while (pos != arr.Length - 1);
            return arr;
        }
        /// <summary>
        /// Ф-ция пузырьковой сортировки
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    counterOfСomparisons++;
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                        counterOfReshuffles++;
                    }
                }
            }
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
                sortedArrInt = DirectSelectionSort(sortedArrInt);
                sw.Stop();
                Console.Write("Сортировка прямым выбором: ");
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
                sortedArrInt = BubbleSort(sortedArrInt);
                sw.Stop();
                Console.Write("Пузырьковая сортировка: ");
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
