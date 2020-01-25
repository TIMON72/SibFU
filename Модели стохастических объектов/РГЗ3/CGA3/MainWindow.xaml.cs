using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CGA3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Делегаты
        private delegate void UpdateProgressBarDelegate(DependencyProperty dp, Object value);
        // Поля
        double A; // Коэффициент A
        double B; // Коэффициент B
        double C; // Коэффициент C
        double M; // Мат. ожидание
        double D; // Дисперсия
        double beta; // Коэффициент бета
        double h; // Помеха h
        double X_start; // Начальное значение X
        double X_end; // Конечное значение X
        double X_step; // Шаг X
        // Списки
        List<double> X = new List<double>();
        List<double> Y = new List<double>();
        List<double> Y_h = new List<double>();
        List<List<double>> nu_n = new List<List<double>>();

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Очистка данных
        /// </summary>
        void ClearData()
        {
            X.Clear();
            Y.Clear();
            Y_h.Clear();
            nu_n.Clear();
        }
        /// <summary>
        /// Внутренняя функция ядра
        /// </summary>
        /// <param name="x"></param>
        /// <param name="x_i"></param>
        /// <param name="beta"></param>
        /// <param name="border"></param>
        /// <returns></returns>
        double InnerCoreFunc(double x, double x_i, double beta, int border) => 
            (Math.Abs(beta * (x - x_i) / X_step) <= 1) ? (Math.Abs(beta * (x - x_i) / X_step)) : ((border == 0) ? 0 : 1);
        /// <summary>
        /// Оценка регрессии
        /// </summary>
        /// <param name="betta"></param>
        void RegressionEstimate(double betta)
        {
            // Инициализация списков
            List<double> sumK = new List<double>(); // Сумма ядер
            List<double> K_n = new List<double>(); // Нормализованные ядра
            // Инициализация суммы четырех ядер и норм. ядер 
            for (int i = 0; i < 4; i++)
            {
                sumK.Add(0);
                K_n.Add(0);
                nu_n.Add(new List<double>());
            }
            // Инициализация оценки регрессии для 4-х ядер
            for (int i = 0; i < X.Count; i++)
            {
                nu_n[0].Add(0);
                nu_n[1].Add(0);
                nu_n[2].Add(0);
                nu_n[3].Add(0);
            }
            // Вычисления
            for (int i = 0; i < X.Count; i++)
            {
                // Вычисление суммы четырех ядер
                sumK[0] = 0;
                sumK[1] = 0;
                sumK[2] = 0;
                sumK[3] = 0;
                for (int j = 0; j < X.Count; j++)
                {
                    if (i == j)
                        continue;
                    sumK[0] += 0.5 * InnerCoreFunc(X[i], X[j], beta, 0);
                    sumK[1] += 1 - InnerCoreFunc(X[i], X[j], beta, 1);
                    sumK[2] += 0.75 * (1 - Math.Pow(InnerCoreFunc(X[i], X[j], beta, 1), 2));
                    sumK[3] += (1 + 2 * InnerCoreFunc(X[i], X[j], beta, 1)) * Math.Pow(1 - InnerCoreFunc(X[i], X[j], beta, 1), 2);
                }
                // Вычисление четырех норм. ядер и функции регрессии
                for (int j = 0; j < X.Count; j++)
                {
                    if (i == j)
                        continue;
                    K_n[0] = 0.5 * InnerCoreFunc(X[i], X[j], beta, 0) / sumK[0];
                    nu_n[0][i] += K_n[0] * Y_h[j];
                    K_n[1] = (1 - InnerCoreFunc(X[i], X[j], beta, 1)) / sumK[1];
                    nu_n[1][i] += K_n[1] * Y_h[j];
                    K_n[2] = 0.75 * (1 - Math.Pow(InnerCoreFunc(X[i], X[j], beta, 1), 2)) / sumK[2];
                    nu_n[2][i] += K_n[2] * Y_h[j];
                    K_n[3] = (1 + 2 * InnerCoreFunc(X[i], X[j], beta, 1)) * Math.Pow(1 - InnerCoreFunc(X[i], X[j], beta, 1), 2) / sumK[3];
                    nu_n[3][i] += K_n[3] * Y_h[j];
                }
            }
        }
        /// <summary>
        /// Нормальное распределение
        /// </summary>
        /// <param name="m"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        double NormalDistribution(double m, double d)
        {
            Random rnd = new Random();
            double x = 0;
            int n = 50; // Количество реализаций
            double temp = 0;
            for (int i = 0; i < n; i++)
                temp += rnd.NextDouble() - 0.5;
            x = Math.Sqrt((d * 12) / n) * temp + m;
            return x;
        }
        /// <summary>
        /// Создать график
        /// </summary>
        void CreateGraph()
        {
            // Создаем модель графика
            PlotModel plotModel = new PlotModel();
            // Объявляем кривые графика
            LineSeries ls_Y = new LineSeries();
            LineSeries ls_Y_h = new LineSeries();
            ls_Y_h.MarkerType = MarkerType.Circle;
            ls_Y_h.MarkerFill = OxyColors.Blue;
            ls_Y_h.MarkerSize = 5;
            ls_Y_h.LineStyle = LineStyle.None;
            LineSeries ls_K0 = new LineSeries();
            LineSeries ls_K1 = new LineSeries();
            LineSeries ls_K2 = new LineSeries();
            LineSeries ls_K3 = new LineSeries();
            // Именуем кривые
            ls_Y.Title = "График Y";
            ls_Y_h.Title = "График Y c помехой h";
            ls_K0.Title = "Прямоугольное ядро";
            ls_K1.Title = "Треугольное ядро";
            ls_K2.Title = "Параболическое ядро";
            ls_K3.Title = "Кубическое ядро";
            // Добавляем точки к кривым
            for (int i = 0; i < X.Count; i++)
            {
                ls_Y.Points.Add(new DataPoint(X[i], Y[i]));
                ls_Y_h.Points.Add(new DataPoint(X[i], Y_h[i]));
                ls_K0.Points.Add(new DataPoint(X[i], nu_n[0][i]));
                ls_K1.Points.Add(new DataPoint(X[i], nu_n[1][i]));
                ls_K2.Points.Add(new DataPoint(X[i], nu_n[2][i]));
                ls_K3.Points.Add(new DataPoint(X[i], nu_n[3][i]));
            }
            // Добавляем кривые к модели
            plotModel.Series.Add(ls_Y);
            plotModel.Series.Add(ls_Y_h);
            plotModel.Series.Add(ls_K0);
            plotModel.Series.Add(ls_K1);
            plotModel.Series.Add(ls_K2);
            plotModel.Series.Add(ls_K3);
            // Передаем модель для отображения
            plotView.Model = plotModel;
        }
        /// <summary>
        /// Линейная функция
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        double LinearFunc(double x) => A * x + B;
        /// <summary>
        /// Нелинейная функция
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        double NonlinearFunc(double x) => A * Math.Pow(x, 2) + B * x + C;
        /// <summary>
        /// Синусоидальная функция
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        double SineFunc(double x) => A * Math.Sin(B * x) + C;
        /// <summary>
        /// Нажатие на кнопку "Запуск" в разделе "Линейный объект"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Linear_Click(object sender, RoutedEventArgs e)
        {
            // Очистка списков
            ClearData();
            // Инициализация входных данных
            A = double.Parse(MTB_A.Text.Replace("_", ""));
            B = double.Parse(MTB_B.Text.Replace("_", ""));
            C = 0;
            M = double.Parse(MTB_M.Text.Replace("_", ""));
            D = double.Parse(MTB_D.Text.Replace("_", ""));
            beta = double.Parse(MTB_beta.Text.Replace("_", ""));
            X_start = double.Parse(MTB_X_start.Text.Replace("_", ""));
            X_end = double.Parse(MTB_X_end.Text.Replace("_", ""));
            X_step = double.Parse(MTB_X_step.Text.Replace("_", ""));
            // Заполняем список X
            for (double i = X_start; i < X_end; i += X_step)
            {
                X.Add(i);
            }
            // Заполняем список Y
            for (int i = 0; i < X.Count; i++)
            {
                Y.Add(LinearFunc(X[i]));
            }
            // Заполняем список Y с помехой h
            for (int i = 0; i < X.Count; i++)
            {
                Thread.Sleep(25); // Костыль для генерации чисел
                h = NormalDistribution(M, D);
                Y_h.Add(LinearFunc(X[i]) + h);
            }
            // Ищем оценку регрессии M[Y|x] = nu_n(x) с каждым ядром
            RegressionEstimate(beta);
            // Отображаем на графике
            CreateGraph();
        }
        /// <summary>
        /// Нажатие на кнопку "Запуск" в разделе "Нелинейный объект"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Nonlinear_Click(object sender, RoutedEventArgs e)
        {
            // Очистка списков
            ClearData();
            // Инициализация входных данных
            A = double.Parse(MTB_A1.Text.Replace("_", ""));
            B = double.Parse(MTB_B1.Text.Replace("_", ""));
            C = double.Parse(MTB_C1.Text.Replace("_", ""));
            M = double.Parse(MTB_M1.Text.Replace("_", ""));
            D = double.Parse(MTB_D1.Text.Replace("_", ""));
            beta = double.Parse(MTB_beta1.Text.Replace("_", ""));
            X_start = double.Parse(MTB_X_start1.Text.Replace("_", ""));
            X_end = double.Parse(MTB_X_end1.Text.Replace("_", ""));
            X_step = double.Parse(MTB_X_step1.Text.Replace("_", ""));
            // Заполняем список X
            for (double i = X_start; i < X_end; i += X_step)
            {
                X.Add(i);
            }
            // Заполняем список Y
            for (int i = 0; i < X.Count; i++)
            {
                Y.Add(NonlinearFunc(X[i]));
            }
            // Заполняем список Y с помехой h
            for (int i = 0; i < X.Count; i++)
            {
                Thread.Sleep(25); // Костыль для генерации чисел
                h = NormalDistribution(M, D);
                Y_h.Add(NonlinearFunc(X[i]) + h);
            }
            // Ищем оценку регрессии M[Y|x] = nu_n(x) с каждым ядром
            RegressionEstimate(beta);
            // Отображаем на графике
            CreateGraph();
        }
        /// <summary>
        /// Нажатие на кнопку "Запуск" в разделе "Синусоидальный объект"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Sinewave_Click(object sender, RoutedEventArgs e)
        {
            // Очистка списков
            ClearData();
            // Инициализация входных данных
            A = double.Parse(MTB_A2.Text.Replace("_", ""));
            B = double.Parse(MTB_B2.Text.Replace("_", ""));
            C = double.Parse(MTB_C2.Text.Replace("_", ""));
            M = double.Parse(MTB_M2.Text.Replace("_", ""));
            D = double.Parse(MTB_D2.Text.Replace("_", ""));
            beta = double.Parse(MTB_beta2.Text.Replace("_", ""));
            X_start = double.Parse(MTB_X_start2.Text.Replace("_", ""));
            X_end = double.Parse(MTB_X_end2.Text.Replace("_", ""));
            X_step = double.Parse(MTB_X_step2.Text.Replace("_", ""));
            // Заполняем список X
            for (double i = X_start; i < X_end; i += X_step)
            {
                X.Add(i);
            }
            // Заполняем список Y
            for (int i = 0; i < X.Count; i++)
            {
                Y.Add(SineFunc(X[i]));
            }
            // Заполняем список Y с помехой h
            for (int i = 0; i < X.Count; i++)
            {
                Thread.Sleep(25); // Костыль для генерации чисел
                h = NormalDistribution(M, D);
                Y_h.Add(SineFunc(X[i]) + h);
            }
            // Ищем оценку регрессии M[Y|x] = nu_n(x) с каждым ядром
            RegressionEstimate(beta);
            // Отображаем на графике
            CreateGraph();
        }
    }
}
