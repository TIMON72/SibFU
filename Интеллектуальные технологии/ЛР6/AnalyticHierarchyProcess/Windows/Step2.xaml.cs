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

namespace AnalyticHierarchyProcess.Windows
{
    /// <summary>
    /// Логика взаимодействия для Step2.xaml
    /// </summary>
    public partial class Step2 : UserControl
    {
        double leftRaiting = 1;
        double rightRaiting = 1;
        int current_matrix = -1;
        int current_i = 0;
        int current_j = 0;
        readonly DataTable table = new DataTable();
        public static List<Matrix> a = new List<Matrix>(Criterion.CriteriaList.Count);
        /// <summary>
        /// Конструктор
        /// </summary>
        public Step2()
        {
            InitializeComponent();
            InitializeMatrix();
            B_PreviousCriterion.Visibility = Visibility.Hidden;
            TB_LeftAlternativeName.Text = Alternative.AlternativesList[0].Name;
            TB_RightAlternativeName.Text = Alternative.AlternativesList[1].Name;
        }
        /// <summary>
        /// Инициализация матрицы
        /// </summary>
        void InitializeMatrix()
        {
            foreach (Alternative a in Alternative.AlternativesList)
                table.Columns.Add(a.Name);
            for (int m = 0; m < Criterion.CriteriaList.Count; m++)
            {
                a.Add(new Matrix(Alternative.AlternativesList.Count, Alternative.AlternativesList.Count));
                for (int i = 0; i < Alternative.AlternativesList.Count; i++)
                    for (int j = 0; j < Alternative.AlternativesList.Count; j++)
                        a[m].Element[i, j] = 1;
            }
            DG_Matrix.ItemsSource = table.DefaultView;
            B_NextCriterion_Click(null, null);
        }
        /// <summary>
        /// Событие загрузки строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG_Matrix_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (e.Row.GetIndex() <= Alternative.AlternativesList.Count - 1)
                e.Row.Header = Alternative.AlternativesList[e.Row.GetIndex()].Name;
        }
        /// <summary>
        /// Событие после ввода рейтинга левой альтернативы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_LeftAlternativeRaiting_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                leftRaiting = Convert.ToDouble(TB_LeftAlternativeRaiting.Text);
            }
            catch (FormatException)
            {
                TB_LeftAlternativeRaiting.Text = "1";
                TB_RightAlternativeRaiting.Text = "1";
                return;
            }
            if (leftRaiting > 1)
            {
                leftRaiting = Math.Round(leftRaiting);
                TB_LeftAlternativeRaiting.Text = leftRaiting.ToString();
            }
            if (leftRaiting < 0 || leftRaiting > 9)
            {
                TB_LeftAlternativeRaiting.Text = "1";
                TB_RightAlternativeRaiting.Text = "1";
            }
            else
            {
                rightRaiting = Convert.ToDouble(string.Format("{0:0.00}", 1 / leftRaiting));
                TB_RightAlternativeRaiting.Text = rightRaiting.ToString();
            }
        }
        /// <summary>
        /// Событие после ввода рейтинга правой альтернативы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_RightAlternativeRaiting_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                rightRaiting = Convert.ToDouble(TB_RightAlternativeRaiting.Text);
            }
            catch (FormatException)
            {
                TB_LeftAlternativeRaiting.Text = "1";
                TB_RightAlternativeRaiting.Text = "1";
                return;
            }
            if (rightRaiting > 1)
            {
                rightRaiting = Math.Round(rightRaiting);
                TB_RightAlternativeRaiting.Text = rightRaiting.ToString();
            }
            if (rightRaiting < 0 || rightRaiting > 9)
            {
                TB_LeftAlternativeRaiting.Text = "1";
                TB_RightAlternativeRaiting.Text = "1";
            }
            else
            {
                leftRaiting = Convert.ToDouble(string.Format("{0:0.00}", 1 / rightRaiting));
                TB_LeftAlternativeRaiting.Text = leftRaiting.ToString();
            }
        }
        /// <summary>
        /// Событие нажатия кнопки "Далее"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Next_Click(object sender, RoutedEventArgs e)
        {
            if (current_i < Alternative.AlternativesList.Count)
            {
                if (current_i == current_j)
                {
                    a[current_matrix].Element[current_i, current_j] = 1;
                    current_j++;
                }
                if (current_j < Alternative.AlternativesList.Count)
                {
                    if (current_j < Alternative.AlternativesList.Count - 1)
                    {
                        TB_LeftAlternativeName.Text = Alternative.AlternativesList[current_i].Name;
                        TB_RightAlternativeName.Text = Alternative.AlternativesList[current_j + 1].Name;
                    }
                    a[current_matrix].Element[current_i, current_j] = leftRaiting;
                    a[current_matrix].Element[current_j, current_i] = rightRaiting;
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
        /// Событие нажатия кнопки ">" у критерия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_NextCriterion_Click(object sender, RoutedEventArgs e)
        {
            table.Clear();
            current_matrix++;
            if (current_matrix >= Criterion.CriteriaList.Count - 1)
            {
                B_NextCriterion.Visibility = Visibility.Hidden;
                B_PreviousCriterion.Visibility = Visibility.Visible;
                current_matrix = Criterion.CriteriaList.Count - 1;
            }
            else
            {
                B_NextCriterion.Visibility = Visibility.Visible;
                B_PreviousCriterion.Visibility = Visibility.Visible;
            }
            current_i = 0;
            current_j = 0;
            TB_CriterionName.Text = Criterion.CriteriaList[current_matrix].Name;
            TB_LeftAlternativeName.Text = Alternative.AlternativesList[0].Name;
            TB_RightAlternativeName.Text = Alternative.AlternativesList[1].Name;

            string[] row = new string[table.Columns.Count];
            for (int i = 0; i < Alternative.AlternativesList.Count; i++)
            {
                for (int j = 0; j < Alternative.AlternativesList.Count; j++)
                {
                    row[j] = a[current_matrix].Element[i, j].ToString();
                }
                table.Rows.Add(row);
            }
            DG_Matrix.ItemsSource = table.DefaultView;
        }
        /// <summary>
        /// Событие нажатия кнопки "<" у критерия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_PreviousCriterion_Click(object sender, RoutedEventArgs e)
        {
            table.Clear();
            current_matrix--;
            if (current_matrix <= 0)
            {
                B_PreviousCriterion.Visibility = Visibility.Hidden;
                B_NextCriterion.Visibility = Visibility.Visible;
                current_matrix = 0;
            }
            else
            {
                B_NextCriterion.Visibility = Visibility.Visible;
                B_PreviousCriterion.Visibility = Visibility.Visible;
            }
            current_i = 0;
            current_j = 0;
            TB_CriterionName.Text = Criterion.CriteriaList[current_matrix].Name;
            TB_LeftAlternativeName.Text = Alternative.AlternativesList[0].Name;
            TB_RightAlternativeName.Text = Alternative.AlternativesList[1].Name;

            string[] row = new string[table.Columns.Count];
            for (int i = 0; i < Alternative.AlternativesList.Count; i++)
            {
                for (int j = 0; j < Alternative.AlternativesList.Count; j++)
                {
                    row[j] = a[current_matrix].Element[i, j].ToString();
                }
                table.Rows.Add(row);
            }
            DG_Matrix.ItemsSource = table.DefaultView;
        }
        /// <summary>
        /// Событие нажатия кнопки "Тестовые данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_TestData_Click(object sender, RoutedEventArgs e)
        {
            string[] matrix_str = new string[a.Count * a.Count];
            switch (current_matrix)
            {
                case 0:
                    matrix_str =
                        ("1 4 0,5 " +
                         "0,25 1 0,2 " +
                         "2 5 1").Split();
                    break;
                case 1:
                    matrix_str =
                        ("1 0,5 3 " +
                         "2 1 4 " +
                         "0,33 0,25 1").Split();
                    break;
                case 2:
                    matrix_str =
                        ("1 1 0,2 " +
                         "1 1 3 " +
                         "0,5 0,33 1").Split();
                    break;
                case 3:
                    matrix_str =
                        ("1 0,33 4 " +
                         "3 1 5 " +
                         "0,25 0,2 1").Split();
                    break;
                case 4:
                    matrix_str =
                        ("1 2 0,2 " +
                         "0,5 1 0,17 " +
                         "5 6 1").Split();
                    break;
                case 5:
                    matrix_str =
                        ("1 0,14 7 " +
                         "7 1 3 " +
                         "0,14 0,33 1").Split();
                    break;
                case 6:
                    matrix_str =
                        ("1 0,33 0,13 " +
                         "3 1 9 " +
                         "8 0,11 1").Split();
                    break;
                case 7:
                    matrix_str =
                        ("1 9 0,5 " +
                         "0,11 1 0,14 " +
                         "2 7 1").Split();
                    break;
                default:
                    return;
            }
            table.Clear();
            for (int i = 0; i < Alternative.AlternativesList.Count; i++)
            {
                string[] row = matrix_str[(i * 3)..(i * 3 + 3)];
                for (int j = 0; j < Alternative.AlternativesList.Count; j++)
                {
                    a[current_matrix].Element[i, j] = Convert.ToDouble(row[j]);
                }
                table.Rows.Add(row);
            }
            DG_Matrix.ItemsSource = table.DefaultView;
        }
    }
}
