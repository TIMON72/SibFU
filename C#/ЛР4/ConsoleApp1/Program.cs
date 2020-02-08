using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            NoteCollection notes = new NoteCollection("Коллекция 1");
            Journal journal = new Journal();

            notes.OnNoteCountChanged += journal.NoteCountChanged; // Подписка метода NoteCountChanged класса Journal
            notes.OnNoteReferenceChanged += journal.NoteReferenceChanged; // Подписка метода NoteReferenceChanged класса Journal

            notes.AddDefaults(); // Добавляем заготовленные объекты
            notes.Remove(1); // Удаляем объект из списка с индексом 1
            notes[0] = notes[2]; // Заменяем данные объекта с индексом 0 на данные объекта с индексом 2
            Console.WriteLine(journal.ToString()); // Вывод на консоль

            //notes.SortBy("SurnameName");
            notes.Sort((x, y) => x.SurnameName.CompareTo(y.SurnameName));
            Console.WriteLine("Сортировка по фамилии и имени:\n" + notes.ToString());
            notes.Sort((x, y) => x.Phone.CompareTo(y.Phone));
            Console.WriteLine("Сортировка по телефону:\n" + notes.ToString());
            notes.Sort((x, y) => x.DOB.CompareTo(y.DOB));
            Console.WriteLine("Сортировка по дате рождения:\n" + notes.ToString());

            journal.SortByTypeChange();
            Console.WriteLine("Сортировка в журнале по типу изменения:\n" + journal.ToString());

            Console.ReadKey();
        }
    }
}
