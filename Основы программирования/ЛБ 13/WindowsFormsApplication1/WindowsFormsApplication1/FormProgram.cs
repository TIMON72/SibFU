using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // Для работы с файлами

namespace WindowsFormsApplication1
{
    public partial class FormProgram : Form
    {
        private bool sorting_column = false; // состояние сортируемой колокни
        protected internal int change_index = -1; // индекс изменяемого элемента
        protected internal bool change_bool = false; // состояние изменяемого элемента
        public FormProgram()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Нажатие на кнопку "Добавить" слева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FormProduct form_product = new FormProduct();
            form_product.Owner = this; // Задаем FormProgram родителем для FormProduct
            form_product.Show();
        }
        /// <summary>
        /// Нажатие на кнопку "Изменить" слева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            bool exception = false;
            try
            {
                change_index = listView1.SelectedIndices[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                exception = true;
            }
            if (!exception)
            {
                change_bool = true;
                FormProduct form_product = new FormProduct();
                form_product.Owner = this; // Задаем FormProgram родителем для FormProduct
                form_product.maskedTextBox1.Text = Product.products[change_index].designation;
                form_product.maskedTextBox2.Text = Product.products[change_index].price;
                form_product.maskedTextBox3.Text = Product.products[change_index].weight;
                form_product.Show();
            }
        }
        /// <summary>
        /// Нажатие на кнопку "Удалить" слева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int index = -1;
            bool exception = false;
            try
            {
                index = listView1.SelectedIndices[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                exception = true;
            }
            if (!exception)
            {
                listView1.BeginUpdate();
                Product.products.RemoveAt(index);
                listView1.Items.RemoveAt(index);
                // Ищем все связанные связи с удаляемым элементом
                List<MyLink> results = MyLink.links.FindAll(t => t.ID_product.Equals(index));
                for (int i = 0; i < results.Count; i++)
                {
                    MyLink.links.RemoveAt(results[i].ID_product);
                }
                listView1.EndUpdate();
            }
            else if (listView1.CheckedItems.Count != 0)
            {
                listView1.BeginUpdate();
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Checked)
                    {
                        listView1.Items.RemoveAt(i);
                        Product.products.RemoveAt(i);
                        i--;
                    }
                }
                listView1.EndUpdate();
            }
        }
        /// <summary>
        /// Нажатие на кнопку "Добавить" справа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            FormOrder form_order = new FormOrder();
            form_order.Owner = this; // Задаем FormProgram родителем для FormOrder
            form_order.Show();
        }
        /// <summary>
        /// Нажатие на кнопку "Изменить" справа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            bool exception = false;
            try
            {
                change_index = listView2.SelectedIndices[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                exception = true;
            }
            if (!exception)
            {
                change_bool = true;
                FormOrder form_order = new FormOrder();
                form_order.Owner = this; // Задаем FormProgram родителем для FormProduct
                form_order.maskedTextBox1.Text = Order.orders[change_index].name;
                form_order.maskedTextBox2.Text = Order.orders[change_index].delivery_time;
                form_order.maskedTextBox3.Text = Order.orders[change_index].registration_date;
                form_order.Show();
            }
        }
        /// <summary>
        /// Нажатие на кнопку "Удалить" справа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            {
                int index = -1;
                bool exception = false;
                try
                {
                    index = listView2.SelectedIndices[0];
                }
                catch (ArgumentOutOfRangeException)
                {
                    exception = true;
                }
                if (!exception)
                {
                    listView2.BeginUpdate();
                    Product.products.RemoveAt(index);
                    listView2.Items.RemoveAt(index);
                    listView2.EndUpdate();
                }
                else if (listView2.CheckedItems.Count != 0)
                {
                    listView2.BeginUpdate();
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        if (listView2.Items[i].Checked)
                        {
                            listView2.Items.RemoveAt(i);
                            Order.orders.RemoveAt(i);
                            i--;
                        }
                    }
                    listView2.EndUpdate();
                }
            }
        }
        /// <summary>
        /// Нажатие на кнопку "Связать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            // Создаем коллекции выбранных для связи элементов
            ListView.CheckedIndexCollection selected_products = listView1.CheckedIndices;
            ListView.CheckedIndexCollection selected_orders = listView2.CheckedIndices;
            // Если ничего не выбрали
            if (selected_products.Count == 0 || selected_orders.Count == 0)
            {
                MessageBox.Show("Выберите товары и заказы для связки");
            }
            // Если пытаемся связать многое со многим
            else if (selected_products.Count > 1 && selected_orders.Count > 1)
            {
                MessageBox.Show("Вы выбрали много товаров и заказов одновременно для связки, " +
                    "выберете один товар или один заказ");
            }
            // Связываем 1 товар и много заказов
            else if (selected_products.Count == 1)
            {
                foreach (int index_product in selected_products)
                {
                    foreach (int index_order in selected_orders)
                    {
                        if (MyLink.links.Count != 0)
                        {
                            // Игнорируем существующую связь и ей симметричную
                            if (MyLink.links.Contains(new MyLink(index_product, index_order)))
                            {
                                continue;
                            }
                            else
                            {
                                MyLink.links.Add(new MyLink(index_product, index_order));
                            }
                        }
                        else
                        {
                            MyLink.links.Add(new MyLink(index_product, index_order));
                        }
                    }
                }
            }
            // Связываем 1 заказ и много товаров
            else if (selected_orders.Count == 1)
            {
                foreach (int index_order in selected_orders)
                {
                    foreach (int index_product in selected_products)
                    {
                        if (MyLink.links.Count != 0)
                        {
                            // Игнорируем существующую связь и ей симметричную
                            if (MyLink.links.Contains(new MyLink(index_product, index_order)))
                            {
                                continue;
                            }
                            else
                            {
                                MyLink.links.Add(new MyLink(index_product, index_order));
                            }
                        }
                        else
                        {
                            MyLink.links.Add(new MyLink(index_product, index_order));
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Нажатие на кнопку "Показать связанные элементы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            // Получаем индекс выделенной строки
            int index1 = -1;
            int index2 = -1;
            bool exception1 = false;
            bool exception2 = false;
            try
            {
                index1 = listView1.SelectedIndices[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                exception1 = true;
            }
            try
            {
                index2 = listView2.SelectedIndices[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                exception2 = true;
            }
            // Если оба индекса не получили значения
            if (exception1 && exception2)
            {
                MessageBox.Show("Вы не выбрали элемент для отображения связи");
                return;
            }
            listView1.BeginUpdate();
            listView2.BeginUpdate();
            // Очищаем таблицы
            listView1.Items.Clear();
            listView2.Items.Clear();
            // Если мы выделили в левой таблице элемент для отображения связей
            if (exception2)
            {
                // Добавляем в первую таблицу выбранный нами товар
                ListViewItem product = new ListViewItem(Product.products[index1].designation);
                product.SubItems.Add(Product.products[index1].price);
                product.SubItems.Add(Product.products[index1].weight);
                listView1.Items.Add(product);
                // Создаем массив, который ищет связи в links (ID товара и ID его заказов)
                List<MyLink> results = MyLink.links.FindAll(t => t.ID_product.Equals(index1));
                if (results.Count != 0)
                {
                    for (int t = 0; t < results.Count; t++)
                    {
                        ListViewItem order = new ListViewItem(Order.orders[results[t].ID_order].name);
                        order.SubItems.Add(Order.orders[results[t].ID_order].delivery_time);
                        order.SubItems.Add(Order.orders[results[t].ID_order].registration_date);
                        listView2.Items.Add(order);
                    }
                }
            }
            // Если мы выделили в правой таблице элемент для отображения связей
            if (exception1)
            {
                // Добавляем во вторую таблицу выбранный нами товар
                ListViewItem order = new ListViewItem(Order.orders[index2].name);
                order.SubItems.Add(Order.orders[index2].delivery_time);
                order.SubItems.Add(Order.orders[index2].registration_date);
                listView2.Items.Add(order);
                // Создаем массив, который ищет связи в links (ID товара и ID его заказов)
                List<MyLink> results = MyLink.links.FindAll(t => t.ID_order.Equals(index2));
                if (results.Count != 0)
                {
                    for (int i = 0; i < results.Count; i++)
                    {
                        ListViewItem product = new ListViewItem(
                            Product.products[results[i].ID_product].designation);
                        product.SubItems.Add(Product.products[results[i].ID_product].price);
                        product.SubItems.Add(Product.products[results[i].ID_product].weight);
                        listView1.Items.Add(product);
                    }
                }
            }
            listView1.EndUpdate();
            listView2.EndUpdate();
        }
        /// <summary>
        /// Нажатие на кнопку "Вывести полный список на экран"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            listView2.BeginUpdate();
            listView1.Items.Clear();
            listView2.Items.Clear();
            for (int i = 0; i < Product.products.Count; i++)
            {
                ListViewItem product = new ListViewItem(Product.products[i].designation);
                product.SubItems.Add(Product.products[i].price);
                product.SubItems.Add(Product.products[i].weight);
                listView1.Items.Add(product);
            }
            for (int i = 0; i < Order.orders.Count; i++)
            {
                ListViewItem order = new ListViewItem(Order.orders[i].name);
                order.SubItems.Add(Order.orders[i].delivery_time);
                order.SubItems.Add(Order.orders[i].registration_date);
                listView2.Items.Add(order);
            }
            listView1.EndUpdate();
            listView2.EndUpdate();
        }
        /// <summary>
        /// Нажатие на кнопку "Загрузить данные из файла"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            // Открыть диалоговое окно выбора файлов
            string path = "";
            string ext = "";
            string file_name = "";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"C:\Users\TIMON_Dark\OneDrive\Google Drive\Study\Основы программирования\Программы\Лабораторные работы\ЛБ 13\WindowsFormsApplication1\WindowsFormsApplication1\[Файлы]";
            dlg.Filter = ".txt файлы|*.txt|Все файлы|*.*";
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = dlg.FileName;
                ext = Path.GetExtension(dlg.FileName);
                file_name = Path.GetFileName(dlg.FileName);
            }
            else
            {
                return;
            }
            // Чтение из файла
            FileStream file;
            file = new FileStream(path, FileMode.Open, FileAccess.Read);
            if (ext == ".txt")
            {
                StreamReader reader = new StreamReader(file); // Потоковое чтение файла
                while (!reader.EndOfStream)
                {
                    string buf = ""; // Буферная переменная для считываемой строки
                    reader.ReadLine();
                    buf = reader.ReadLine();
                    // Считывание товаров
                    while (buf != "orders:")
                    {
                        string[] buf_arr = buf.Split('|'); // Создаем буферный массив 
                                                           //с разбиением на эл-ты по "|"
                        Product new_product = new Product();
                        new_product.designation = buf_arr[0];
                        new_product.price = buf_arr[1];
                        new_product.weight = buf_arr[2];
                        buf_arr = null; // Удаляем ссылки на массив
                        Product.products.Add(new_product);
                        buf = reader.ReadLine();
                    }
                    buf = reader.ReadLine();
                    // Считывание заказчиков
                    while (buf != "links:")
                    {
                        string[] buf_arr = buf.Split('|'); // Создаем буферный массив 
                                                           //с разбиением на эл-ты по "|"
                        Order new_order = new Order();
                        new_order.name = buf_arr[0];
                        new_order.delivery_time = buf_arr[1];
                        new_order.registration_date = buf_arr[2];
                        buf_arr = null; // Удаляем ссылки на массив
                        Order.orders.Add(new_order);
                        buf = reader.ReadLine();
                    }
                    buf = reader.ReadLine();
                    // Cчитывание связок
                    while (true)
                    {
                        string i, j;
                        string[] buf_arr = buf.Split('|', ','); // Создаем буферный массив 
                                                                //с разбиением на эл-ты по "|"
                        for (int k = 0; k < buf_arr.Length; k = k + 2)
                        {
                            i = buf_arr[k];
                            j = buf_arr[k + 1];
                            int id_product = Convert.ToInt32(i);
                            int id_order = Convert.ToInt32(j);
                            MyLink.links.Add(new MyLink(id_product, id_order));
                        }
                        buf_arr = null; // Удаляем ссылки на массив
                        break;
                    }
                }
                reader.Close();
                button9_Click(sender, e); // Выводим список на экран
            }
            else
            {
                MessageBox.Show("Вы выбрали некорректный файл не в формате .txt");
            }
        }
        /// <summary>
        /// Нажатие на кнопку "Записать в файл"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            // Открыть диалоговое окно для сохранения файла
            string path = "";
            string ext = "";
            string file_name = "";
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = @"C:\Users\TIMON_Dark\OneDrive\Google Drive\Study\Основы программирования\Программы\Лабораторные работы\ЛБ 13\WindowsFormsApplication1\WindowsFormsApplication1\[Файлы]";
            dlg.Filter = ".txt файлы|*.txt|Все файлы|*.*";
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = dlg.FileName;
                ext = Path.GetExtension(dlg.FileName);
                file_name = Path.GetFileName(dlg.FileName);
            }
            else
            {
                return;
            }
            // Запись в файл
            FileStream file;
            file = new FileStream(path, FileMode.Truncate, FileAccess.Write);
            if (ext == ".txt")
            {
                StreamWriter writer = new StreamWriter(file);
                // Запись товаров
                writer.WriteLine("products:");
                for (int i = 0; i < Product.products.Count; i++)
                {
                    string buf;
                    buf = Product.products[i].designation + "|" +
                        Product.products[i].price + "|" +
                        Product.products[i].weight;
                    writer.WriteLine(buf);
                }
                // Запись заказчиков
                writer.WriteLine("orders:");
                for (int i = 0; i < Order.orders.Count; i++)
                {
                    string buf;
                    buf = Order.orders[i].name + "|" +
                        Order.orders[i].delivery_time + "|" +
                        Order.orders[i].registration_date;
                    writer.WriteLine(buf);
                }
                writer.WriteLine("links:");
                // Запись связок
                for (int i = 0; i < MyLink.links.Count; i++)
                {
                    string buf;
                    buf = MyLink.links[i].ID_product + "," +
                        MyLink.links[i].ID_order + "|";
                    if (i == MyLink.links.Count - 1)
                    {
                        writer.Write(MyLink.links[i].ID_product + "," +
                        MyLink.links[i].ID_order);
                    }
                    else
                    {
                        writer.Write(buf);
                    }
                }
                writer.Close();
            }
            else
            {
                MessageBox.Show("Вы выбрали некорректный файл не в формате .txt");
            }
        }
        /// <summary>
        /// Нажатие на кнопку "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Событие при нажатии на заголовки колонок таблицы слева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Если выбрана первая колонка "Название"
            if (e.Column == 0)
            {
                if (sorting_column)
                {
                    Sort.ByDesignationDown();
                    sorting_column = false;
                }
                else
                {
                    Sort.ByDesignationUp();
                    sorting_column = true;
                }
            }
            // Если выбрана вторая колонка "Цена"
            if (e.Column == 1)
            {
                if (sorting_column)
                {
                    Sort.ByPriceDown();
                    sorting_column = false;
                }
                else
                {
                    Sort.ByPriceUp();
                    sorting_column = true;
                }
            }
            // Если выбрана третья колонка "Вес"
            if (e.Column == 2)
            {
                if (sorting_column)
                {
                    Sort.ByWeightDown();
                    sorting_column = false;
                }
                else
                {
                    Sort.ByWeightUp();
                    sorting_column = true;
                }
            }
            button9_Click(sender, e); // Выводим список на экран
        }
        /// <summary>
        /// Событие при нажатии на заголовки колонок таблицы справа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Если выбрана первая колонка "ФИО"
            if (e.Column == 0)
            {
                if (sorting_column)
                {
                    Sort.ByNameDown();
                    sorting_column = false;
                }
                else
                {
                    Sort.ByNameUp();
                    sorting_column = true;
                }
            }
            // Если выбрана вторая колонка "Дата доставки"
            if (e.Column == 1)
            {
                if (sorting_column)
                {
                    Sort.ByDeliveryTimeDown();
                    sorting_column = false;
                }
                else
                {
                    Sort.ByDeliveryTimeUp();
                    sorting_column = true;
                }
            }
            // Если выбрана третья колонка "Дата заказа"
            if (e.Column == 2)
            {
                if (sorting_column)
                {
                    Sort.ByRegistrationDateDown();
                    sorting_column = false;
                }
                else
                {
                    Sort.ByRegistrationDateUp();
                    sorting_column = true;
                }
            }
            button9_Click(sender, e); // Выводим список на экран
        }
    }
}
