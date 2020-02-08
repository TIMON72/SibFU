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
        bool flag = false;
        static int size = 9;
        char[,] alphabet = new char[size, size];
        string delimiter = "|";
        char[] key;
        string text;
 
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Поиск символа в char[,] alphabet
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private char FindCharacter(int[] position)
        {
            return alphabet[position[0], position[1]];
        }
        /// <summary>
        /// Поиск позиции символа в char[,] alphabet
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private int[] FindCharacterPosition(char ch)
        {
            int[] result = new int[2];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (ch == alphabet[i, j])
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            result[0] = -1;
            result[1] = -1;
            return result;
        }
        /// <summary>
        /// Ф-ция сопоставления и добавления символа в алфавит
        /// </summary>
        /// <param name="ch"></param>
        private void CheckForCharacterInAlphabet(char ch)
        {
            int a = -1;
            int b = -1;
            // Выполняем поиск символа в алфавите
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    a = i;
                    b = j;
                    // Если такой символ есть, то прекращаем поиск
                    if (alphabet[i, j] == ch)
                    {
                        return;
                    }
                    // Если символ в массиве не задан, то добавляем символ в алфавит и прекращаем поиск
                    if (alphabet[i, j] == 0)
                    {
                        alphabet[a, b] = ch;
                        return;
                    }
                }
            // Если сравниваемый символ отсутствует в алфавите, то добавляем его туда
            alphabet[a, b] = ch;
        }
        /// <summary>
        /// Ф-ция преобразования текста перед шифрованием
        /// - разбитие на пары и поиск пар с одинаковыми символами для последующей трансформации
        /// - если в последней паре один символ, то добавление второго символа
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string FindMatchesInText(string text)
        {
            for (int i = 0, j = 1; i < text.Length; i = i + 2, j = j + 2)
            {
                // Если после i-го символа отсутствует j-ый (у последнего символа нет пары), то добавляем "."
                if (j == text.Length)
                {
                    text = text + delimiter;
                    return text;
                }
                // Если символы совпали, то заменяем на "."
                if (text.Substring(i, 1) == text.Substring(j, 1))
                {
                    text = text.Insert(j, delimiter);
                }
            }
            return text;
        }
        /// <summary>
        /// Ф-ция шифрования текста
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string Encryption(string text)
        {
            string result = "";
            for (int i = 0, j = 1; i < text.Length; i = i + 2, j = j + 2)
            {
                char firstCh = Convert.ToChar(text.Substring(i, 1));
                int[] firstChPos = FindCharacterPosition(firstCh); // [0] - строка, [1] - столбец
                char secondCh = Convert.ToChar(text.Substring(j, 1));
                int[] secondChPos = FindCharacterPosition(secondCh); // [0] - строка, [1] - столбец
                // Если символы находятся на одной строке в таблице (шаг 2)
                if (firstChPos[0] == secondChPos[0])
                {
                    // Если первый символ находится в крайнем столбце, то присваиваем значения символа в первом столбце
                    if (firstChPos[1] == size - 1)
                    {
                        firstChPos[1] = 0;
                    }
                    // Иначе смещаем на один столбец вправо
                    else
                    {
                        firstChPos[1]++;
                    }
                    // Если второй символ находится в крайнем столбце, то присваиваем значения символа в первом столбце
                    if (secondChPos[1] == size - 1)
                    {
                        secondChPos[1] = 0;
                    }
                    // Иначе смещаем на один столбец вправо
                    else
                    {
                        secondChPos[1]++;
                    }
                    firstCh = FindCharacter(firstChPos);
                    secondCh = FindCharacter(secondChPos);
                }
                // Если символы находятся на одном столбце в таблице (шаг 3)
                else if (firstChPos[1] == secondChPos[1])
                {
                    // Если первый символ находится на нижней строке, то присваиваем значения символа на первой строке
                    if (firstChPos[0] == size - 1)
                    {
                        firstChPos[0] = 0;
                    }
                    // Иначе смещаем на строку вниз
                    else
                    {
                        firstChPos[0]++;
                    }
                    // Если второй символ находится на нижней строке, то присваиваем значения символа на первой строке
                    if (secondChPos[0] == size - 1)
                    {
                        secondChPos[0] = 0;
                    }
                    // Иначе смещаем на строку вниз
                    else
                    {
                        secondChPos[0]++;
                    }
                    firstCh = FindCharacter(firstChPos);
                    secondCh = FindCharacter(secondChPos);
                }
                // Если символы находятся на разных столбцах и строках (шаг 4), то замещаем по "прямоугольнику" (см. алгоритм Плейфера)
                else
                {
                    int temp = firstChPos[0];
                    firstChPos[0] = secondChPos[0];
                    secondChPos[0] = temp;
                    firstCh = FindCharacter(firstChPos);
                    secondCh = FindCharacter(secondChPos);
                }
                result = result + firstCh.ToString() + secondCh.ToString();
            }
            return result;
        }
        /// <summary>
        /// Ф-ция расшифрования текста
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string Decryption(string text)
        {
            string result = "";
            for (int i = 0, j = 1; i < text.Length; i = i + 2, j = j + 2)
            {
                char firstCh = Convert.ToChar(text.Substring(i, 1));
                int[] firstChPos = FindCharacterPosition(firstCh); // [0] - строка, [1] - столбец
                char secondCh = Convert.ToChar(text.Substring(j, 1));
                int[] secondChPos = FindCharacterPosition(secondCh); // [0] - строка, [1] - столбец
                // Если символы находятся на одной строке в таблице (шаг 2)
                if (firstChPos[0] == secondChPos[0])
                {
                    // Если первый символ находится в первом столбце, то присваиваем значение символа в крайнем столбце
                    if (firstChPos[1] == 0)
                    {
                        firstChPos[1] = size - 1;
                    }
                    // Иначе смещаем на один столбец влево
                    else
                    {
                        firstChPos[1]--;
                    }
                    // Если второй символ находится в первом столбце, то присваиваем значение символа в крайнем столбце
                    if (secondChPos[1] == 0)
                    {
                        secondChPos[1] = size - 1;
                    }
                    // Иначе смещаем на один столбец влево
                    else
                    {
                        secondChPos[1]--;
                    }
                    firstCh = FindCharacter(firstChPos);
                    secondCh = FindCharacter(secondChPos);
                }
                // Если символы находятся на одном столбце в таблице (шаг 3)
                else if (firstChPos[1] == secondChPos[1])
                {
                    // Если первый символ находится на первой строке, то присваиваем значение символа на крайней строке
                    if (firstChPos[0] == 0)
                    {
                        firstChPos[0] = size - 1;
                    }
                    // Иначе смещаем на строку вверх
                    else
                    {
                        firstChPos[0]--;
                    }
                    // Если второй символ находится на первой строке, то присваиваем значение символа на крайней строке
                    if (secondChPos[0] == 0)
                    {
                        secondChPos[0] = size - 1;
                    }
                    // Иначе смещаем на строку вверх
                    else
                    {
                        secondChPos[0]--;
                    }
                    firstCh = FindCharacter(firstChPos);
                    secondCh = FindCharacter(secondChPos);
                }
                // Если символы находятся на разных столбцах и строках (шаг 4), то замещаем по "прямоугольнику" (см. алгоритм Плейфера)
                else
                {
                    int temp = firstChPos[0];
                    firstChPos[0] = secondChPos[0];
                    secondChPos[0] = temp;
                    firstCh = FindCharacter(firstChPos);
                    secondCh = FindCharacter(secondChPos);
                }
                result = result + firstCh.ToString() + secondCh.ToString();
            }
            result = result.Replace(delimiter, "");
            return result;
        }
        /// <summary>
        /// нажатие на кнопку "Задействовать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            // Если не заполнено поле "Ключ"
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите ключ");
                return;
            }
            // Очистка данных и создание скелета dataGridView1
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            alphabet = new char[size, size];
            // Присвоение значений необходимым переменным
            key = textBox1.Text.ToLower().ToCharArray();
            // Формируем таблицу алфавита
            alphabet[0, 0] = key[0];
            for (int i = 1; i < key.Length; i++)
            {
                CheckForCharacterInAlphabet(key[i]);
            }
            char[] engAlphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            for (int i = 0; i < engAlphabet.Length; i++)
            {
                CheckForCharacterInAlphabet(engAlphabet[i]);
            }
            char[] rusAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя., !?".ToCharArray();
            for (int i = 0; i < rusAlphabet.Length; i++)
            {
                CheckForCharacterInAlphabet(rusAlphabet[i]);
            }
            char[] symbAlphabet = "@#$%^&*()_+-=~`/|".ToCharArray();
            for (int i = 0; i < symbAlphabet.Length; i++)
            {
                CheckForCharacterInAlphabet(symbAlphabet[i]);
            }
            // Выводим алфавит на dataGridView1
            for (int i = 0; i < size; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
                dataGridView1.Columns[i].Width = 20;
                dataGridView1.Rows[i].Height = 20;
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = alphabet[i, j].ToString();
                }
            }
            flag = true;
        }
        /// <summary>
        /// Нажатие на кнопку "Зашифровать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                MessageBox.Show("Алфавит не составлен для корректного шифрования текста");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Вы ничего не ввели в поле текста для шифрования");
                return;
            }
            text = textBox2.Text.ToLower();
            // Сравниваем в тексте символы "по парам" и производим необходимое форматирование (шаг 1)
            text = FindMatchesInText(text);
            // Шифруем текст (шаг 2, 3, 4)
            text = Encryption(text);
            // Выводим на textBox3
            textBox3.Text = text;
        }
        /// <summary>
        /// Нажатие на кнопку "Расшифровать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Тут нечего дешифровывать");
                return;
            }
            text = textBox3.Text.ToLower();
            // Расшифруем текст (шаг 2, 3, 4)
            text = Decryption(text);
            // Выводим на textBox4
            textBox4.Text = text;
        }
    }
}
