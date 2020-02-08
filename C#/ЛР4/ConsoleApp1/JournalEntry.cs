using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class JournalEntry
    {
        public string NameCollection { get; set; }
        public DateTime Time { get; set; }
        public string TypeChange { get; set; }
        public string DataNote { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="nameCollection"></param>
        /// <param name="time"></param>
        /// <param name="typeChange"></param>
        /// <param name="dataNote"></param>
        public JournalEntry(string nameCollection, DateTime time, string typeChange, string dataNote)
        {
            NameCollection = nameCollection;
            Time = time;
            TypeChange = typeChange;
            DataNote = dataNote;
        }
        /// <summary>
        /// Перегрузка метода ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Название коллекции: {0}; Время: {1}; Тип изменения: {2}; Данные о Note: {3}", 
                NameCollection, Time, TypeChange, DataNote);
        }
    }
}
