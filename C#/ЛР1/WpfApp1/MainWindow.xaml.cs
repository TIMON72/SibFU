using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i < n; i++)
            {
                result = result * i;
            }
            return result;
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            double x_start = Convert.ToDouble(TextBoxXStart.Text); // х начальное
            double x_end = Convert.ToDouble(TextBoxXEnd.Text); // x конечное
            double step = Convert.ToDouble(TextBoxStep.Text); // шаг
            double accuracy = Convert.ToDouble(TextBoxAccuracy.Text); // точность
            double result = 1;
            int counter = 1; // счетчик
            List<Result> results = new List<Result>();
            for (double x = x_start; x <= x_end; x = x + step)
            {
                for (int n = 0; result >= accuracy; n++)
                {
                    double f = (Math.Pow(-1, n) * Math.Pow(x, 2 * n)) / Factorial(2 * n);
                    result += f;
                    counter++;
                    //results.Add(new Result(x, f, result, counter));
                    DataGridResults.Items.Add(new Result(x, f, result, counter));
                }
            }
            
        }
    }
}
