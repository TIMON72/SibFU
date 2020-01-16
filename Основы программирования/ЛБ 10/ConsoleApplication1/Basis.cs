using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Basis
    {
        // Ф-ция защиты для ввода чисел
        public static int ProtectEntryOfNumber()
        {
            int x;
            while (true)
            {
                try
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели не число");
                }
            }
            return x;
        }
        // Ф-ция вывода на экран массива
        public static void Printing(ref List<Client> clients)
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|   Фамилия Имя Отчество                 | Cумма кредита    | Срок    | % ставка в год | Сумма кредита по истечению срока |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < clients.Count; i++)
            {
                Console.Write("|" + i + ". {0}", clients[i].name.PadRight(36));
                Console.Write(" | {0} рублей", clients[i].summ.PadRight(9));
                Console.Write(" | {0} лет", clients[i].date.PadRight(3));
                Console.Write(" | {0} %", clients[i].percent.PadRight(12));
                Console.WriteLine(" | {0} рублей |", clients[i].debt.PadRight(25));
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
        }
    }
}
