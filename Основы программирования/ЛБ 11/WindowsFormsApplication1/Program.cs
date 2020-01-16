using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Буфферный класс для доступа к переменным из любого класса или формы
    /// </summary>
    class Buffer
    {
        public static string path_of_directory;
        public static List<string> list_of_folders = new List<string>();
        public static List<Info> list_of_files = new List<Info>();
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
