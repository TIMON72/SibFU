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
    public partial class Form1 : Form
    {
        ViewModel viewModel = ViewModel.GetObjectOfViewModel();
        int id;
        bool identification = false;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Нажатие кнопки раздела "Идентификация"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Индетификация
            string text = viewModel.Identification(maskedTextBox1.Text);
            // Вывод имеющихся книг
            if (text == "Идентификация прошла успешно")
            {
                dataGridView1.Rows.Clear(); // Очистка таблицы книг читателя
                identification = true;
                MessageBox.Show(text);
                id = Convert.ToInt32(maskedTextBox1.Text);
                int numberOfBooks = viewModel.GetCountOfBooksOfReader(id);
                if (numberOfBooks != -1)
                {
                    for (int i = 0; i < numberOfBooks; i++)
                    {
                        dataGridView1.Rows.Add();
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            string value = viewModel.GetFieldOfBook(i, id, j);
                            dataGridView1[j, i].Value = value;
                        }
                    }
                }
            }
            else
            {
                identification = false;
                MessageBox.Show(text);
            }
        }
        /// <summary>
        /// Нажатие кнопки раздела: "Заполнить БД из шаблона"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string result = viewModel.FillTestData();
            if (result == "Успех")
            {       
                for (int i = 0; i < 5; i++)
                {
                    dataGridView2.Rows.Add();
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        string value = viewModel.GetFieldOfBook(i, j);
                        dataGridView2[j, i].Value = value;
                    }
                }
            }
            else
            {
                MessageBox.Show(result);
            }
        }
        /// <summary>
        /// Нажатие кнопки "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (!identification)
            {
                MessageBox.Show("Ошибка авторизации пользователя");
                return;
            }
            if (dataGridView2.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("Выбранная книга не существует");
                return;
            }
            string ID_book = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            int[] result = viewModel.AddBookToReader(id, ID_book);
            int countBookOfReader = result[0];
            int countBook = result[1];
            int position = result[2];
            // Если книг больше нет в наличии
            if (countBookOfReader == 0)
            {
                MessageBox.Show("Книги #" +
                    dataGridView2.CurrentRow.Cells[0].Value.ToString() +
                    " нет в наличии");
            }
            // Если книги не было у читателя
            else if (countBookOfReader == 1)
            {
                int numberOfBooks = viewModel.GetCountOfBooksOfReader(id);
                dataGridView1.Rows.Add();
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    string value = viewModel.GetFieldOfBook(numberOfBooks - 1, id, i);
                    dataGridView1[i, numberOfBooks - 1].Value = value;
                }
                dataGridView2.CurrentRow.Cells[5].Value = countBook.ToString();
            }
            // Если такая книга есть у читателя
            else if (countBookOfReader > 1)
            {
                dataGridView1[5, position].Value = countBookOfReader.ToString();
                dataGridView2.CurrentRow.Cells[5].Value = countBook.ToString();
            }
            // Если возникла какая-либо ошибка при добавлении
            else
            {
                MessageBox.Show("Ошибка добавления книги " + 
                    dataGridView2.CurrentRow.Cells[0].Value.ToString() + 
                    " читателю " + id.ToString());
            }
        }
        /// <summary>
        /// Нажатие кнопки "Убрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (!identification)
            {
                MessageBox.Show("Ошибка авторизации пользователя");
                return;
            }
            if (dataGridView1.CurrentCell.Value == null)
            {
                MessageBox.Show("Выбранная книга не существует");
                return;
            }
            string ID_book = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int[] result = viewModel.DeleteBookOfReader(id, ID_book);
            int countBookOfReader = result[0];
            int countBook = result[1];
            int position = result[2];
            // Если выбранная книга у читателя в нескольких экземплярах
            if (countBookOfReader > 0)
            {
                dataGridView1.CurrentRow.Cells[5].Value = countBookOfReader.ToString();
                dataGridView2[5, position].Value = countBook.ToString();
            }
            // Если выбранная книга у читателя в единственном экземпляре
            else if (countBookOfReader == 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                dataGridView2[5, position].Value = countBook.ToString();
            }
            // Если возникла какая-либо ошибка при удалении
            else
            {
                MessageBox.Show("Ошибка удаления книги");
            }
        }
    }
}
