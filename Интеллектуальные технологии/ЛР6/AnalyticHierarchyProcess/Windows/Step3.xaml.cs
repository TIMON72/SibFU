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
    /// Логика взаимодействия для Step3.xaml
    /// </summary>
    public partial class Step3 : UserControl
    {
        int current_matrix = -1;
        DataTable table = new DataTable();
        readonly List<Matrix> matricesList = new List<Matrix>();
        readonly List<Matrix> normalizedMatricesList = new List<Matrix>();
        Matrix criteriaWeightsMatrix;
        Matrix alternativesWeightsMatrix;
        Matrix targetsMatrix;
        /// <summary>
        /// Конструктор
        /// </summary>
        public Step3()
        {
            InitializeComponent();
            B_DetermineWeights.IsEnabled = false;
            B_DetermineTarget.IsEnabled = false;
        }
        /// <summary>
        /// Инициализация матриц
        /// </summary>
        void MatricesInitialization()
        {
            matricesList.Add(Step1.a);
            foreach (Matrix m in Step2.a)
                matricesList.Add(m);
            B_NextMatrix_Click(null, null);
        }
        /// <summary>
        /// Событие окончания загрузки таблицы данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG_Matrix_Loaded(object sender, RoutedEventArgs e)
        {
            MatricesInitialization();
            B_PreviousMatrix.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Событие загрузки строки матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG_Matrix_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (current_matrix == 0)
            {
                if (e.Row.GetIndex() <= Criterion.CriteriaList.Count - 1)
                    e.Row.Header = Criterion.CriteriaList[e.Row.GetIndex()].Name;
            }
            else if (current_matrix == -2)
            {
                if (e.Row.GetIndex() < Alternative.AlternativesList.Count + 1 && e.Row.GetIndex() > 0)
                    e.Row.Header = Alternative.AlternativesList[e.Row.GetIndex() - 1].Name;
            }
            else
            {
                if (e.Row.GetIndex() <= Alternative.AlternativesList.Count - 1)
                    e.Row.Header = Alternative.AlternativesList[e.Row.GetIndex()].Name;
            }
        }
        /// <summary>
        /// Перерисовка матрицы
        /// </summary>
        private void DG_Matrix_Refresh(Matrix matrix)
        {
            table = new DataTable();
            if (current_matrix == 0)
            {
                TB_MatrixName.Text = "М-ца \"Критерии\"";
                foreach (Criterion c in Criterion.CriteriaList)
                    table.Columns.Add(c.Name);
                string[] row = new string[table.Columns.Count];
                for (int i = 0; i < Criterion.CriteriaList.Count; i++)
                {
                    for (int j = 0; j < Criterion.CriteriaList.Count; j++)
                        row[j] = matrix.Element[i, j].ToString();
                    table.Rows.Add(row);
                }
            }
            else
            {
                TB_MatrixName.Text = "М-ца \"" + Criterion.CriteriaList[current_matrix - 1].Name + "\"";
                foreach (Alternative a in Alternative.AlternativesList)
                    table.Columns.Add(a.Name);
                string[] row = new string[table.Columns.Count];
                for (int i = 0; i < Alternative.AlternativesList.Count; i++)
                {
                    for (int j = 0; j < Alternative.AlternativesList.Count; j++)
                        row[j] = matrix.Element[i, j].ToString();
                    table.Rows.Add(row);
                }
            }
            DG_Matrix.ItemsSource = table.DefaultView;
        }
        /// <summary>
        /// Событие нажатия кнопки ">" у матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_NextMatrix_Click(object sender, RoutedEventArgs e)
        {
            current_matrix++;
            if (current_matrix >= matricesList.Count - 1)
            {
                B_NextMatrix.Visibility = Visibility.Hidden;
                B_PreviousMatrix.Visibility = Visibility.Visible;
                current_matrix = matricesList.Count - 1;
            }
            else
            {
                B_NextMatrix.Visibility = Visibility.Visible;
                B_PreviousMatrix.Visibility = Visibility.Visible;
            }
            if (B_MatrixNormalization.IsEnabled == true)
                DG_Matrix_Refresh(matricesList[current_matrix]);
            else
                DG_Matrix_Refresh(normalizedMatricesList[current_matrix]);
        }
        /// <summary>
        /// Событие нажатия кнопки "<" у матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_PreviousMatrix_Click(object sender, RoutedEventArgs e)
        {
            current_matrix--;
            if (current_matrix <= 0)
            {
                B_PreviousMatrix.Visibility = Visibility.Hidden;
                B_NextMatrix.Visibility = Visibility.Visible;
                current_matrix = 0;
            }
            else
            {
                B_NextMatrix.Visibility = Visibility.Visible;
                B_PreviousMatrix.Visibility = Visibility.Visible;
            }
            if (B_MatrixNormalization.IsEnabled == true)
                DG_Matrix_Refresh(matricesList[current_matrix]);
            else
                DG_Matrix_Refresh(normalizedMatricesList[current_matrix]);
        }
        /// <summary>
        /// Событие нажатия кнопки "Нормировка"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_MatrixNormalization_Click(object sender, RoutedEventArgs e)
        {
            // Алгоритм нормировки матриц
            for (int m = 0; m < matricesList.Count; m++)
            {
                normalizedMatricesList.Add(new Matrix(matricesList[m].M, matricesList[m].N));
                for (int j = 0; j < matricesList[m].N; j++)
                {
                    double j_sum = 0;
                    for (int i = 0; i < matricesList[m].M; i++)
                        j_sum += matricesList[m].Element[i, j];
                    for (int i = 0; i < matricesList[m].M; i++)
                        normalizedMatricesList[m].Element[i, j] =
                            Convert.ToDouble(string.Format("{0:0.000}", matricesList[m].Element[i, j] / j_sum));
                }
            }
            // Визуализация матрицы
            DG_Matrix_Refresh(normalizedMatricesList[current_matrix]);
            // Настройка отображения UI-элементов
            B_MatrixNormalization.IsEnabled = false;
            B_DetermineWeights.IsEnabled = true;
        }
        /// <summary>
        /// Событие нажатия кнопки "Определить веса"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_DetermineWeights_Click(object sender, RoutedEventArgs e)
        {
            // Алгоритм
            criteriaWeightsMatrix = new Matrix(Criterion.CriteriaList.Count, 1);
            alternativesWeightsMatrix = new Matrix(Alternative.AlternativesList.Count, Criterion.CriteriaList.Count);
            for (int m = 0; m < normalizedMatricesList.Count; m++)
                for (int i = 0; i < normalizedMatricesList[m].M; i++)
                {
                    double i_sum = 0;
                    for (int j = 0; j < normalizedMatricesList[m].N; j++)
                        i_sum += normalizedMatricesList[m].Element[i, j];
                    if (m == 0)
                        criteriaWeightsMatrix.Element[i, 0] = i_sum / normalizedMatricesList[m].N;
                    else
                        alternativesWeightsMatrix.Element[i, m - 1] = i_sum / normalizedMatricesList[m].N;
                }
            // Визуализация матрицы
            current_matrix = -2;
            table = new DataTable();
            foreach (Criterion c in Criterion.CriteriaList)
                table.Columns.Add(c.Name);
            string[] row = new string[Criterion.CriteriaList.Count];
            for (int i = 0; i < Alternative.AlternativesList.Count + 1; i++)
            {
                for (int j = 0; j < Criterion.CriteriaList.Count; j++)
                    if (i == 0)
                        row[j] = string.Format("{0:0.000}", criteriaWeightsMatrix.Element[j, i]);
                    else
                        row[j] = string.Format("{0:0.000}", alternativesWeightsMatrix.Element[i - 1, j]);
                table.Rows.Add(row);
            }
            DG_Matrix.ItemsSource = table.DefaultView;
            // Настройка отображения UI-элементов
            B_DetermineWeights.IsEnabled = false;
            B_DetermineTarget.IsEnabled = true;
            B_NextMatrix.Visibility = Visibility.Hidden;
            B_PreviousMatrix.Visibility = Visibility.Hidden;
            TB_MatrixName.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Событие нажатия кнопки "Определить цель"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_DetermineTarget_Click(object sender, RoutedEventArgs e)
        {
            // Алгоритм
            targetsMatrix = alternativesWeightsMatrix * criteriaWeightsMatrix;
            // Визуализация матрицы
            current_matrix = -1;
            table = new DataTable();
            table.Columns.Add("%");
            string[] row = new string[targetsMatrix.N];
            for (int i = 0; i < targetsMatrix.M; i++)
            {
                for (int j = 0; j < targetsMatrix.N; j++)
                    row[j] = string.Format("{0:0.0}", targetsMatrix.Element[i, j] * 100);
                table.Rows.Add(row);
            }
            DG_Matrix.ItemsSource = table.DefaultView;
            // Настройка отображения UI-элементов
            B_DetermineTarget.IsEnabled = false;
        }
    }
}
