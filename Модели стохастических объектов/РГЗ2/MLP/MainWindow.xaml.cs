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
        // Делегаты
        private delegate void UpdateProgressBarDelegate(DependencyProperty dp, Object value);

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Perceptron.InitializeData();
            TB_Answer.Text = Perceptron.Teaching(6000, 0.4);
        }
        /// <summary>
        /// Нажатие на кнопку "Teaching"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Teaching_Click(object sender, RoutedEventArgs e)
        {
            TB_Answer.Clear();
            TB_Answer.Text += Perceptron.Teaching(6000, 0.3);
        }
        /// <summary>
        /// Нажатие на кнопку "Experience"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Experience_Click(object sender, RoutedEventArgs e)
        {
            if (MTB_N_start.Text.Replace("_", "") == "")
            {
                MessageBox.Show("Вы не указали начальное значение N", "Ошибка параметра N", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MTB_N_end.Text.Replace("_", "") == "")
            {
                MessageBox.Show("Вы не указали конечное значение N", "Ошибка параметра N", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (MTB_N_step.Text.Replace("_", "") == "")
            {
                MessageBox.Show("Вы не указали шаг N", "Ошибка параметра N", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            int n_start = Convert.ToInt32(MTB_N_start.Text.Replace("_", ""));
            int n_end = Convert.ToInt32(MTB_N_end.Text.Replace("_", ""));
            int n_step = Convert.ToInt32(MTB_N_step.Text.Replace("_", "")); ;
            int m = Convert.ToInt32(MTB_M.Text.Replace("_", ""));
            double eta_start = 0.1;
            double eta_end = 0.6;
            double eta_step = 0.1;
            // Настраиваем полосу загрузки
            PB_Experience.Maximum = ((n_end - n_start) / n_step) * ((eta_end - eta_start) / eta_step);
            UpdateProgressBarDelegate updatePB = new UpdateProgressBarDelegate(PB_Experience.SetValue);
            PB_Experience.Value = 0;
            // Выполняем исследование
            List<double> x = new List<double>();
            for (double eta = eta_start; eta < eta_end; eta += eta_step)
            {
                LineSeries lineSeries = new LineSeries(); // Начинаем новую кривую
                lineSeries.Title = "eta = " + eta;
                for (int n = n_start; n < n_end; n = n + n_step)
                {
                    double accuracy = Perceptron.ExperienceTeaching(n, eta, m);
                    x.Add(accuracy);
                    lineSeries.Points.Add(new DataPoint(n, accuracy)); // Добавляем точку к кривой
                    PB_Experience.Value += 1;
                    if (n == n_end && eta == 1)
                    {
                        PB_Experience.Value = PB_Experience.Maximum;
                    }
                    Dispatcher.Invoke(updatePB, System.Windows.Threading.DispatcherPriority.Background,
                        new object[] { System.Windows.Controls.Primitives.RangeBase.ValueProperty, PB_Experience.Value });
                }
                plotModel.Series.Add(lineSeries); // Добавляем кривую в модель
            }
            plotView.Model = plotModel; // Передаем модель для отображения
        }
    }
}
