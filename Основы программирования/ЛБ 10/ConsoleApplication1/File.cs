using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Для работы с файлами
using System.Windows.Forms; // Для работы с окнами

namespace ConsoleApplication1
{
    class File
    {
        // Ф-ция чтения файла (меню 2)
        public static void ReadFile(ref List<Client> clients)
        {
            string path = "";
            string ext = "";
            string file_name = "";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"C:\Users\TIMON_Dark\OneDrive\Google Drive\Study\Основы программирования\Программы\Лабораторные работы\ЛБ 10\ConsoleApplication1\[Файлы]";
            dlg.Filter = ".txt и .bin файлы|*.txt; *.bin|Все файлы|*.*";
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = dlg.FileName;
                ext = Path.GetExtension(dlg.FileName);
                file_name = Path.GetFileName(dlg.FileName);
                Console.Write("Файл \"" + file_name + "\" открыт успешно");
            }
            else
            {
                Console.WriteLine("Вы не выбрали файл");
                Console.Write("Нажмите любую клавишу, чтобы продолжить ");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            FileStream file;
            file = new FileStream(path, FileMode.Open, FileAccess.Read);
            if (ext == ".txt")
            {
                StreamReader reader = new StreamReader(file); // Потоковое чтение файла
                while (!reader.EndOfStream)
                {
                    string buf; // Буферная переменная для считываемой строки
                    buf = reader.ReadLine();
                    string[] buf_arr = buf.Split('|'); // Создаем буферный массив с разбиением на эл-ты по "|"
                    Client newclient = new Client(); // Создаем новый объект в структуре
                    newclient.name = buf_arr[0];
                    newclient.summ = buf_arr[1];
                    newclient.date = buf_arr[2];
                    newclient.percent = buf_arr[3];
                    buf_arr = null; // Удаляем ссылки на массив
                    // Расчет и запись суммы, которую должен выплатить клиент по истечению срока
                    int x = Convert.ToInt32(newclient.summ);
                    int y = Convert.ToInt32(newclient.percent);
                    int z = Convert.ToInt32(newclient.date);
                    newclient.debt = Convert.ToString(x + 0.01 * y * x * z);
                    clients.Add(newclient); // Добавляем в массив 1-го клиента
                }
                reader.Close();
                Console.WriteLine(" и данные считаны оттуда");
            }
            if (ext == ".bin")
            {
                BinaryReader reader = new BinaryReader(file); // Потоковое чтение файла
                                                              //Console.WriteLine(reader.ReadToEnd());
                while (reader.PeekChar() != -1)
                {
                    string buf; // Буферная переменная для считываемой строки
                    buf = reader.ReadString();
                    string[] buf_arr = buf.Split('|'); // Создаем буферный массив с разбиением на эл-ты по "|"
                    Client newclient = new Client(); // Создаем новый объект в структуре
                    newclient.name = buf_arr[0];
                    newclient.summ = buf_arr[1];
                    newclient.date = buf_arr[2];
                    newclient.percent = buf_arr[3];
                    buf_arr = null; // Удаляем ссылки на массив
                    // Расчет и запись суммы, которую должен выплатить клиент по истечению срока
                    int x = Convert.ToInt32(newclient.summ);
                    int y = Convert.ToInt32(newclient.percent);
                    int z = Convert.ToInt32(newclient.date);
                    newclient.debt = Convert.ToString(x + 0.01 * y * x * z);
                    clients.Add(newclient); // Добавляем в массив 1-го клиента
                }
                reader.Close();
                Console.WriteLine(" и данные считаны оттуда");
            }
            if (ext != ".txt" && ext != ".bin")
            {
                Console.WriteLine(", но вы выбрали неверное расширение файла (выберите .bin или .txt)");
                Console.Write("Нажмите любую клавишу, чтобы продолжить ");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.Write("Нажмите любую клавишу, чтобы продолжить ");
            Console.ReadKey();
            Console.Clear();
        }
        // Ф-ция записи файла (меню 4.1)
        private static void RecordFile(ref List<Client> clients)
        {
            string path = "";
            string ext = "";
            string file_name = "";
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = @"C:\Users\TIMON_Dark\OneDrive\Google Drive\Study\Основы программирования\Программы\Лабораторные работы\ЛБ 10\ConsoleApplication1\[Файлы]";
            dlg.Filter = ".txt и .bin файлы|*.txt; *.bin|Все файлы|*.*";
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = dlg.FileName;
                ext = Path.GetExtension(dlg.FileName);
                file_name = Path.GetFileName(dlg.FileName);
            }
            else
            {
                Console.WriteLine("Вы не выбрали файл");
                Console.Write("Нажмите любую клавишу, чтобы продолжить ");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            FileStream file;
            file = new FileStream(path, FileMode.Truncate, FileAccess.Write);
            if (ext == ".txt")
            {
                StreamWriter writer = new StreamWriter(file);
                for (int i = 0; i < clients.Count; i++)
                {
                    string buf;
                    buf = clients[i].name + "|" + clients[i].summ + "|" +
                        clients[i].date + "|" + clients[i].percent;
                    if (i == clients.Count - 1)
                    {
                        writer.Write(buf);
                    }
                    else
                    {
                        writer.WriteLine(buf);
                    }
                }
                writer.Close();
                Console.WriteLine("Данные успешно записаны в \"" + file_name + "\"");
            }
            if (ext == ".bin")
            {
                BinaryWriter writer = new BinaryWriter(file);
                for (int i = 0; i < clients.Count; i++)
                {
                    string buf;
                    buf = clients[i].name + "|" + clients[i].summ + "|" +
                        clients[i].date + "|" + clients[i].percent;
                    if (i == clients.Count - 1)
                    {
                        writer.Write(buf);
                    }
                    else
                    {
                        writer.Write(buf);
                    }
                }
                writer.Close();
                Console.WriteLine("Данные успешно записаны в \"" + file_name + "\"");
            }
            if (ext != ".txt" && ext != ".bin")
            {
                Console.WriteLine("Вы выбрали файл с неверным расширением для записи (выберите .bin или .txt)");
                Console.Write("Нажмите любую клавишу, чтобы продолжить ");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.Write("Нажмите любую клавишу, чтобы продолжить ");
            Console.ReadKey();
            Console.Clear();
        }
        // Ф-ция записи файла-отчёта (меню 4.2)
        private static void Report(ref List<Client> clients)
        {
            string path = "";
            string path_folder = "";
            string file_name = "";
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_folder = dlg.SelectedPath;
                file_name = "Отчёт.txt";
                path = Path.Combine(path_folder, file_name);
            }
            else
            {
                Console.WriteLine("Вы не выбрали папку для создания в ней отчёта");
                Console.Write("Нажмите любую клавишу, чтобы продолжить ");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            FileStream file;
            file = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
            writer.WriteLine("|   Фамилия Имя Отчество                 | Cумма кредита    | Срок    | % ставка в год | Сумма кредита по истечению срока |");
            writer.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < clients.Count; i++)
            {
                writer.Write("|" + i + ". {0}", clients[i].name.PadRight(36));
                writer.Write(" | {0} рублей", clients[i].summ.PadRight(9));
                writer.Write(" | {0} лет", clients[i].date.PadRight(3));
                writer.Write(" | {0} %", clients[i].percent.PadRight(12));
                writer.WriteLine(" | {0} рублей |", clients[i].debt.PadRight(25));
            }
            writer.Write("---------------------------------------------------------------------------------------------------------------------------");
            writer.Close();
            Console.WriteLine("Файл-отчёт успешно записан в: " + path);
            System.Diagnostics.Process.Start(path_folder);
            Console.Write("Нажмите любую клавишу, чтобы продолжить ");
            Console.ReadKey();
            Console.Clear();
        }
        // Меню 4
        public static void Menu4(ref List<Client> clients)
        {
            int menu = 0;
            do
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>  МЕНЮ  <<<<<<<<<<<<<<<<");
                Console.WriteLine("1. Записать в файл");
                Console.WriteLine("2. Создать файл-отчёт");
                Console.WriteLine("3. Назад");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<");
                Console.Write("Введите пункт меню: ");
                menu = Basis.ProtectEntryOfNumber();
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        {
                            Console.Clear();
                            RecordFile(ref clients);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Report(ref clients);
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Вы ввели несуществующий пункт меню\n");
                            break;
                        }
                }
            } while (menu != 3);
        }
    }
}