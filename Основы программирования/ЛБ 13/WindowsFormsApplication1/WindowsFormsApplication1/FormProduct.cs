using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Нажатие на кнопку "ОК"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if ((maskedTextBox1.Text != string.Empty) &&
                (maskedTextBox2.Text != "       руб.") &&
                (maskedTextBox3.Text != "    ,    кг"))
            {
                // Добавляем в список
                Product new_product = new Product();
                new_product.designation = maskedTextBox1.Text;
                new_product.price = maskedTextBox2.Text;
                new_product.weight = maskedTextBox3.Text;
                FormProgram parent = Owner as FormProgram; // Создаем объект родителя
                // Если это добавление нового элемента
                if (!parent.change_bool)
                {
                    Product.products.Add(new_product);
                    ListViewItem new_item = new ListViewItem(maskedTextBox1.Text);
                    new_item.SubItems.Add(maskedTextBox2.Text);
                    new_item.SubItems.Add(maskedTextBox3.Text);
                    parent.listView1.Items.Add(new_item);
                }
                // Если это изменение элемента
                else
                {
                    parent.change_bool = false; // Возвращаем состояние изменения элемента
                    Product.products.RemoveAt(parent.change_index); // Удаляем старый элемент
                    parent.listView1.Items.RemoveAt(parent.change_index); // и из таблицы тоже
                    Product.products.Insert(parent.change_index, new_product);
                    ListViewItem new_item = new ListViewItem(maskedTextBox1.Text);
                    new_item.SubItems.Add(maskedTextBox2.Text);
                    new_item.SubItems.Add(maskedTextBox3.Text);
                    parent.listView1.Items.Insert(parent.change_index, new_item);
                }
                // Закрытие окна
                Close();
            }
            else
            {
                MessageBox.Show("Вы не заполнили полностью нужные поля");
            }
        }
        /// <summary>
        /// Нажатие на кнопку "Отмена"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}