using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    delegate void NoteListHandler(object source, NoteListHandlerEventArgs args);

    class NoteCollection
    {
        // Свойства класса
        public string NameCollection { get; set; } = "NoteCollection";
        // Инициализация делегатов и событий
        NoteListHandler NoteCountChanged; // Иницилизация делегата NoteListHandler
        public event NoteListHandler OnNoteCountChanged // Подпискаи отписка метода через событие (обычное описание события с добавлением add и remove) 
        {
            add { NoteCountChanged += value; }
            remove { NoteCountChanged -= value; }
        }
        NoteListHandler NoteReferenceChanged;
        public event NoteListHandler OnNoteReferenceChanged
        {
            add { NoteReferenceChanged += value; }
            remove { NoteReferenceChanged -= value; }
        }
        // Список
        List<Note> notes = new List<Note>();
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="nameCollection"></param>
        public NoteCollection(string nameCollection)
        {
            NameCollection = nameCollection;
        }
        /// <summary>
        /// Добавление элемента в список по заданному индексу
        /// </summary>
        /// <param name="j"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public bool Add(int j, Note record)
        {
            try
            {
                notes.Insert(j, record);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            NoteCountChanged?.Invoke(this, new NoteListHandlerEventArgs(NameCollection, "Добавление в список", notes[j]));
            return true;
        }
        /// <summary>
        /// Удаление элемента из списка по заданному индексу
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool Remove(int j)
        {
            Note oldNote = notes[j];
            try
            {
                notes.RemoveAt(j);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            NoteCountChanged?.Invoke(this, new NoteListHandlerEventArgs(NameCollection, "Удаление из списка", oldNote));
            return true;
        }
        /// <summary>
        /// Индекстатор this типа Note для доступа к элементу списка по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Note this[int index]
        {
            get
            {
                return notes[index];
            }
            set
            {
                NoteReferenceChanged?.Invoke(this, new NoteListHandlerEventArgs(NameCollection, "Измененяется", notes[index]));
                notes[index] = value;
                NoteReferenceChanged?.Invoke(this, new NoteListHandlerEventArgs(NameCollection, "Изменили", notes[index]));
            }
        }
        /// <summary>
        /// Заполнение списка заготовленными объектами
        /// </summary>
        public void AddDefaults()
        {
            Note note = new Note(new Tuple<string, string, string>("Иван Васильевич", "+7 (987) 654-32-11", "01.11.1993"));
            notes.Add(note);
            NoteCountChanged?.Invoke(this, new NoteListHandlerEventArgs(NameCollection, "Добавление в список", note));
            note = new Note(new Tuple<string, string, string>("Петр Петрович", "+7 (123) 456-78-90", "01.11.1997"));
            notes.Add(note);
            NoteCountChanged?.Invoke(this, new NoteListHandlerEventArgs(NameCollection, "Добавление в список", note));
            note = new Note(new Tuple<string, string, string>("Иван Иванович", "+7 (111) 222-33-44", "01.11.1992"));
            notes.Add(note);
            NoteCountChanged?.Invoke(this, new NoteListHandlerEventArgs(NameCollection, "Добавление в список", note));
            note = new Note(new Tuple<string, string, string>("Сергей Сергеевич", "+7 (222) 333-44-55", "01.11.1991"));
            notes.Add(note);
            NoteCountChanged?.Invoke(this, new NoteListHandlerEventArgs(NameCollection, "Добавление в список", note));
            note = new Note(new Tuple<string, string, string>("Виталий Витальевич", "+7 (333) 444-55-66", "01.11.1995"));
            notes.Add(note);
            NoteCountChanged?.Invoke(this, new NoteListHandlerEventArgs(NameCollection, "Добавление в список", note));
        }
        /// <summary>
        /// Сортировка по полям
        /// </summary>
        /// <param name="fieldName"></param>
        public void SortBy(string fieldName)
        {
            notes.Sort(delegate (Note note1, Note note2)
            {
                if (fieldName == "SurnameName")
                {
                    return note1.SurnameName.CompareTo(note2.SurnameName);
                }
                else if (fieldName == "Phone")
                {
                    return note1.Phone.CompareTo(note2.Phone);
                }
                else if (fieldName == "DOB")
                {
                    return note1.DOB.CompareTo(note2.DOB);
                }
                else
                    return 0;
            });
        }
        /// <summary>
        /// Сортировка
        /// </summary>
        /// <param name="comparison"></param>
        public void Sort(Comparison<Note> comparison)
        {
            notes.Sort(comparison);
        }
        /// <summary>
        /// Перегрузка метода ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < notes.Count; i++)
                result += notes[i].ToString() + "\n";
            return result;
        }
    }
}
