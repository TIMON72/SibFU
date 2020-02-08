using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace WpfApp1
{
    struct NOTE : IComparable<NOTE>
    {
        public string SurnameName { get; set; }
        public string Phone { get; set; }
        public string DOB { get; set; }
        /// <summary>
        /// Конструктор с кортежем
        /// </summary>
        /// <param name="note"></param>
        public NOTE(Tuple<string, string, string> note)
        {
            SurnameName = note.Item1;
            Phone = note.Item2;
            DOB = note.Item3;
        }
        /// <summary>
        /// Перегрузка метода ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Фамилия Имя: {0}; Телефон: {1}; Дата рождения: {2}", SurnameName, Phone, DOB);
        }
        /// <summary>
        /// Реализация интерфейса IComparable
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(NOTE obj)
        {
            return Phone.CompareTo(obj.Phone);
        }
    }
}
