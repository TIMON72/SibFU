using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Table
    {
        // Отображение всего списка
        //public static void ShowAll()
        //{
        //    for (int i = 0; i < Order.orders.Count; i++)
        //    {
        //        Console.Write(i + ". ");
        //        Console.Write(Order.orders[i].name + " ");
        //        Console.Write(Order.orders[i].registration_date + " ");
        //        Console.WriteLine(Order.orders[i].delivery_time);
        //    }
        //    for (int j = 0; j < Product.products.Count; j++)
        //    {
        //        Console.Write(j + ". ");
        //        Console.Write(Product.products[j].designation + " ");
        //        Console.Write(Product.products[j].price + " ");
        //        Console.WriteLine(Product.products[j].weight);
        //    }
        //    Console.WriteLine("--------------------------------------------------------------------------");
            
        //}
        // Отображение связанных товаров
        public static void ShowLink()
        {
            Console.Write("Введите номер клиента для отображения связанных с ним товаров: ");
            int i = Convert.ToInt32(Console.ReadLine());
            List<MyLink> results = MyLink.links.FindAll(t => t.ID_order.Equals(i)); // Создаем массив, который содержит только элементы массива links
                                                                                 // c выбранным ID клиента (т.е. ID клиента и ID его товаров)
            if (results.Count != 0)
            {
                for (int t = 0; t < results.Count; t++)
                {
                    Console.Write(results[t].ID_product + " ");
                }
            }
            else
            {
                Console.WriteLine("Связей нет");
            }
        }
    }
}
