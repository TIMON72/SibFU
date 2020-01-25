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

namespace PerceptronSL
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle[,] matrix;
        public MainWindow()
        {
            InitializeComponent();
            matrix = new Rectangle[,] 
            {
                { rec11, rec12, rec13 },
                { rec21, rec22, rec23 },
                { rec31, rec32, rec33 },
                { rec41, rec42, rec43 },
                { rec51, rec52, rec53 }
            };
            Perceptron.Teaching(1000000); // Обучаем перцептрон
        }
        /// <summary>
        /// Нажатие на кнопку "Generate"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Generate_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j].Fill = Brushes.Black;
        }
        /// <summary>
        /// Событие клика по пикселю табло
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {        
            Rectangle rec = (Rectangle)sender;
            // Цвет пикселя черный?
            if (rec.Fill == Brushes.Black)
                rec.Fill = Brushes.White;
            else
                rec.Fill = Brushes.Black;
        }
        /// <summary>
        /// Нажатие на кнопку "Run"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Run_Click(object sender, RoutedEventArgs e)
        {
            TB_Answer.Clear();
            TB_Answer.Text = Perceptron.Run(matrix);
        }
        /// <summary>
        /// Нажатие на кнопку "Teaching"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Teaching_Click(object sender, RoutedEventArgs e)
        {
            TB_Answer.Clear();
            TB_Answer.Text = Perceptron.Teaching(1000000);
        }
        /// <summary>
        /// Нажатие на кнопку "Experience"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Experience_Click(object sender, RoutedEventArgs e)
        {
            List<List<double>> results = new List<List<double>>();
            for (double eta = 0.1; eta < 1; eta = eta + 0.1)
            {
                List<double> result = new List<double>();
                for (int n = 10000; n < 100000; n = n + 10000)
                {
                    result.Add(Perceptron.ExperienceTeaching(n, 1));
                }
                results.Add(result);
            }
        }
    }
}
