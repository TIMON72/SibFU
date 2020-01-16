using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Info
    {
        /// <summary>
        /// Поля текущего класса
        /// </summary>
        public string name, size;
        public FileAttributes attributes;
        public DateTime time_of_last_access;
        /// <summary>
        /// Ф-ция выбора каталога для вывода его информации
        /// </summary>
        /// <param name="lis"></param>
        /// <returns></returns>
        public static void ChoiseOfDirectory()
        {
            Buffer.list_of_folders.Clear(); // Очистка списка папок
            Buffer.list_of_files.Clear(); // Очистка списка файлов
            FolderBrowserDialog folder_dlg = new FolderBrowserDialog();
            DialogResult result = folder_dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                Buffer.path_of_directory = folder_dlg.SelectedPath;
                MessageBox.Show("Каталог \"" + Buffer.path_of_directory + "\" открыт успешно");
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// Ф-ция создания списков папок и файлов
        /// </summary>
        /// <param name="list_of_folders"></param>
        /// <param name="list_of_files"></param>
        public static void ListsOfFoldersAndFiles()
        {
            // Получаем адрес выбранной директории
            ChoiseOfDirectory();
            if (Buffer.path_of_directory == null)
            {
                MessageBox.Show("Вы не выбрали каталог", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Поиск папок и добавление в список
            DirectoryInfo dir = new DirectoryInfo(Buffer.path_of_directory);
            foreach (var item in dir.GetDirectories())
            {
                string folder;
                folder = item.Name;
                Buffer.list_of_folders.Add(folder);
            }
            // Поиск файлов и добавление в список
            FileInfo file_info = new FileInfo(Buffer.path_of_directory);
            foreach (var item in dir.GetFiles())
            {
                Info file = new Info();
                file.name = Convert.ToString(item.Name);
                file.size = (item.Length / 1024).ToString();
                file.time_of_last_access = item.LastAccessTime;
                file.attributes = item.Attributes;
                Buffer.list_of_files.Add(file);
            }
        }
    }
}