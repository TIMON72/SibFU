using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int countNotes = 8;
        List<NOTE> notes = new List<NOTE>(countNotes);
        ICollectionView view;

        int position = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Событие загрузки окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            notes = new List<NOTE>(countNotes);
            DG_Notes.ItemsSource = notes;
            DG_Notes.Columns[0].Header = "Фамилия Имя";
            DG_Notes.Columns[1].Header = "Телефон";
            DG_Notes.Columns[2].Header = "Дата рождения";
        }
        /// <summary>
        /// Нажатие на кнопку "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_AddNote_Click(object sender, RoutedEventArgs e)
        {
            if (position == countNotes)
            {
                MessageBox.Show("Достигнут лимит для записи (максимальное количество - " + countNotes + ")");
                return;
            }
            notes.Add(new NOTE(new Tuple<string, string, string>(MTB_SurnameName.Text, MTB_Phone.Text, MTB_DOB.Text)));
            DG_Notes.ItemsSource = notes;
            DG_Notes.Items.Refresh();
            position++;
        }
        /// <summary>
        /// Событие при вводе символа в бокс поиска по фамилии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_FindBySurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<NOTE> filteredNotes = new List<NOTE>();
            foreach (NOTE note in notes)
            {
                if (note.SurnameName.Contains(TB_FindBySurname.Text))
                    filteredNotes.Add(note);
            }
            if (filteredNotes.Count == 0)
            {
                filteredNotes.Add(new NOTE(new Tuple<string, string, string>("Записей нет", "", "")));
            }
            view = CollectionViewSource.GetDefaultView(filteredNotes);
            DG_Notes.ItemsSource = view;
            DG_Notes.Columns[0].Header = "Фамилия Имя";
            DG_Notes.Columns[1].Header = "Телефон";
            DG_Notes.Columns[2].Header = "Дата рождения";
            DG_Notes.Items.Refresh();
        }
        /// <summary>
        /// Сортировка по номеру телефона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_SortByPhone_Click(object sender, RoutedEventArgs e)
        {
            notes.Sort();
            DG_Notes.Items.Refresh();
        }
    }
}
