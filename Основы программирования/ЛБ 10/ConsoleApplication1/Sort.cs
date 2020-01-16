using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Sort
    {
        // Меню 3
        public static void Menu3(ref List<Client> clients)
        {
            int menu = 0;
            do
            {
                Basis.Printing(ref clients);
                Console.WriteLine(">>>>>>>>>>>>>>>>  МЕНЮ  <<<<<<<<<<<<<<<<");
                Console.WriteLine("1. Сортировка по ФИО");
                Console.WriteLine("2. Сортировка по сумме кредита");
                Console.WriteLine("3. Сортировка по сроку кредита");
                Console.WriteLine("4. Сортировка по процентной ставке в год");
                Console.WriteLine("5. Сортировка по сумме, которую должен выплатить клиент за срок кредита");
                Console.WriteLine("6. Назад");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<");
                Console.Write("Введите пункт меню: ");
                menu = Basis.ProtectEntryOfNumber();
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        {
                            Console.Clear();
                            clients.Sort((a, b) => a.name.CompareTo(b.name));
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            for (int i = 0; i < clients.Count - 1; i++)
                            {
                                for (int j = i + 1; j < clients.Count; j++)
                                {
                                    if (Convert.ToInt32(clients[i].summ) > Convert.
                                        ToInt32(clients[j].summ))
                                    {
                                        var t = clients[i];
                                        clients[i] = clients[j];
                                        clients[j] = t;
                                    }
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            for (int i = 0; i < clients.Count - 1; i++)
                            {
                                for (int j = i + 1; j < clients.Count; j++)
                                {
                                    if (Convert.ToInt32(clients[i].date) > Convert.
                                        ToInt32(clients[j].date))
                                    {
                                        var t = clients[i];
                                        clients[i] = clients[j];
                                        clients[j] = t;
                                    }
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            for (int i = 0; i < clients.Count - 1; i++)
                            {
                                for (int j = i + 1; j < clients.Count; j++)
                                {
                                    if (Convert.ToInt32(clients[i].percent) > Convert.
                                        ToInt32(clients[j].percent))
                                    {
                                        var t = clients[i];
                                        clients[i] = clients[j];
                                        clients[j] = t;
                                    }
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            for (int i = 0; i < clients.Count - 1; i++)
                            {
                                for (int j = i + 1; j < clients.Count; j++)
                                {
                                    if (Convert.ToInt32(clients[i].debt) > Convert.
                                        ToInt32(clients[j].debt))
                                    {
                                        var t = clients[i];
                                        clients[i] = clients[j];
                                        clients[j] = t;
                                    }
                                }
                            }
                            break;
                        }
                    case 6:
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
            } while (menu != 6);
        }
    }
}
