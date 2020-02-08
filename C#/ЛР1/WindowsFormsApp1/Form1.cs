using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int Factorial(int n)
        {
            int result = 1;
            int i = 1;
            while (i <= n)
            {
                result = result * i;
                i++;
            }
            return result;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            double x_start = Convert.ToDouble(maskedTextBoxXStart.Text); // х начальное
            double x_end = Convert.ToDouble(maskedTextBoxXEnd.Text); // x конечное
            double dx = Convert.ToDouble(maskedTextBoxDX.Text); // шаг
            double accuracy = Convert.ToDouble(maskedTextBoxAccuracy.Text); // точность
            double result = 0;
            int counter = 1; // счетчик
            // Очистка данных и создание скелета dataGridView1
            dataGridViewResults.Rows.Clear();
            dataGridViewResults.Columns.Clear();
            dataGridViewResults.Columns.Add("x", "X");
            dataGridViewResults.Columns.Add("f", "F(X)");
            dataGridViewResults.Columns.Add("result", "Результат");
            dataGridViewResults.Columns.Add("n", "Кол-во членов ряда");
            dataGridViewResults.Rows.Add();
            dataGridViewResults.Rows[0].Height = 20;
            // Вычисление функции Тейлора
            int row = 0;
            for (double x = x_start; x <= x_end; x = x + dx)
            {
                double prev_f;
                double f = 0;
                int n = 0;
                do
                {
                    prev_f = f;
                    f = (Math.Pow(-1, n) * Math.Pow(x, 2 * n)) / Factorial(2 * n);
                    result += f;
                    counter++;
                    n++;
                } while (Math.Abs(f - prev_f) > accuracy && n < 10);
                dataGridViewResults.Rows[row].Cells[0].Value = x.ToString();
                dataGridViewResults.Rows[row].Cells[1].Value = f.ToString();
                dataGridViewResults.Rows[row].Cells[2].Value = result.ToString();
                dataGridViewResults.Rows[row].Cells[3].Value = n.ToString();
                dataGridViewResults.Rows.Add();
                row++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBoxXStart.Text = Convert.ToString(1);
            maskedTextBoxXEnd.Text = Convert.ToString(3);
            maskedTextBoxDX.Text = Convert.ToString(1);
            maskedTextBoxAccuracy.Text = Convert.ToString(0.01);
        }
    }
}
