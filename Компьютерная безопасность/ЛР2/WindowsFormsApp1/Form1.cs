using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Threading;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static BigInteger N;
        static BigInteger S;
        static BigInteger E;
        static Stopwatch sw = Stopwatch.StartNew();

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Ф-ция генерации случайного числа типа Big Integer в диапазоне 100000000100000000 - 31000000031000000000
        /// </summary>
        /// <returns></returns>
        private static BigInteger RandomGenerateBigInteger()
        {
            Random random = new Random();
            BigInteger value = 0;
            string valueString;
            valueString = Convert.ToString(random.Next(100000000, 310000000));
            valueString = valueString + Convert.ToString(random.Next(100000000, 310000000));
            value = BigInteger.Parse(valueString);
            return value;
        }
        /// <summary>
        /// Ф-ция генерации случайного числа типа Big Integer в диапазоне 3 - 310000000
        /// </summary>
        /// <returns></returns>
        private static BigInteger RandomGenerateBigIntegerForFerma()
        {
            Random random = new Random();
            BigInteger value = 0;
            string valueString;
            valueString = Convert.ToString(random.Next(3, 310000000));
            value = BigInteger.Parse(valueString);
            return value;
        }
        /// <summary>
        /// Ф-ция теста Миллера-Рабина на простоту
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool MillerRabinTest(BigInteger value)
        {
            Thread.Sleep(10);
            long totalWitness = 15;
            BigInteger[] randomWitness = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 51001, 351011 };
            BigInteger oddMultiplier;
            long bitLength;
            long i, j;
            BigInteger result;
            oddMultiplier = value - 1;
            bitLength = 0;
            while (oddMultiplier % 2 == 0)
            {
                oddMultiplier /= 2;
                bitLength++;
            }
            for (i = 0; i < totalWitness; i++)
            {
                if (randomWitness[i] == value)
                    return true;
                result = BigInteger.ModPow(randomWitness[i], oddMultiplier, value);
                if (result == 1)
                    continue;
                if (result == value - 1)
                    continue;
                for (j = 1; j <= bitLength; j++)
                {
                    result = BigInteger.ModPow(result, 2, value);
                    if (result == value - 1)
                        break;
                }
                if (result != value - 1)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Ф-ция поиска НОД у двух чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static BigInteger GCB(BigInteger a, BigInteger b)
        {
            if (b == 0)
                return a;
            return GCB(b, a % b);
        }
        /// <summary>
        /// Ф-ция проверки на простоту
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsSimple(BigInteger value)
        {
            BigInteger end = (BigInteger)Math.Exp(BigInteger.Log(value) / 2);
            for (BigInteger i = 3; i < end; i += 2)
            {
                if (value % i == 0)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Ф-ция теста Ферма на простоту
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static bool FermaTest(BigInteger value)
        {
            for (int i = 0; i < 1000; i++)
            {
                BigInteger a;
                do
                {
                    a = RandomGenerateBigIntegerForFerma();
                } while (a > value - 1);
                while (GCB(a, value) > 1)
                {
                    do
                    {
                        a = RandomGenerateBigIntegerForFerma();
                    } while (a > value - 1);
                }
                if (BigInteger.ModPow(a, value - 1, value) != 1)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Действия при нажатии на кнопку "Создание октрытого и закрытого ключей"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Enabled = false;
            // Вычисляем число P
            BigInteger p;
            sw.Restart();
            do
            {
                p = RandomGenerateBigInteger();
                if (p.IsEven)
                {
                    p--;
                }
                if (FermaTest(p))
                {
                    break;
                }
            } while (true);
            sw.Stop();
            textBoxTimeP.Text = sw.ElapsedMilliseconds + " ms";
            textBoxP.Text = p.ToString();
            Update();
            // Вычисляем число Q
            BigInteger q;
            sw.Restart();
            do
            {
                q = RandomGenerateBigInteger();
                if (q.IsEven)
                {
                    q--;
                }
                if (MillerRabinTest(q))
                {
                    break;
                }
            } while (true);
            sw.Stop();
            textBoxTimeQ.Text = sw.ElapsedMilliseconds + " ms";
            textBoxQ.Text = q.ToString();
            Update();
            // Вычисляем число N
            BigInteger n = BigInteger.Multiply(p, q);
            textBoxN.Text = n.ToString();
            textBoxNLength.Text = textBoxN.Text.Length.ToString();
            Update();
            // Вычисляем число D
            BigInteger d = (p - 1) * (q - 1);
            textBoxD.Text = d.ToString();
            Update();
            // Вычисляем число S
            BigInteger s = q;
            textBoxS.Text = s.ToString();
            Update();
            // Вычисляем число Е
            BigInteger E = 0;
            BigInteger a = s;
            BigInteger b = d;
            BigInteger dd = 1; // Остаток

            while (a > 0)
            {
                BigInteger aa = b / a;
                BigInteger bb = a;
                a = b % a;
                b = bb;
                bb = dd;
                dd = E - aa * dd;
                E = bb;
            }
            E = E % d;
            if (E < 0)
            {
                E = (E + d) % d;
            }
            BigInteger eCheck = (E * s) % d;
            textBoxECheck.Text = eCheck.ToString();
            Update();
            textBoxE.Text = E.ToString();
            Update();
            // Передаем открытый и закрытый ключ
            N = n;
            S = s;
            Form1.E = E;
            Enabled = true;
        }
        /// <summary>
        /// Действие при нажатии кнопки "Зашифровать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Введите какой-либо текст");
                return;
            }
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            // Получаем публичный ключ
            BigInteger s = S;
            BigInteger n = N;
            // Получаем текст
            char[] text = richTextBox1.Text.ToCharArray();
            int size = richTextBox1.Text.Length;
            string m = "1";
            //// Шифруем текст посимвольно
            for (int i = 0; i < size; i++)
            {

                string ch = String.Format("{0:d4}", Convert.ToInt32(text[i]));
                m = m + ch;
                if ((i % 7 == 0) && (i != 0) || i == size - 1)
                {
                    BigInteger c = BigInteger.ModPow(BigInteger.Parse(m), s, n);
                    richTextBox2.AppendText(c.ToString() + "\n");
                    m = "1";
                }
            }
        }
        /// <summary>
        /// Действие при нажатие кнопки "Расшифровать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                MessageBox.Show("Отсутствует текст для расшифрования");
                return;
            }
            richTextBox3.Text = "";
            // Получаем зыкрытый ключ
            BigInteger E = Form1.E;
            BigInteger n = N;
            // Получаем текст
            string text = richTextBox2.Text;
            int size = richTextBox2.Lines.Length - 1;
            // Расшифровываем посимвольно
            for (int i = 0; i < size; i++)
            {
                BigInteger c = BigInteger.Parse(richTextBox2.Lines[i]);
                string m = BigInteger.ModPow(c, E, n).ToString();
                for (int j = 1; j < m.Length; j++)
                {
                    if (j % 4 == 0)
                    {
                        richTextBox3.Text = richTextBox3.Text + 
                            Convert.ToChar(Convert.ToInt32(m.Substring(j - 3, 4))).ToString();
                    }
                }
            }
        }
    }
}
