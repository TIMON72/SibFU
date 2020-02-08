using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Journal
    {
        private List<JournalEntry> journal = new List<JournalEntry>();
        /// <summary>
        /// Запись в журнал события изменения количества объектов в коллекции
        /// </summary>
        /// <param name="sourse"></param>
        /// <param name="args"></param>
        public void NoteCountChanged(object sourse, NoteListHandlerEventArgs args)
        {
            journal.Add(new JournalEntry(args.NameCollection, DateTime.Now, args.TypeChange, args.Note.ToString()));
        }
        /// <summary>
        /// Запись в журнал события изменения ссылки в коллекции
        /// </summary>
        /// <param name="sourse"></param>
        /// <param name="args"></param>
        public void NoteReferenceChanged(object sourse, NoteListHandlerEventArgs args)
        {
            journal.Add(new JournalEntry(args.NameCollection, DateTime.Now, args.TypeChange, args.Note.ToString()));
        }
        /// <summary>
        /// Сортировка по типу изменения
        /// </summary>
        public void SortByTypeChange()
        {
            journal.Sort((x, y) => x.TypeChange.CompareTo(y.TypeChange));
        }
        /// <summary>
        /// Перегрузка метода ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < journal.Count; i++)
                result += journal[i].ToString() + "\n";
            return result;
        }
    }
}
