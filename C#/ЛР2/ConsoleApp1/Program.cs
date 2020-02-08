using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Console.Write("Введите размер массива: ");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Write("Введено не число");
                Console.ReadKey();
                return;
            }
            Array array = new Array(n);
            Console.WriteLine("Размер массива: " + array.ArraySize);
            Console.Write("Введите имя файла: ");
            string fileName = Console.ReadLine();
            array = new Array(n, fileName);
            try
            {
                Console.WriteLine("Размер массива: " + array.ArraySize);
            }
            catch (NullReferenceException)
            {
                Console.Write("Ошибка имени файла");
                Console.ReadKey();
                return;
            }
            int result = array.Calculate();
            Console.WriteLine("Результат произведения между минимальным и максимальным элементом: " + result.ToString());
            Console.ReadKey();
        }
    }
}
