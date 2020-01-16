//Вариант 19. Товары и заказы.
//А: товар(наименование, цена, масса).
//Б: заказ(ФИО заказчика, срок доставки, дата оформления).
//Один товар может входить в несколько заказов, один заказ может содержать несколько товаров.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormProgram());
        }
    }

    class Product
    {
        protected internal string designation { get; set; }
        protected internal string price { get; set; }
        protected internal string weight { get; set; }
        protected internal static List<Product> products = new List<Product>();
    }

    class Order
    {
        protected internal string name { get; set; }
        protected internal string delivery_time { get; set; }
        protected internal string registration_date { get; set; }
        protected internal static List<Order> orders = new List<Order>();
    }

    class MyLink : IEquatable<MyLink>
    {
        protected internal int ID_product { get; set; }
        protected internal int ID_order { get; set; }
        protected internal static List<MyLink> links = new List<MyLink>();

        protected internal MyLink(int id_product, int id_order)
        {
            ID_product = id_product;
            ID_order = id_order;
        }
        // Для проверки наличия элемента в списке
        public bool Equals(MyLink other)
        {
            if (ID_product == other.ID_product && ID_order == other.ID_order)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Sort
    {
        /// <summary>
        /// Сортировка названия товара от А до Я и обратная
        /// </summary>
        protected internal static void ByDesignationUp()
        {
            Product.products.Sort((a, b) => a.designation.CompareTo(b.designation));
        }
        protected internal static void ByDesignationDown()
        {
            Product.products.Sort((a, b) => b.designation.CompareTo(a.designation));
        }
        /// <summary>
        /// Сортировка цены товара от меньшей к большей и наоборот
        /// </summary>
        protected internal static void ByPriceUp()
        {
            for (int i = 0; i < Product.products.Count - 1; i++)
            {   
                for (int j = i + 1; j < Product.products.Count; j++)
                {
                    string temp_str1 = Product.products[i].price; // временные строки для
                    temp_str1 = temp_str1.Remove(temp_str1.IndexOf(" ")); // сравнения элементов без
                    string temp_str2 = Product.products[j].price; // пробелов и последующих символов
                    temp_str2 = temp_str2.Remove(temp_str2.IndexOf(" "));
                    if (Convert.ToInt32(temp_str1) >
                        Convert.ToInt32(temp_str2))
                    {
                        var t = Product.products[i];
                        Product.products[i] = Product.products[j];
                        Product.products[j] = t;
                    }
                }
            }
        }
        protected internal static void ByPriceDown()
        {
            for (int i = 0; i < Product.products.Count - 1; i++)
            {
                for (int j = i + 1; j < Product.products.Count; j++)
                {
                    string temp_str1 = Product.products[i].price; // временные строки для
                    temp_str1 = temp_str1.Remove(temp_str1.IndexOf(" ")); // сравнения элементов без
                    string temp_str2 = Product.products[j].price; // пробелов и последующих символов
                    temp_str2 = temp_str2.Remove(temp_str2.IndexOf(" "));
                    if (Convert.ToInt32(temp_str1) <
                        Convert.ToInt32(temp_str2))
                    {
                        var t = Product.products[i];
                        Product.products[i] = Product.products[j];
                        Product.products[j] = t;
                    }
                }
            }
        }
        /// <summary>
        /// Сортировка веса товара от меньшего к большему и наоборот
        /// </summary>
        protected internal static void ByWeightUp()
        {
            for (int i = 0; i < Product.products.Count - 1; i++)
            {
                for (int j = i + 1; j < Product.products.Count; j++)
                {
                    string temp_str1 = Product.products[i].weight; // временные строки для
                    temp_str1 = temp_str1.Remove(temp_str1.IndexOf(" ")); // сравнения элементов без
                    string temp_str2 = Product.products[j].weight; // пробелов и последующих символов
                    temp_str2 = temp_str2.Remove(temp_str2.IndexOf(" "));
                    if (Convert.ToDouble(temp_str1) >
                        Convert.ToDouble(temp_str2))
                    {
                        var t = Product.products[i];
                        Product.products[i] = Product.products[j];
                        Product.products[j] = t;
                    }
                }
            }
        }
        protected internal static void ByWeightDown()
        {
            for (int i = 0; i < Product.products.Count - 1; i++)
            {
                for (int j = i + 1; j < Product.products.Count; j++)
                {
                    string temp_str1 = Product.products[i].weight; // временные строки для
                    temp_str1 = temp_str1.Remove(temp_str1.IndexOf(" ")); // сравнения элементов без
                    string temp_str2 = Product.products[j].weight; // пробелов и последующих символов
                    temp_str2 = temp_str2.Remove(temp_str2.IndexOf(" "));
                    if (Convert.ToDouble(temp_str1) <
                        Convert.ToDouble(temp_str2))
                    {
                        var t = Product.products[i];
                        Product.products[i] = Product.products[j];
                        Product.products[j] = t;
                    }
                }
            }
        }
        /// <summary>
        /// Сортировка ФИО заказчика от А до Я и обратная
        /// </summary>
        protected internal static void ByNameUp()
        {
            Order.orders.Sort((a, b) => a.name.CompareTo(b.name));
        }
        protected internal static void ByNameDown()
        {
            Order.orders.Sort((a, b) => b.name.CompareTo(a.name));
        }
        /// <summary>
        /// Сортировка по дате доставки по возрастанию и наоборот
        /// </summary>
        public static void ByDeliveryTimeUp()
        {
            Order.orders.Sort((a, b) => Convert.ToDateTime(a.delivery_time).
            CompareTo(Convert.ToDateTime(b.delivery_time)));
        }
        public static void ByDeliveryTimeDown()
        {
            Order.orders.Sort((a, b) => Convert.ToDateTime(b.delivery_time).
            CompareTo(Convert.ToDateTime(a.delivery_time)));
        }
        /// <summary>
        /// Сортировка по дате заказа по возрастанию и наоборот
        /// </summary>
        public static void ByRegistrationDateUp()
        {
            Order.orders.Sort((a, b) => Convert.ToDateTime(a.registration_date).
            CompareTo(Convert.ToDateTime(b.registration_date)));
        }
        public static void ByRegistrationDateDown()
        {
            Order.orders.Sort((a, b) => Convert.ToDateTime(b.registration_date).
            CompareTo(Convert.ToDateTime(a.registration_date)));
        }
    }
}
