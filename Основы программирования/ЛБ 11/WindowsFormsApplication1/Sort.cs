using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Sort
    {
        /// <summary>
        ///  Сортировка от А до Я по имени
        /// </summary>
        public static void ByNameUp()
        {
            Buffer.list_of_files.Sort((a, b) => a.name.CompareTo(b.name));
        }
        /// <summary>
        ///  Сортировка от Я до А по имени
        /// </summary>
        public static void ByNameDown()
        {
            Buffer.list_of_files.Sort((a, b) => b.name.CompareTo(a.name));
        }
        /// <summary>
        /// Сортировка по размеру файла (по возрастанию)
        /// </summary>
        public static void BySizeUp()
        {
            for (int i = 0; i < Buffer.list_of_files.Count - 1; i++)
            {
                for (int j = i + 1; j < Buffer.list_of_files.Count; j++)
                {
                    if (Convert.ToInt32(Buffer.list_of_files[i].size) >
                        Convert.ToInt32(Buffer.list_of_files[j].size))
                    {
                        var t = Buffer.list_of_files[i];
                        Buffer.list_of_files[i] = Buffer.list_of_files[j];
                        Buffer.list_of_files[j] = t;
                    }
                }
            }
        }
        /// <summary>
        /// Сортировка по размеру файла (по убыванию)
        /// </summary>
        public static void BySizeDown()
        {
            for (int i = 0; i < Buffer.list_of_files.Count - 1; i++)
            {
                for (int j = i + 1; j < Buffer.list_of_files.Count; j++)
                {
                    if (Convert.ToInt32(Buffer.list_of_files[i].size) <
                        Convert.ToInt32(Buffer.list_of_files[j].size))
                    {
                        var t = Buffer.list_of_files[i];
                        Buffer.list_of_files[i] = Buffer.list_of_files[j];
                        Buffer.list_of_files[j] = t;
                    }
                }
            }
        }
        /// <summary>
        /// Сортировка по дате последнего доступа (по возрастанию)
        /// </summary>
        public static void ByDateUp()
        {
            Buffer.list_of_files.Sort((a, b) => a.time_of_last_access.CompareTo(b.time_of_last_access));
        }
        /// <summary>
        /// Сортировка по дате последнего доступа (по убыванию)
        /// </summary>
        public static void ByDateDown()
        {
            Buffer.list_of_files.Sort((a, b) => b.time_of_last_access.CompareTo(a.time_of_last_access));
        }
        /// <summary>
        /// Сортировка по атрибуту "Arhive"
        /// </summary>
        public static void ByAttribute_Archive()
        {
            for (int i = Buffer.list_of_files.Count-1; i > 0; i--)
            {
                string str = Convert.ToString(Buffer.list_of_files[i].attributes);
                if (str.Contains("Archive"))
                {
                    Buffer.list_of_files.Insert(0, Buffer.list_of_files[i]);
                    Buffer.list_of_files.RemoveAt(i+1);
                }
            }
        }
        /// <summary>
        /// Сортировка по атрибуту "Hidden"
        /// </summary>
        public static void ByAttribute_Hidden()
        {
            int end = Buffer.list_of_files.Count - 1;
            for (int i = end; i >= 0; i--)
            {
                string str = Convert.ToString(Buffer.list_of_files[i].attributes);
                if (str.Contains("Hidden"))
                {
                    Buffer.list_of_files.Insert(0, Buffer.list_of_files[i]);
                    Buffer.list_of_files.RemoveAt(i+1);
                }
            }
        }
        /// <summary>
        /// Сортировка по атрибуту "ReadOnly"
        /// </summary>
        public static void ByAttribute_ReadOnly()
        {
            int end = Buffer.list_of_files.Count - 1;
            for (int i = end; i >= 0; i--)
            {
                string str = Convert.ToString(Buffer.list_of_files[i].attributes);
                if (str.Contains("ReadOnly"))
                {
                    Buffer.list_of_files.Insert(0, Buffer.list_of_files[i]);
                    Buffer.list_of_files.RemoveAt(i + 1);
                }
            }
        }
        /// <summary>
        /// Сортировка по атрибуту "System"
        /// </summary>
        public static void ByAttribute_System()
        {
            int end = Buffer.list_of_files.Count - 1;
            for (int i = end; i >= 0; i--)
            {
                string str = Convert.ToString(Buffer.list_of_files[i].attributes);
                if (str.Contains("System"))
                {
                    Buffer.list_of_files.Insert(0, Buffer.list_of_files[i]);
                    Buffer.list_of_files.RemoveAt(i + 1);
                }
            }
        }


    }
}
