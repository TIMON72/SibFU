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
        /// Обработчик нажатия клавиш в textBox2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrorProvider error = new ErrorProvider();
            error.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57)) // 8 - BackSpace
            {
                e.Handled = true;
                error.SetError(textBox2, "Вводите только числа");
            }
        }
        /// <summary>
        /// Обработчик нажатия клавиш в textBox3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrorProvider error = new ErrorProvider();
            error.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57)) // 8 - BackSpace
            {
                e.Handled = true;
                error.SetError(textBox3, "Вводите только числа");
            }
        }
        /// <summary>
        /// Нажатие на кнопку "ОК"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != string.Empty) &&
                (textBox2.Text != string.Empty) &&
                (textBox3.Text != string.Empty))
            {
                Product new_product = new Product();
                new_product.designation = textBox1.Text;
                new_product.price = textBox2.Text;
                new_product.weight = textBox3.Text;
                Product.products.Add(new_product);
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