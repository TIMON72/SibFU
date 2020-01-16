using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Class1
    {
        /// <summary>
        /// Поля текущего класса
        /// </summary>
        public string name, size, atributes;
        public DateTime time_of_last_access;
        /// <summary>
        /// Ф-ция выбора каталога для вывода его информации
        /// </summary>
        /// <param name="lis"></param>
        /// <returns></returns>
        public static void ChoiseOfDirectory(ref string path_of_directory)
        {
            FolderBrowserDialog folder_dlg = new FolderBrowserDialog();
            ;
            DialogResult result = folder_dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                path_of_directory = folder_dlg.SelectedPath;
                MessageBox.Show("Каталог \"" + path_of_directory + "\" открыт успешно");
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
        public static void ListsOfFoldersAndFiles(ref List<string> list_of_folders,
            ref List<Class1> list_of_files, ref string path_of_directory)
        {
            // Получаем адрес выбранной директории
            //string path_of_directory = null;
            ChoiseOfDirectory(ref path_of_directory);
            if (path_of_directory == null)
            {
                MessageBox.Show("Вы не выбрали каталог", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Поиск папок и добавление в список
            DirectoryInfo dir = new DirectoryInfo(path_of_directory);
            foreach (var item in dir.GetDirectories())
            {
                list_of_folders.Add(Convert.ToString(item));
            }
            // Поиск файлов и добавление в список
            FileInfo file_info = new FileInfo(path_of_directory);
            foreach (var item in dir.GetFiles())
            {
                Class1 file = new Class1();
                file.name = Convert.ToString(item.Name);
                if (file.name.Contains(" ")) // Если файл содержит пробелы, то добавить [!]
                    file.name = "[!]" + file.name;
                file.size = (item.Length / 1024).ToString() + " KB";
                file.time_of_last_access = item.LastAccessTime;
                file.atributes = item.Attributes.ToString();
                list_of_files.Add(file);
            }
        }
    }
}
