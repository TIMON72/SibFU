using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ObjectB : ObjectA
    {
        static List<ObjectB> listB = new List<ObjectB>();
        string name, delivery_time, registration_date;
        //public static void AddItem()
        //{
        //    ObjectB new_objectB = new ObjectB();
        //    Console.WriteLine("Введите данные покупателя:");
        //    Console.Write("ФИО: ");
        //    new_objectB.name = Console.ReadLine();
        //    Console.Write("Срок доставки товара: ");
        //    new_objectB.delivery_time = Console.ReadLine();
        //    Console.Write("Дата оформления товара: ");
        //    new_objectB.registration_date = Console.ReadLine();
        //    listB.Add(new_objectB);
        //}
    }
}
