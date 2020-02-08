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
        List<int> shiftList = new List<int>(); // Список смещений
        Dictionary<int, char> alphabet = new Dictionary<int, char>(); // Алфавит запроса
        char[] request; // Массив символов запроса
        int lengthOfRequest; // Определение длины текста запроса

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Ф-ция формирования списка смещений
        /// </summary>
        void FormationOfListOfShifts(string requestStr)
        {
            shiftList.Clear(); // Очистка списка смещений
            alphabet.Clear(); // Очистка алфавита запроса
            request = requestStr.ToCharArray();
            lengthOfRequest = request.Count();
            // Заполнение алфивита и списка смещений в обратном порядке
            for (int i = lengthOfRequest - 1, j = 0; i >= 0; i--, j++)
            {
                // Получаем значение ключа алфавита через поиск первого вхождения символа
                int resultKey;
                try
                {
                    resultKey = alphabet.First(x => x.Value == request[i]).Key;
                }
                catch (InvalidOperationException)
                {
                    resultKey = -1;
                }
                // Если есть символ в алфавите, то добавляем значение в таблицу смещений
                if (resultKey != -1)
                {
                    shiftList.Insert(0, resultKey);
                }
                // Если нет символа в алфавите, то добавляем его в алфавит
                else
                {
                    alphabet.Add(j, request[i]);
                    shiftList.Insert(0, j);
                }
            }
            // Замена ключа "0" в списке смещений у последнего символа запроса
            int firstEntryOfIndex = -1;
            // Если запрос состоит из одного символа, то присваиваем "1" и завершаем формирование списка смещений
            if (lengthOfRequest == 1)
            {
                shiftList[0] = 1;
                
            }
            // Если запрос из более, чем один символ, то
            else
            {
                // Определение индекса первого вхождения символа, схожего с конечным в запросе
                for (int i = lengthOfRequest - 2; i >= 0; i--)
                {
                    // Если таков символ есть, то записываем его индекс
                    if (request[i] == request[lengthOfRequest - 1])
                    {
                        firstEntryOfIndex = i;
                        break;
                    }
                }
                // Если такой символ существует, то заменяем все ключи в списке смещений этого символа на вычисленное значение
                if (firstEntryOfIndex != -1)
                {
                    for (int i = lengthOfRequest - 1; i >= 0; i--)
                    {
                        // Если таков символ есть, то записываем его индекс
                        if (request[i] == request[lengthOfRequest - 1])
                        {
                            shiftList[i] = lengthOfRequest - 1 - firstEntryOfIndex;
                        }
                    }
                }
                // Иначе заменяем значение последнего элемента списка смещений на значение длины строки запроса
                else
                {
                    shiftList[shiftList.Count - 1] = shiftList.Count;
                }
            }
            // Вывод списка смещений на richTextBox2
            richTextBox2.Text = richTextBox2.Text + "Список смещений для запроса: ";
            for (int i = 0; i < shiftList.Count; i++)
            {
                richTextBox2.Text = richTextBox2.Text + shiftList[i].ToString() + " ";
            }
            richTextBox2.Text = richTextBox2.Text + "\n";
        }
        /// <summary>
        /// Ф-ция поиска совпадений в тексте из запроса
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="text"></param>
        void SearchCoincidencesWithRequest(int currentPosition, string text)
        {
            int shift = lengthOfRequest - 1;
            int previousPosition = currentPosition;
            for (int j = lengthOfRequest - 1; j >= 0; j--)
            {
                // Если символ текста совпал с текущим символом запроса, то переходим к сравнению следующего символа текста и запроса
                if (text.Substring(previousPosition, 1) == request[j].ToString())
                {
                    previousPosition--;
                    shift = j - 1;
                }
                // Если есть несоответствие, то сдвигаем каретку на значение из shiftList и выполняем рекурсию
                else
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        // Если сравниваемый символ текста имеется в запросе, то присваиваем n позицию в shiftList
                        if (text.Substring(previousPosition, 1) == request[k].ToString())
                        {
                            shift = k;
                            break;
                        }
                    }
                    // Если конец текста не достигнут, то продолжаем выполнять алгоритм
                    currentPosition = currentPosition + shiftList[shift]; // Выполняем перевод каретки
                    if (currentPosition <= text.Length - 1)
                    {
                        SearchCoincidencesWithRequest(currentPosition, text); // Вызываем рекрсию
                        return;
                    }
                    // Иначе заканчиваем алгоритм
                    else
                    {
                        return;
                    }    
                }
            }
            // Вывод результатов поиска на richTextBox2
            int start = previousPosition + 1;
            richTextBox1.SelectionStart = start;
            richTextBox1.SelectionLength = lengthOfRequest;
            richTextBox1.SelectionBackColor = Color.Yellow;
            richTextBox1.SelectionLength = 0;
            int end = start + request.Length - 1;
            richTextBox2.Text = richTextBox2.Text + "Найдено совпадение на позиции " + start.ToString() + ", " + end.ToString() + "\n";
            // Если конец текста не достигнут, то продолжаем выполнять алгоритм
            currentPosition = currentPosition + shiftList[lengthOfRequest - 1]; // Выполняем перевод каретки по значению смещения последнего символа запроса
            if (currentPosition <= text.Length - 1)
            {
                SearchCoincidencesWithRequest(currentPosition, text); // Вызываем рекурсию
                return;
            }
            // Иначе заканчиваем алгоритм
            else
            {
                return;
            }
        }
        /// <summary>
        /// Действие при нажатии кнопки "Поиск"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            string requestStr = textBox1.Text;
            // Если не заполнены нужные поля, то ничего не делать
            if (richTextBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Заполните необходимые поля");
                return;
            }
            // Если выбрано "Не учитывать регистр"
            if (checkBox1.Checked)
            {
                text = text.ToLower();
                requestStr = requestStr.ToLower();
            }
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = text.Length;
            richTextBox1.SelectionBackColor = Color.White;
            richTextBox2.Clear(); // Очистка richTextBox2
            FormationOfListOfShifts(requestStr); // Формирование списка смещений
            SearchCoincidencesWithRequest(lengthOfRequest - 1, text); // Поиск совпадающих фрагментов текста с запросом
        }
        /// <summary>
        /// Действие при нажатии кнопки "Тест"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Одно из наиболее часто встречающихся в про­граммировании действий – " +
                "поиск.Он же представ­ляет собой идеальную задачу, на которой можно ис­пытывать различные " +
                "структуры данных по мере их появления. Существует несколько основных «вариа­ций этой темы», " +
            "и для них создано много различных алгоритмов.В данной лекции будет рассмотрен специфический поиск, " +
            "так называемый поиск строки. Его можно определить следующим образом.";
        }
    }
}
