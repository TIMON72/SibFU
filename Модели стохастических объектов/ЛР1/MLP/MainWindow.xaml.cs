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
using OxyPlot;
using OxyPlot.Series;

namespace MLP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle[,] Matrix { get; set; }
        // Делегаты
        private delegate void UpdateProgressBarDelegate(DependencyProperty dp, Object value);

        public MainWindow()
        {
            
            InitializeComponent();
            Matrix = new Rectangle[,] 
            {
                { rec11, rec12, rec13, rec14, rec15 },
                { rec21, rec22, rec23, rec24, rec25 },
                { rec31, rec32, rec33, rec34, rec35 },
                { rec41, rec42, rec43, rec44, rec45 },
                { rec51, rec52, rec53, rec54, rec55 },
                { rec61, rec62, rec63, rec64, rec65 },
                { rec71, rec72, rec73, rec74, rec75 },
                { rec81, rec82, rec83, rec84, rec85 },
                { rec91, rec92, rec93, rec94, rec95 },
                { rec101, rec102, rec103, rec104, rec105 }
            };
            Perceptron.Teaching(9000, 0.4);
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
            TB_Answer.Text += Perceptron.Run(Matrix);
        }
        /// <summary>
        /// Нажатие на кнопку "Teaching"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Teaching_Click(object sender, RoutedEventArgs e)
        {
            TB_Answer.Clear();
            TB_Answer.Text += Perceptron.Teaching(9000, 0.4);
        }
        /// <summary>
        /// Нажатие на кнопку "Experience"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Experience_Click(object sender, RoutedEventArgs e)
        {
            if (MTB_N_start.Text.Replace("_","") == "")
            {
                MessageBox.Show("Вы не указали начальное значение N", "Ошибка параметра N", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MTB_N_end.Text.Replace("_", "") == "")
            {
                MessageBox.Show("Вы не указали конечное значение N", "Ошибка параметра N", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MTB_M.Text.Replace("_", "") == "")
            {
                MessageBox.Show("Вы не указали количество опытов M", "Ошибка параметра M", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Создаем модель графика
            PlotModel plotModel = new PlotModel();
            // Переводим введенные данные в нужный формат
            int n_start = Convert.ToInt32(MTB_N_start.Text.Replace("_",""));
            int n_end = Convert.ToInt32(MTB_N_end.Text.Replace("_", ""));
            int n_step = 500;
            int m = Convert.ToInt32(MTB_M.Text.Replace("_", ""));
            double eta_start = 0.1;
            double eta_end = 1;
            double eta_step = 0.1;
            // Настраиваем полосу загрузки
            PB_Experience.Maximum = ((n_end - n_start) / n_step) * ((eta_end - eta_start) / eta_step + 1);
            UpdateProgressBarDelegate updatePB = new UpdateProgressBarDelegate(PB_Experience.SetValue);
            PB_Experience.Value = 0;
            // Выполняем исследование
            for (double eta = 0.1; eta < 1; eta = eta + 0.1)
            {
                LineSeries lineSeries = new LineSeries(); // Начинаем новую кривую
                lineSeries.Title = "eta = " + eta;
                for (int n = n_start; n < n_end; n = n + 500)
                {
                    double error = Perceptron.ExperienceTeaching(n, eta, m);
                    lineSeries.Points.Add(new DataPoint(n, error)); // Добавляем точку к кривой
                    PB_Experience.Value += 1;
                    if (n == n_end && eta == 1)
                    {
                        PB_Experience.Value = PB_Experience.Maximum;
                    }
                    Dispatcher.Invoke(updatePB,System.Windows.Threading.DispatcherPriority.Background, 
                        new object[] { System.Windows.Controls.Primitives.RangeBase.ValueProperty, PB_Experience.Value });
                }
                plotModel.Series.Add(lineSeries); // Добавляем кривую в модель
            }
            plotView.Model = plotModel; // Передаем модель для отображения
        }
    }
}
