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
using System.Windows.Threading;
using OxyPlot;
using OxyPlot.Series;

namespace CGA4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Поля
        double A; // Коэффициент A
        double B; // Коэффициент B
        double C; // Коэффициент C
        double X_start; // Начальное значение X
        double X_end; // Конечное значение X
        double X_step; // Шаг X
        double h; // Помеха h
        // Списки
        List<double> X = new List<double>();
        List<double> Y = new List<double>();
        List<double> Y_exp = new List<double>();
        List<double> Y_exp_h = new List<double>();
        // Таймер
        DispatcherTimer timer = new DispatcherTimer();

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
            Y_exp.Clear();
            Y_exp_h.Clear();
        }
        /// <summary>
        /// Нормальное распределение
        /// </summary>
        /// <param name="m"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        double NormalDistribution(double m = 0.3, double d = 0.5)
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
            LineSeries ls_Y_exp = new LineSeries();
            LineSeries ls_Y = new LineSeries();
            LineSeries ls_Y_exp_h = new LineSeries();
            ls_Y_exp_h.MarkerType = MarkerType.Circle;
            ls_Y_exp_h.MarkerFill = OxyColors.Blue;
            ls_Y_exp_h.MarkerSize = 5;
            ls_Y_exp_h.LineStyle = LineStyle.None;
            // Именуем кривые
            ls_Y_exp.Title = "Ожидаемый Y";
            ls_Y.Title = "Y";
            ls_Y_exp_h.Title = "Ожидаемый Y с помехой h";
            // Добавляем точки к кривым
            for (int i = 0; i < X.Count; i++)
            {
                ls_Y_exp.Points.Add(new DataPoint(X[i], Y_exp[i]));
                ls_Y.Points.Add(new DataPoint(X[i], Y[i]));
                ls_Y_exp_h.Points.Add(new DataPoint(X[i], Y_exp_h[i]));
            }
            // Добавляем кривые к модели
            plotModel.Series.Add(ls_Y_exp);
            plotModel.Series.Add(ls_Y);
            plotModel.Series.Add(ls_Y_exp_h);
            // Передаем модель для отображения
            plotView.Model = plotModel;

        }
        /// <summary>
        /// Линейная функция
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        double LinearFunc(double x) => A * x + B;
        double LinearExpFunc(double x) => x;
        /// <summary>
        /// Событие тика таймера для линейной функции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LinearTimerTick(object sender, EventArgs e)
        {
            List<double> delta = new List<double>();
            delta.Add(0);
            for (int i = 0; i < X.Count; i++)
            {
                //Matrix fi = new Matrix(2, 1);
                //fi.Element[0, 0] = X[i];
                //fi.Element[1, 0] = 1;
                //Matrix alpha = new Matrix(2, 1);
                //alpha.Element[0, 0] = A;
                //alpha.Element[1, 0] = B;
                //A = A + ((Y_exp[i] - Matrix.Transpose(fi) * alpha) / (1 + Matrix.Transpose(fi) * fi) * fi).Element[0, 0];
                //B = B + ((Y_exp[i] - Matrix.Transpose(fi) * alpha) / (1 + Matrix.Transpose(fi) * fi) * fi).Element[0, 0];

                //Matrix m1 = Matrix.Transpose(fi) * alpha;
                //double x1 = A * X[i] + B;
                //Matrix m2 = Y_exp[i] - m1;
                //double x2 = Y_exp[i] - x1;
                //Matrix m3 = Matrix.Transpose(fi) * fi;
                //double x3 = 1 + Math.Pow(X[i], 2);
                //Matrix result = ((m2 / m3) * fi);
                //double result1 = x2 / x3;

                if (i != 0)
                {
                    delta.Add(0);
                    delta[i] = 1 + 0.9 * delta[i - 1];
                }
                double oldA = A;
                double oldB = B;
                //A = A + (Y_exp[i] - A * X[i] - B) / (1 + Math.Pow(X[i], 2));
                //B = B + (Y_exp[i] - A * X[i] - B) / (1 + Math.Pow(X[i], 2));
                A = A + (Y_exp_h[i] - A * X[i] - B) / (1 + Math.Pow(X[i], 2));
                B = B + (Y_exp_h[i] - A * X[i] - B) / (1 + Math.Pow(X[i], 2));
                //A = oldA + (Y_exp_h[i] - oldA * X[i] - oldB) / (1 + Math.Pow(X[i], 2));
                //B = oldB + (Y_exp_h[i] - oldA * X[i] - oldB) / (1 + Math.Pow(X[i], 2));
                if (delta[i] == 0)
                {
                    A = oldA;
                    B = oldB;
                }
                else
                {
                    A = oldA + Math.Pow(delta[i], -1) * (A - oldA);
                    B = oldB + Math.Pow(delta[i], -1) * (B - oldB);
                }
            }
            // Перезаполняем список Y
            Y.Clear();
            for (int j = 0; j < X.Count; j++)
            {
                Y.Add(LinearFunc(X[j]));
            }
            // Отображаем на графике
            CreateGraph();
        }
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
            X_start = double.Parse(MTB_X_start.Text.Replace("_", ""));
            X_end = double.Parse(MTB_X_end.Text.Replace("_", ""));
            X_step = double.Parse(MTB_X_step.Text.Replace("_", ""));
            // Заполняем список X
            for (double i = X_start; i < X_end; i += X_step)
            {
                X.Add(i);
            }
            // Заполняем список Y_exp
            for (int i = 0; i < X.Count; i++)
            {
                Y_exp.Add(LinearExpFunc(X[i]));
            }
            // Заполняем список Y
            for (int i = 0; i < X.Count; i++)
            {
                Y.Add(LinearFunc(X[i]));
            }
            // Заполняем список Y_exp с помехой h
            for (int i = 0; i < X.Count; i++)
            {
                Thread.Sleep(25); // Костыль для генерации чисел
                h = NormalDistribution();
                Y_exp_h.Add(LinearExpFunc(X[i]) + h);
            }
            timer.Stop();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(LinearTimerTick);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }
        /// <summary>
        /// Нелинейная функция
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        double NonlinearFunc(double x) => A * Math.Pow(x, 2) + B * x + C;
        double NonlinearExpFunc(double x) => Math.Pow(x, 2) + x;
        /// <summary>
        /// /// Событие тика таймера для нелинейной функции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NonlinearTimerTick(object sender, EventArgs e)
        {
            List<double> delta = new List<double>();
            delta.Add(0);
            for (int i = 0; i < X.Count; i++)
            {
                if (i != 0)
                {
                    delta.Add(0);
                    delta[i] = 1 + 0.9 * delta[i - 1];
                }
                double oldA = A;
                double oldB = B;

                double x1 = Y_exp_h[i] - (A * Math.Pow(X[i], 2) + B * X[i] + C);
                double x2 = Math.Pow(Math.Pow(X[i], 2), 2) + Math.Pow(X[i], 2) + 1;
                if (x2 == 0)
                    continue;
                double x3 = x1 / x2;
                double a = A + x3 * Math.Pow(X[i], 2);
                double b = B + x3 * X[i];
                double c = C + x3 * 1;
                A = a;
                B = b;
                C = c;


                if (delta[i] == 0)
                {
                    A = oldA;
                    B = oldB;
                }
                else
                {
                    A = oldA + Math.Pow(delta[i], -1) * (A - oldA);
                    B = oldB + Math.Pow(delta[i], -1) * (B - oldB);
                }
            }
            // Перезаполняем список Y
            Y.Clear();
            for (int j = 0; j < X.Count; j++)
            {
                Y.Add(NonlinearFunc(X[j]));
            }
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
            X_start = double.Parse(MTB_X_start1.Text.Replace("_", ""));
            X_end = double.Parse(MTB_X_end1.Text.Replace("_", ""));
            X_step = double.Parse(MTB_X_step1.Text.Replace("_", ""));
            // Заполняем список X
            for (double i = X_start; i < X_end; i += X_step)
            {
                X.Add(i);
            }
            // Заполняем список Y_exp
            for (int i = 0; i < X.Count; i++)
            {
                Y_exp.Add(NonlinearExpFunc(X[i]));
            }
            // Заполняем список Y
            for (int i = 0; i < X.Count; i++)
            {
                Y.Add(NonlinearFunc(X[i]));
            }
            // Заполняем список Y_exp с помехой h
            for (int i = 0; i < X.Count; i++)
            {
                Thread.Sleep(25); // Костыль для генерации чисел
                h = NormalDistribution();
                Y_exp_h.Add(NonlinearExpFunc(X[i]) + h);
            }
            timer.Stop();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(NonlinearTimerTick);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }
        /// <summary>
        /// Синусоидальная функция
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        double SineFunc(double x) => A * Math.Sin(B * x);
        double SineExpFunc(double x) => Math.Sin(x);
        /// <summary>
        /// Событие тика таймера для синусоидальной функции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SinewaveTimerTick(object sender, EventArgs e)
        {
            List<double> delta = new List<double>();
            delta.Add(0);
            for (int i = 0; i < X.Count; i++)
            {
                if (i != 0)
                {
                    delta.Add(0);
                    delta[i] = 1 + 0.9 * delta[i - 1];
                }
                double oldA = A;
                double oldB = B;

                //double x1 = Y_exp[i] - A * Math.Sin(B * X[i]);
                double x1 = Y_exp_h[i] - A * Math.Sin(B * X[i]);
                double x2 = (Math.Pow(Math.Sin(B * X[i]), 2) + Math.Pow(A * X[i] * Math.Cos(B * X[i]), 2));
                if (x2 == 0)
                    continue;
                double x3 = x1 / x2;
                double a = A + x1 / x2 * Math.Sin(B * X[i]);
                double b = B + x1 / x2 * A * X[i] * Math.Cos(B * X[i]);
                A = a;
                B = b;

                if (delta[i] == 0)
                {
                    A = oldA;
                    B = oldB;
                }
                else
                {
                    A = oldA + Math.Pow(delta[i], -1) * (A - oldA);
                    B = oldB + Math.Pow(delta[i], -1) * (B - oldB);
                }
                //A = A + (Y_exp[i] - A * Math.Sin(B * X[i])) / 
                //    (Math.Pow(Math.Sin(B * X[i]), 2) + (A * X[i] * Math.Pow(Math.Cos(B * X[i]), 2))) *
                //    Math.Sin(B * X[i]);
                //B = B + (Y_exp[i] - A * Math.Sin(B * X[i])) /
                //    (Math.Pow(Math.Sin(B * X[i]), 2) + (A * X[i] * Math.Pow(Math.Cos(B * X[i]), 2))) *
                //    A * X[i] * Math.Cos(B * X[i]);
            }
            // Перезаполняем список Y
            Y.Clear();
            for (int j = 0; j < X.Count; j++)
            {
                Y.Add(SineFunc(X[j]));
            }
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
            X_start = double.Parse(MTB_X_start2.Text.Replace("_", ""));
            X_end = double.Parse(MTB_X_end2.Text.Replace("_", ""));
            X_step = double.Parse(MTB_X_step2.Text.Replace("_", ""));
            // Заполняем список X
            for (double i = X_start; i < X_end; i += X_step)
            {
                X.Add(i);
            }
            // Заполняем список Y_exp
            for (int i = 0; i < X.Count; i++)
            {
                Y_exp.Add(SineExpFunc(X[i]));
            }
            // Заполняем список Y
            for (int i = 0; i < X.Count; i++)
            {
                Y.Add(SineFunc(X[i]));
            }
            // Заполняем список Y_exp с помехой h
            for (int i = 0; i < X.Count; i++)
            {
                Thread.Sleep(25); // Костыль для генерации чисел
                h = NormalDistribution();
                Y_exp_h.Add(SineExpFunc(X[i]) + h);
            }
            timer.Stop();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(SinewaveTimerTick);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }
        /// <summary>
        /// Нажатие на кнопку "Стоп"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_StopTimer_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }


    }
}
