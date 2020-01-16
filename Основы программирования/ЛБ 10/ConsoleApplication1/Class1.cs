using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class client
    {
        public string percent, time, summ, debt, name;

        public static void function(out List<client> clients, out client men)
        {
            clients = new List<client>();
            men = new client();
            Console.Write("Срок кредита: ");
            men.time = Console.ReadLine();
            Console.Write("Процентная ставка: ");
            men.percent = Console.ReadLine();
            Console.Write("Cумма кредита: ");
            men.summ = Console.ReadLine();
            Console.Write("Долг: ");
            men.debt = Console.ReadLine();
            Console.Write("ФИО: ");
            men.name = Console.ReadLine();
            clients.Add(men);
        }
    }
}
