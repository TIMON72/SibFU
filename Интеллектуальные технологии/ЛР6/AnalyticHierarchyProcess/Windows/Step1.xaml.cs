using AnalyticHierarchyProcess.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalyticHierarchyProcess
{
    /// <summary>
    /// Логика взаимодействия для Step1.xaml
    /// </summary>
    public partial class Step1 : UserControl
    {
        double leftRaiting = 1;
        double rightRaiting = 1;
        int current_i = 0;
        int current_j = 0;
        readonly DataTable table = new DataTable();
        public static Matrix a = new Matrix(Criterion.CriteriaList.Count, Criterion.CriteriaList.Count);
        /// <summary>
        /// Конструктор
        /// </summary>
        public Step1()
        {
            InitializeComponent();
            InitializeMatrix();
            TB_LeftCriterionName.Text = Criterion.CriteriaList[0].Name;
            TB_RightCriterionName.Text = Criterion.CriteriaList[1].Name;
        }
        /// <summary>
        /// Инициализация матрицы
        /// </summary>
        void InitializeMatrix()
        {
            foreach (Criterion c in Criterion.CriteriaList)
                table.Columns.Add(c.Name);
            string[] row = new string[table.Columns.Count];
            for (int i = 0; i < Criterion.CriteriaList.Count; i++)
            {
                for (int j = 0; j < Criterion.CriteriaList.Count; j++)
                {
                    row[j] = "1";
                    a.Element[i, j] = Convert.ToDouble(row[j]);
                }
                table.Rows.Add(row);
            }
            DG_Matrix.ItemsSource = table.DefaultView;
        }
        /// <summary>
        /// Событие загрузки строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG_Matrix_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (e.Row.GetIndex() <= Criterion.CriteriaList.Count - 1)
                e.Row.Header = Criterion.CriteriaList[e.Row.GetIndex()].Name;
        }
        /// <summary>
        /// Событие после ввода рейтинга левого критерия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_LeftCriterionRaiting_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                leftRaiting = Convert.ToDouble(TB_LeftCriterionRaiting.Text);
            }
            catch (FormatException)
            {
                TB_LeftCriterionRaiting.Text = "1";
                TB_RightCriterionRaiting.Text = "1";
                return;
            }
            if (leftRaiting > 1)
            {
                leftRaiting = Math.Round(leftRaiting);
                TB_LeftCriterionRaiting.Text = leftRaiting.ToString();
            }
            if (leftRaiting < 0 || leftRaiting > 9)
            {
                TB_LeftCriterionRaiting.Text = "1";
                TB_RightCriterionRaiting.Text = "1";
            }
            else
            {
                rightRaiting = Convert.ToDouble(string.Format("{0:0.00}", 1 / leftRaiting));
                TB_RightCriterionRaiting.Text = rightRaiting.ToString();
            }
        }
        /// <summary>
        /// Событие после ввода рейтинга правого критерия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_RightCriterionRaiting_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                rightRaiting = Convert.ToDouble(TB_RightCriterionRaiting.Text);
            }
            catch (FormatException)
            {
                TB_LeftCriterionRaiting.Text = "1";
                TB_RightCriterionRaiting.Text = "1";
                return;
            }
            if (rightRaiting > 1)
            {
                rightRaiting = Math.Round(rightRaiting);
                TB_RightCriterionRaiting.Text = rightRaiting.ToString();
            }
            if (rightRaiting < 0 || rightRaiting > 9)
            {
                TB_LeftCriterionRaiting.Text = "1";
                TB_RightCriterionRaiting.Text = "1";
            }
            else
            {
                leftRaiting = Convert.ToDouble(string.Format("{0:0.00}", 1 / rightRaiting));
                TB_LeftCriterionRaiting.Text = leftRaiting.ToString();
            }
        }
        /// <summary>
        /// Событие нажатия кнопки "Далее"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Next_Click(object sender, RoutedEventArgs e)
        {
            if (current_i < Criterion.CriteriaList.Count)
            {
                if (current_i == current_j)
                {
                    a.Element[current_i, current_j] = 1;
                    current_j++;
                }
                if (current_j < Criterion.CriteriaList.Count)
                {
                    if (current_j < Criterion.CriteriaList.Count - 1)
                    {
                        TB_LeftCriterionName.Text = Criterion.CriteriaList[current_i].Name;
                        TB_RightCriterionName.Text = Criterion.CriteriaList[current_j + 1].Name;
                    }
                    a.Element[current_i, current_j] = leftRaiting;
                    a.Element[current_j, current_i] = rightRaiting;
                    table.Rows[current_i][current_j] = leftRaiting;
                    table.Rows[current_j][current_i] = rightRaiting;
                    current_j++;
                }
                else
                {
                    current_i++;
                    current_j = current_i;
                }
            }
            else
            {
                current_i = 0;
                current_j = 0;
                B_Next.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// Событие нажатия кнопки "Тестовые данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_TestData_Click(object sender, RoutedEventArgs e)
        {
            table.Clear();
            string[] matrix_str = 
                ("1 3 5 0,5 0,33 7 9 8 " +
                "0,33 1 2 4 0,5 0,33 0,25 9 " +
                "0,2 0,5 1 8 0,11 0,13 4 2 " +
                "2 0,25 0,13 1 6 0,17 5 5 " +
                "3 2 9 0,17 1 1 0,33 0,25 " +
                "0,14 3 8 6 1 1 7 0,5 " +
                "0,11 4 0,25 0,2 3 0,14 1 1 " +
                "0,13 0,11 0,5 0,2 4 2 1 1").Split();
            for (int i = 0; i < Criterion.CriteriaList.Count; i++)
            {
                string[] row = matrix_str[(i * 8)..(i * 8 + 8)];
                for (int j = 0; j < Criterion.CriteriaList.Count; j++)
                {
                    a.Element[i, j] = Convert.ToDouble(row[j]);
                }
                table.Rows.Add(row);
            }
            DG_Matrix.ItemsSource = table.DefaultView;
        }
    }
}
