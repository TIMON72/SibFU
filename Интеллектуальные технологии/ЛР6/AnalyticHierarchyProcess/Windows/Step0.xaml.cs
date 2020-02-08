using AnalyticHierarchyProcess.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalyticHierarchyProcess.Windows
{
    /// <summary>
    /// Логика взаимодействия для Step0.xaml
    /// </summary>
    public partial class Step0 : UserControl
    {
        bool isEditEnding = false;

        public Step0()
        {
            InitializeComponent();
            DG_Criteria.ItemsSource = Criterion.ListInitialization();
            DG_Alternatives.ItemsSource = Alternative.ListInitialization();
        }
        /// <summary>
        /// Событие окончания загрузки таблицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DG_Criteria.Columns[0].Header = "Название критерия";
            DG_Alternatives.Columns[0].Header = "Название альтернативы";
        }
        /// <summary>
        /// Событие при окончании редактирования ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG_Criteria_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int input;
            try
            {
                input = Convert.ToInt32(((TextBox)e.EditingElement).Text);
            }
            catch (FormatException)
            {
                return;
            }
            if (input > 9 || input < 1)
            {
                if (isEditEnding)
                {
                    return;
                }
                try
                {
                    isEditEnding = true;
                    e.Cancel = true;
                    (sender as DataGrid).CancelEdit(DataGridEditingUnit.Cell);
                }
                finally
                {
                    isEditEnding = false;
                }
            }
        }
        /// <summary>
        /// Событие нажатия кнопки "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_AddNewCriterion_Click(object sender, RoutedEventArgs e)
        {
            int itemCount = Criterion.CriteriaList.Count;
            if (itemCount > 10)
                return;
            Criterion.CriteriaList.Add(new Criterion("критерий" + (itemCount + 1)));
            DG_Criteria.Items.Refresh();
        }
    }
}
