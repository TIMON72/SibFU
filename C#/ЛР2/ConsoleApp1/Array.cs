using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Array
    {
        int[] array; // Поле массив
        // Св-во со значением размера массива
        public int ArraySize
        {
            get
            {
                return array.Length;
            }
            private set
            { }
        }

        public Array(int n)
        {
            array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = (i + 1) * (i + 1);
            }
        }

        public Array(int n, string fileName)
        {
            string path = fileName + ".txt";
            FileStream file;
            try
            {
                file = new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException)
            {
                return;
            }
            file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file); // Потоковое чтение файла
            while (!reader.EndOfStream)
            {
                string buf; // Буферная переменная для считываемой строки
                buf = reader.ReadLine();
                string[] bufArr = buf.Split(' '); // Создаем буферный массив с разбиением на эл-ты по пробелу
                // Если переданное кол-во элементов больше, чем их есть в файле, то считываем все элементы файла
                if (n > bufArr.Length)
                {
                    n = bufArr.Length;
                }
                array = new int[n];
                // Заполняем массив считанными данными
                for (int i = 0; i < n; i++)
                {
                    array[i] = Convert.ToInt32(bufArr[i]);
                }
            }
            reader.Close();
        }

        public int Calculate()
        {
            int maxPos = 0;
            int minPos = array.Length - 1;
            int result = 1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i + 1] >= array[maxPos])
                {
                    maxPos = i + 1;
                }
                if (array[i + 1] <= array[minPos])
                {
                    minPos = i + 1;
                }
            }
            if (minPos > maxPos)
            {
                for (int j = maxPos + 1; j < minPos; j++)
                {
                    result = result * array[j];
                }
            }
            else
            {
                for (int j = minPos + 1; j < maxPos; j++)
                {
                    result = result * array[j];
                }
            }
            return result;
        }
    }
}
