using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.classes;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int step11 = 0; // счетчик строк 1-ой колонки GridView1
        int step12 = 0; // счетчик строк 2-ой колонки GridView1
        int step13 = 0; // счетчик строк 3-ей колонки GridView1
        int step = 0; // Счетчик индексов списка transports
        
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Нажатие на кнопку "Добавить" автобусов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "")
            {
                MessageBox.Show("Заполните поле");
                return;
            }
            TBus newBus = new TBus("20 мест", "120 км/ч", "5 тонн", "6 колес");
            // Добавление ключа
            Key newKey = new Key();
            newKey.keyOfTable = Convert.ToString(1) + Convert.ToString(step11);
            newKey.keyOfList = step;
            Key.keys.Add(newKey);
            // Добавление объекта в таблицу
            if (step11 == dataGridView1.Rows.Count-1)
            {
                dataGridView1.Rows.Add();             
            }
            dataGridView1[0, step11].Value = maskedTextBox1.Text;
            step11++;
            step++;
        }
        /// <summary>
        /// Нажатие на кнопку "Добавить" поездов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text == "")
            {
                MessageBox.Show("Заполните поле");
                return;
            }
            TTrain newTrain = new TTrain("60 мест", "80 км/ч", "30 тонн", "зеленый");
            // Добавление ключа
            Key newKey = new Key();
            newKey.keyOfTable = Convert.ToString(2) + Convert.ToString(step12);
            newKey.keyOfList = step;
            Key.keys.Add(newKey);
            // Добавление объекта в таблицу
            if (step12 == dataGridView1.Rows.Count - 1)
            {
                dataGridView1.Rows.Add();
            }
            dataGridView1[1, step12].Value = maskedTextBox2.Text;
            step12++;
            step++;
        }
        /// <summary>
        /// Нажатие на кнопку "Добавить" самолетов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox3.Text == "")
            {
                MessageBox.Show("Заполните поле");
                return;
            }
            TPlane newPlane = new TPlane("200 мест", "200 мест", "150 тонн", "керосин");
            // Добавление ключа
            Key newKey = new Key();
            newKey.keyOfTable = Convert.ToString(3) + Convert.ToString(step13);
            newKey.keyOfList = step;
            Key.keys.Add(newKey);
            // Добавление объекта в таблицу
            if (step13 == dataGridView1.Rows.Count - 1)
            {
                dataGridView1.Rows.Add();
            }
            dataGridView1[2, step13].Value = maskedTextBox3.Text;
            step13++;
            step++;
        }
        /// <summary>
        /// Событие при выделении какой-либо ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Получение индекса ячейки, задание уникального ключа для нее для поиска и поиск в списке транспорта
            int row = dataGridView1.CurrentCell.RowIndex;
            int column = dataGridView1.CurrentCell.ColumnIndex + 1;
            string x = Convert.ToString(column) + Convert.ToString(row);
            Key key = Key.keys.Find(searchingKey => searchingKey.keyOfTable == x);
            int index = key.keyOfList;
            TTransport selectedTransport = TTransport.GetTransport(index);
            // Заполнение таблицы свойств объекта
            if (index == -1)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add(4);
                return;
            }
            string result = selectedTransport.GetObjectInformation(index);
            dataGridView2[0, 0].Value = "Скорость";
            dataGridView2[1, 0].Value = selectedTransport.speed;
            dataGridView2[0, 1].Value = "Вес";
            dataGridView2[1, 1].Value = selectedTransport.weight;
            dataGridView2[0, 2].Value = "Число сидений";
            dataGridView2[1, 2].Value = selectedTransport.numberOfSeats;
            if (result == "bus")
            {
                dataGridView2[0, 3].Value = "Число колес";
                TBus bus = (TBus)TTransport.GetTransport(index);
                dataGridView2[1, 3].Value = bus.numberOfWheels;
            }
            else if (result == "train")
            {
                dataGridView2[0, 3].Value = "Цвет";
                TTrain train = (TTrain)TTransport.GetTransport(index);
                dataGridView2[1, 3].Value = train.color;
            }
            else if (result == "plane")
            {
                dataGridView2[0, 3].Value = "Тип топлива";
                TPlane plane = (TPlane)TTransport.GetTransport(index);
                dataGridView2[1, 3].Value = plane.typeOfFuel;
            }
        }
        /// <summary>
        /// Событие запуска формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(4);
        }
    }
}
