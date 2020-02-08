using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Посимвольное считывание из файла и возврат символа типа string
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        static string ReadElement(StreamReader r)
        {
            string element = "";
            while (true)
            {
                char ch = (char)r.Read();
                if (ch == ' ' || ch == '\r')
                {
                    if (element == "")
                        return "\n";
                    return element;
                }
                else if (ch == '\n' || ch == '\uffff')
                {
                    return "\n";
                }
                else
                {
                    element = element + Convert.ToString(ch);
                }
            }
        }
        /// <summary>
        /// Разбиение файла на три
        /// </summary>
        static void Start()
        {
            FileStream f = new FileStream("./files/f.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamWriter w = new StreamWriter(f);
            StreamReader r = new StreamReader(f);
            int counter = 1;
            int elem = Convert.ToInt32(ReadElement(r));
            while (true)
            {
                if (counter == 1 || counter > 3)
                {
                    FileStream f1 = new FileStream("./files/f1.txt", FileMode.Append, FileAccess.Write);
                    w = new StreamWriter(f1);
                    counter = 1;
                }
                else if (counter == 2)
                {
                    FileStream f2 = new FileStream("./files/f2.txt", FileMode.Append, FileAccess.Write);
                    w = new StreamWriter(f2);
                }
                else if (counter == 3)
                {
                    FileStream f3 = new FileStream("./files/f3.txt", FileMode.Append, FileAccess.Write);
                    w = new StreamWriter(f3);
                }
                string elemNextStr = ReadElement(r);
                if (elemNextStr == "\n")
                {
                    w.WriteLine(elem);
                    w.Close();
                    break;
                }
                int elemNext = Convert.ToInt32(elemNextStr);
                if (elem <= elemNext)
                {
                    w.Write(elem + " ");
                    elem = elemNext;
                    w.Close();
                }
                else
                {
                    w.WriteLine(elem);
                    elem = elemNext;
                    w.Close();
                    counter++;
                }
            }
            f.Close();
        }
        /// <summary>
        /// Проход по файлам и перераспределение значений
        /// </summary>
        /// <param name="inversion"></param>
        static void Distribution(bool inversion)
        {
            string inFileName1 = "f1.txt";
            string inFileName2 = "f2.txt";
            string inFileName3 = "f3.txt";
            string outFileName1 = "f4.txt";
            string outFileName2 = "f5.txt";
            string outFileName3 = "f6.txt";
            if (inversion)
            {
                inFileName1 = "f4.txt";
                inFileName2 = "f5.txt";
                inFileName3 = "f6.txt";
                outFileName1 = "f1.txt";
                outFileName2 = "f2.txt";
                outFileName3 = "f3.txt";
            }
            File.Delete("./files/" + outFileName1);
            File.Delete("./files/" + outFileName2);
            File.Delete("./files/" + outFileName3);
            FileStream f = new FileStream("./files/f.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamWriter w = new StreamWriter(f);
            f.Close();
            FileStream inFile1 = new FileStream("./files/" + inFileName1, FileMode.OpenOrCreate, FileAccess.Read);
            FileStream inFile2 = new FileStream("./files/" + inFileName2, FileMode.OpenOrCreate, FileAccess.Read);
            FileStream inFile3 = new FileStream("./files/" + inFileName3, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader r1 = new StreamReader(inFile1);
            StreamReader r2 = new StreamReader(inFile2);
            StreamReader r3 = new StreamReader(inFile3);
            int counter = 1;
            while (!(r1.EndOfStream && r2.EndOfStream && r3.EndOfStream))
            {
                if (counter == 1 || counter > 3)
                {
                    FileStream outFile1 = new FileStream("./files/" + outFileName1, FileMode.Append, FileAccess.Write);
                    w = new StreamWriter(outFile1);
                    counter = 1;
                }
                else if (counter == 2)
                {
                    FileStream outFile2 = new FileStream("./files/" + outFileName2, FileMode.Append, FileAccess.Write);
                    w = new StreamWriter(outFile2);
                }
                else if (counter == 3)
                {
                    FileStream outFile3 = new FileStream("./files/" + outFileName3, FileMode.Append, FileAccess.Write);
                    w = new StreamWriter(outFile3);
                }
                string elemStr1 = ReadElement(r1);
                int elem1 = 0;
                string elemStr2 = ReadElement(r2);
                int elem2 = 0;
                string elemStr3 = ReadElement(r3);
                int elem3 = 0;
                while (true)
                {
                    if (elemStr1 == "\n" && elemStr2 == "\n" && elemStr3 == "\n")
                    {
                        w.Close();
                        counter++;
                        break;
                    }
                    if (elemStr1 == "\n")
                    {
                        elem1 = Int32.MaxValue;
                    }
                    else
                    {
                        elem1 = Convert.ToInt32(elemStr1);
                    }
                    if (elemStr2 == "\n")
                    {
                        elem2 = Int32.MaxValue;
                    }
                    else
                    {
                        elem2 = Convert.ToInt32(elemStr2);
                    }
                    if (elemStr3 == "\n")
                    {
                        elem3 = Int32.MaxValue;
                    }
                    else
                    {
                        elem3 = Convert.ToInt32(elemStr3);
                    }
                    if (elem1 <= elem2 && elem1 <= elem3)
                    {
                        w.Write(elem1);
                        elemStr1 = ReadElement(r1);
                        if (elemStr1 == "\n" && elemStr2 == "\n" && elemStr3 == "\n")
                            w.WriteLine();
                        else
                            w.Write(" ");
                    }
                    else if (elem2 <= elem1 && elem2 <= elem3)
                    {
                        w.Write(elem2);
                        elemStr2 = ReadElement(r2);
                        if (elemStr1 == "\n" && elemStr2 == "\n" && elemStr3 == "\n")
                            w.WriteLine();
                        else
                            w.Write(" ");
                    }
                    else if (elem3 <= elem2 && elem3 <= elem1)
                    {
                        w.Write(elem3);
                        elemStr3 = ReadElement(r3);
                        if (elemStr1 == "\n" && elemStr2 == "\n" && elemStr3 == "\n")
                            w.WriteLine();
                        else
                            w.Write(" ");
                    }
                }
            }
            inFile1.Close();
            inFile2.Close();
            inFile3.Close();
            File.Delete("./files/" + inFileName1);
            File.Delete("./files/" + inFileName2);
            File.Delete("./files/" + inFileName3);
        }
        /// <summary>
        /// Главная функция
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            File.Delete("./files/f1.txt");
            File.Delete("./files/f2.txt");
            File.Delete("./files/f3.txt");
            Start();
            Console.WriteLine("Первый этап - распределение исходного массива по трем файлам");
            Console.WriteLine("f1:");
            foreach (var str in File.ReadAllLines("./files/f1.txt"))
                Console.WriteLine(str);
            Console.WriteLine("f2:");
            foreach (var str in File.ReadAllLines("./files/f2.txt"))
                Console.WriteLine(str);
            Console.WriteLine("f3:");
            foreach (var str in File.ReadAllLines("./files/f3.txt"))
                Console.WriteLine(str);
            Console.WriteLine("Второй этап - сортировка по трем файлам до ее завершения");
            int counter = 0;
            int numberOfFiles = 0;
            do
            {
                counter++;
                Console.WriteLine("Проход " + counter + ":");
                if (counter % 2 == 1)
                {
                    Distribution(false);
                    if (File.Exists("./files/f4.txt"))
                    {
                        Console.WriteLine("f4:");
                        foreach (var str in File.ReadAllLines("./files/f4.txt"))
                            Console.WriteLine(str);
                    }
                    if (File.Exists("./files/f5.txt"))
                    {
                        Console.WriteLine("f5:");
                        foreach (var str in File.ReadAllLines("./files/f5.txt"))
                            Console.WriteLine(str);
                    }
                    if (File.Exists("./files/f6.txt"))
                    {
                        Console.WriteLine("f6:");
                        foreach (var str in File.ReadAllLines("./files/f6.txt"))
                            Console.WriteLine(str);
                    }
                }
                else
                {
                    Distribution(true);
                    if (File.Exists("./files/f1.txt"))
                    {
                        Console.WriteLine("f1:");
                        foreach (var str in File.ReadAllLines("./files/f1.txt"))
                            Console.WriteLine(str);
                    }
                    if (File.Exists("./files/f2.txt"))
                    {
                        Console.WriteLine("f2:");
                        foreach (var str in File.ReadAllLines("./files/f2.txt"))
                            Console.WriteLine(str);
                    }
                    if (File.Exists("./files/f3.txt"))
                    {
                        Console.WriteLine("f3:");
                        foreach (var str in File.ReadAllLines("./files/f3.txt"))
                            Console.WriteLine(str);
                    }
                }
                numberOfFiles = new DirectoryInfo("./files/").GetFiles().Length;
            } while (numberOfFiles != 2);
            Console.WriteLine("Массив отсортирован.");
            Console.ReadKey();
        }
    }
}
