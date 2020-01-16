// Вариант 19
//Кредиты: ФИО заемщика, сумма, процентная ставка в год, срок кредита. Дополнить вывод
//информацией о сумме процентов, которые понадобится выплатить заемщику за срок
//кредита.
//а) сохранять все данные(массив структур) в бинарный файл;
//б) загружать данные из бинарного файла;
//в) сохранять данные в текстовом файле в формате, удобном для последующей загрузки;
//г) загружать данные из текстового файла;
//д) сохранять данные в текстовом файле, удобном для работы человека(отчет).
//Снабдить программу меню пользователя.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            List<Client> clients = new List<Client>();
            int menu = 0;
            do
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>  МЕНЮ  <<<<<<<<<<<<<<<<");
                Console.WriteLine("1. Клиенты");
                Console.WriteLine("2. Добавить клиентов из файла");
                Console.WriteLine("3. Вывод на экран и сортировка");
                Console.WriteLine("4. Запись клиентов в файл");
                Console.WriteLine("5. Выход");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<");
                Console.Write("Введите пункт меню: ");
                menu = Basis.ProtectEntryOfNumber();
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        {
                            Console.Clear();
                            Client.Menu1(ref clients);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            File.ReadFile(ref clients);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Sort.Menu3(ref clients);
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            File.Menu4(ref clients);
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Вы ввели несуществующий пункт меню\n");
                            break;
                        }
                }
            } while (menu != 5);
        }
    }
}
