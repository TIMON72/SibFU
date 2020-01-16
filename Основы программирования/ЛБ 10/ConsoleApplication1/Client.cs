using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Client
    {
        public string name, summ, date, percent, debt;
        // Ф-ция добавления нового клиента (меню 1.1)
        private static void AddingClient(ref List<Client> clients)
        {
            Client newclient = new Client(); // Создаем новый объект в структуре
            Console.Write("ФИО: ");
            newclient.name = Console.ReadLine();
            Console.Write("Cумма кредита (10000 - 1000000): ");
            newclient.summ = Convert.ToString(Basis.ProtectEntryOfNumber());
            Console.Write("Срок кредита (5-50): ");
            newclient.date = Convert.ToString(Basis.ProtectEntryOfNumber());
            Console.Write("Процентная ставка (1-100): ");
            newclient.percent = Convert.ToString(Basis.ProtectEntryOfNumber());
            // Расчет и запись суммы, которую должен выплатить клиент по истечению срока
            int x = Convert.ToInt32(newclient.summ);
            int y = Convert.ToInt32(newclient.percent);
            int z = Convert.ToInt32(newclient.date);
            newclient.debt = Convert.ToString(x + 0.01 * y * x * z);
            clients.Add(newclient); // Добавляем в массив 1-го клиента
            Console.Clear(); // Очистка экрана
        }
        // Ф-ция изменения i-ого клиента (меню 1.2)
        private static int EditingClient(ref List<Client> clients)
        {
            link0:
            Basis.Printing(ref clients);
            link1:
            Console.Write("Введите номер клиента, которого вы хотите изменить (для возврата назад введите -1): ");
            int i = Basis.ProtectEntryOfNumber();
            if (i < clients.Count && i >= 0)
            {
                Console.Write("ФИО: ");
                clients[i].name = Console.ReadLine();
                Console.Write("Cумма кредита (10000 - 1000000): ");
                clients[i].summ = Convert.ToString(Basis.ProtectEntryOfNumber());
                Console.Write("Срок кредита (5-50): ");
                clients[i].date = Convert.ToString(Basis.ProtectEntryOfNumber());
                Console.Write("Процентная ставка (1-100): ");
                clients[i].percent = Convert.ToString(Basis.ProtectEntryOfNumber());
                // Расчет и запись суммы, которую должен выплатить клиент по истечению срока
                int x = Convert.ToInt32(clients[i].summ);
                int y = Convert.ToInt32(clients[i].percent);
                int z = Convert.ToInt32(clients[i].date);
                clients[i].debt = Convert.ToString(x + 0.01 * y * x * z);
                Console.Clear(); // Очистка экрана
                goto link0;
            }
            else if (i == -1)
            {
                Console.Clear();
                return i;
            }
            else
            {
                Console.WriteLine("Клиента с таким номером нет");
                goto link1;
            }
        }
        // Ф-ция удаления i-ого клиента (меню 1.3)
        private static int ClearClient(ref List<Client> clients)
        {
            link0:
            Basis.Printing(ref clients);
            link1:
            Console.Write("Введите номер клиента, которого вы хотите удалить (для возврата назад введите -1): ");
            int i = Basis.ProtectEntryOfNumber();
            if (i < clients.Count && i >= 0)
            {
                clients.RemoveAt(i); // Удаляем i-ый элемент
                Console.Clear(); // Очистка экрана
                goto link0;
            }
            else if (i == -1)
            {
                Console.Clear();
                return i;
            }
            else
            {
                Console.WriteLine("Клиента с таким номером нет");
                goto link1;
            }
        }
        // Меню 1
        public static void Menu1(ref List<Client> clients)
        {
            int menu = 0;
            do
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>  МЕНЮ  <<<<<<<<<<<<<<<<");
                Console.WriteLine("1. Добавить нового клиента");
                Console.WriteLine("2. Редактировать");
                Console.WriteLine("3. Удалить клиента");
                Console.WriteLine("4. Назад");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<");
                Console.Write("Введите пункт меню: ");
                menu = Basis.ProtectEntryOfNumber();
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        {
                            Console.Clear();
                            AddingClient(ref clients);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            EditingClient(ref clients);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            ClearClient(ref clients);
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Вы ввели несуществующий пункт меню\n");
                            break;
                        }
                }
            } while (menu != 4);
        }
    }
}
