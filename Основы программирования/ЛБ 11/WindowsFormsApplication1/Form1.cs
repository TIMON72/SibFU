using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Вывод файлов и папок на окно при нажатии кнопки "Запуск"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Очистка richTextBox и инициализация списков
            richTextBox1.Clear();
            richTextBox2.Clear();
            List<string> list_of_folders = new List<string>();
            List<Info> list_of_files = new List<Info>();
            // Вывод в richTextBox списка папок
            Info.ListsOfFoldersAndFiles();
            textBox1.Text = Buffer.path_of_directory; // Заносим путь к каталогу в TextBox1
            if (Buffer.list_of_folders.Count == 0)
            {
                richTextBox1.AppendText(string.Format("Папки отсутствуют"));
            }
            else
            {
                for (int i = 0; i < Buffer.list_of_folders.Count; i++)
                {
                    richTextBox1.AppendText(string.Format(Buffer.list_of_folders[i] + "\n"));
                }
            }
            // Вывод в richTextBox списка файлов
            if (Buffer.list_of_files.Count == 0)
            {
                richTextBox2.AppendText(string.Format("Файлы отсутствуют"));
            }
            else
            {
                richTextBox2_Print();
            }
        }
        /// <summary>
        /// Ф-ция вывода списка файлов в richTextBox2
        /// </summary>
        private void richTextBox2_Print()
        {
            richTextBox2.Clear(); // Очистка richTextBox2
            richTextBox2.SelectionColor = Color.Red;
            // Защита от сортировки, если не выбран каталог
            if (Buffer.path_of_directory == null)
            {
                richTextBox2.AppendText("Вы не выбрали каталог, чтоб что-то сортировать");
                return;
            }
            richTextBox2.AppendText(string.Format("Имя".PadRight(56) +
                    "Размер".PadRight(16) + "Время создания".PadRight(31)
                    + "Атрибуты" + "\n\n"));
            for (int i = 0; i < Buffer.list_of_files.Count; i++)
            {
                // Если файл содержит пробелы, то добавить [!]
                string name;
                if (Buffer.list_of_files[i].name.Contains(" "))
                {
                    name = "[!]" + Buffer.list_of_files[i].name;
                }
                else
                {
                    name = Buffer.list_of_files[i].name;
                }
                // Выравнивание по столбцам
                richTextBox2.AppendText(string.Format("{0, -55} {1, -15} {2, -30:F} {3}\n",
                name,
                Buffer.list_of_files[i].size + " KB",
                Buffer.list_of_files[i].time_of_last_access,
                Buffer.list_of_files[i].attributes));
            }
        }
        /// <summary>
        /// Сортировка от А до Я при нажатии кнопки сортировки по "Имени"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Click -= button2_Click;
            button2.Click += button2_Click2;
            Sort.ByNameUp(); // Сортировка по имени
            richTextBox2_Print(); // Вывод на richTextBox2
        }
        /// <summary>
        /// Сортировка от Я до А при нажатии кнопки сортировки по "Имени"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click2(object sender, EventArgs e)
        {
            button2.Click -= button2_Click2;
            button2.Click += button2_Click;
            Sort.ByNameDown(); // Сортировка по имени
            richTextBox2_Print(); // Вывод на richTextBox2
        }
        /// <summary>
        /// Сортировка по размеру по возрастанию при нажатии кнопки "Размер"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Click -= button3_Click;
            button3.Click += button3_Click2;
            Sort.BySizeUp();
            richTextBox2_Print(); // Вывод на richTextBox2
        }
        /// <summary>
        /// Сортировка по размеру по возрастанию при нажатии кнопки "Размер"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click2(object sender, EventArgs e)
        {
            button3.Click -= button3_Click2;
            button3.Click += button3_Click;
            Sort.BySizeDown();
            richTextBox2_Print(); // Вывод на richTextBox2
        }
        /// <summary>
        /// Сортировка по дате последнего доступа при нажатии "Дате" (от раннего к позднему)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            button4.Click -= button4_Click;
            button4.Click += button4_Click2;
            Sort.ByDateUp();
            richTextBox2_Print(); // Вывод на richTextBox2
        }
        /// <summary>
        /// Сортировка по дате последнего доступа при нажатии "Дате" (от позднего к раннему)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click2(object sender, EventArgs e)
        {
            button4.Click -= button4_Click2;
            button4.Click += button4_Click;
            Sort.ByDateDown();
            richTextBox2_Print(); // Вывод на richTextBox2
        }
        /// <summary>
        /// Сортировка по атрибуту "Archive" при нажатии кнопки "Атрибутам"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            button5.Click -= button5_Click;
            button5.Click += button5_Click2;
            Sort.ByAttribute_Archive();
            richTextBox2_Print();
        }
        /// <summary>
        /// Сортировка по атрибуту "Hidden" при нажатии кнопки "Атрибутам"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click2(object sender, EventArgs e)
        {
            button5.Click -= button5_Click2;
            button5.Click += button5_Click3;
            Sort.ByAttribute_Hidden();
            richTextBox2_Print();

        }
        /// <summary>
        ///  Сортировка по атрибуту "ReadOnly" при нажатии кнопки "Атрибутам"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click3(object sender, EventArgs e)
        {
            button5.Click -= button5_Click3;
            //button5.Click -= button5_Click;
            //button5.Click -= button5_Click2;
            button5.Click += button5_Click4;
            Sort.ByAttribute_ReadOnly();
            richTextBox2_Print();
        }
        /// <summary>
        ///  Сортировка по атрибуту "System" при нажатии кнопки "Атрибутам"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click4(object sender, EventArgs e)
        {
            button5.Click -= button5_Click4;
            button5.Click += button5_Click;
            Sort.ByAttribute_System();
            richTextBox2_Print();
        }
        /// <summary>
        /// Сброс сортировки (вернуть все так, как было до сортировки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    }
}
