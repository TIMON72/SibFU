using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class Product
    {
        public string designation;
        public string price;
        public string weight;
        public static List<Product> products = new List<Product>();
        public static void Add()
        {
            Product new_objectA = new Product();
            Console.WriteLine("Введите характеристики товара");
            Console.Write("Название товара: ");
            new_objectA.designation = Console.ReadLine();
            Console.Write("Цена товара: ");
            new_objectA.price = Console.ReadLine();
            Console.Write("Вес товара: ");
            new_objectA.weight = Console.ReadLine();
            products.Add(new_objectA);
        }
    }

    class Client
    {
        public string name;
        public string delivery_time;
        public string registration_date;
        public static List<Client> clients = new List<Client>();
        public static void Add()
        {
            Client new_objectB = new Client();
            Console.WriteLine("Введите данные клиента");
            Console.Write("ФИО клиента: ");
            new_objectB.name = Console.ReadLine();
            Console.Write("Дата заказа: ");
            new_objectB.registration_date = Console.ReadLine();
            Console.Write("Срок доставки: ");
            new_objectB.delivery_time = Console.ReadLine();
            clients.Add(new_objectB);
        }
    }

    class Link
    {
        public int ID_product;
        public int ID_client;
        public static List<Link> links = new List<Link>();
        public static void Linking()
        {
            Link new_link = new Link();
            Console.WriteLine("Введите ID товара и клиента для связки");
            Console.Write("ID товара: ");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.Write("ID клиента: ");
            int j = Convert.ToInt32(Console.ReadLine());

            new_link.ID_product = i; //Product.products.IndexOf(Product.products[i]);
            new_link.ID_client = j; //Client.clients.IndexOf(Client.clients[j]);
            links.Add(new_link);

        }
    }

    class Table
    {
        // Отображение всего списка
        public static void ShowAll()
        {
            for (int i = 0; i < Client.clients.Count; i++)
            {
                Console.Write(i + ". ");
                Console.Write(Client.clients[i].name + " ");
                Console.Write(Client.clients[i].registration_date + " ");
                Console.WriteLine(Client.clients[i].delivery_time);
            }
            for (int j = 0; j < Product.products.Count; j++)
            {
                Console.Write(j + ". ");
                Console.Write(Product.products[j].designation + " ");
                Console.Write(Product.products[j].price + " ");
                Console.WriteLine(Product.products[j].weight);
            }
            Console.WriteLine("--------------------------------------------------------------------------");
            
        }
        // Отображение связанных товаров
        public static void ShowLink()
        {
            Console.Write("Введите номер клиента для отображения связанных с ним товаров: ");
            int i = Convert.ToInt32(Console.ReadLine());
            List<Link> results = Link.links.FindAll(t => t.ID_client.Equals(i)); // Создаем массив, который содержит только элементы массива links
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
