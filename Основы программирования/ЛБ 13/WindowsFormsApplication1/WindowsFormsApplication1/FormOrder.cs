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
    public partial class FormOrder : Form
    {
        public FormOrder()
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
                (maskedTextBox2.Text != "  .  .") &&
                (maskedTextBox3.Text != "  .  ."))
            {
                // Добавляем в список
                Order new_order = new Order();
                new_order.name = maskedTextBox1.Text;
                new_order.delivery_time = maskedTextBox2.Text;
                new_order.registration_date = maskedTextBox3.Text;
                FormProgram parent = Owner as FormProgram; // Создаем объект родителя
                // Если это добавление нового элемента
                if (!parent.change_bool)
                {
                    Order.orders.Add(new_order);
                    ListViewItem new_item = new ListViewItem(maskedTextBox1.Text);
                    new_item.SubItems.Add(maskedTextBox2.Text);
                    new_item.SubItems.Add(maskedTextBox3.Text);
                    parent.listView2.Items.Add(new_item);
                }
                // Если это изменение элемента
                else
                {
                    parent.change_bool = false; // Возвращаем состояние изменения элемента
                    Order.orders.RemoveAt(parent.change_index); // Удаляем старый элемент
                    parent.listView2.Items.RemoveAt(parent.change_index); // и из таблицы тоже
                    Order.orders.Insert(parent.change_index, new_order);
                    ListViewItem new_item = new ListViewItem(maskedTextBox1.Text);
                    new_item.SubItems.Add(maskedTextBox2.Text);
                    new_item.SubItems.Add(maskedTextBox3.Text);
                    parent.listView2.Items.Insert(parent.change_index, new_item);
                }
                // Закрываем окно
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