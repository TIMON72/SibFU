using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class NoteListHandlerEventArgs : EventArgs
    {
        public string NameCollection { get; set; }
        public string TypeChange { get; set; }
        public Note Note { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="nameCollection"></param>
        /// <param name="typeChange"></param>
        /// <param name="note"></param>
        public NoteListHandlerEventArgs (string nameCollection, string typeChange, Note note)
        {
            NameCollection = nameCollection;
            TypeChange = typeChange;
            Note = note;
        }
        /// <summary>
        /// Перегрузка метода ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("название коллекции: {0}; Тип изменения: {1}; Объект Note: {2}", NameCollection, TypeChange, Note);
        }
    }
}
