using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Note
    {
        public string SurnameName { get; set; }
        public string Phone { get; set; }
        public string DOB { get; set; }
        CardIndex cardIndex = null;
        public CardIndex CardIndex
        {
            set
            {
                cardIndex = value;
            }
        }
        public int ? CardIndexNumber
        {
            get
            {
                if (cardIndex is null)
                {
                    return null;
                }
                else
                {
                    return cardIndex.Number;
                }
            }
        }

        static List<Note> notes = new List<Note>();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="note"></param>
        public Note(string surnameName, string phone, string DOB)
        {
            SurnameName = surnameName;
            Phone = phone;
            this.DOB = DOB;
        }
        /// <summary>
        /// Заполнение и получение заполненного списка
        /// </summary>
        public static List<Note> GetCompletedList()
        {
            notes.Add(new Note("Андрей Андреевич", "+9 (999) 999-99-99)", "11.01.1990"));
            notes.Add(new Note("Константин Константинович", "+2 (323) 245-38-75)", "11.01.1994"));
            notes.Add(new Note("Тимур Тимурович", "+2 (873) 145-35-84)", "11.01.1995"));
            notes.Add(new Note("Федр Федорович", "+2 (982) 244-31-95)", "11.01.1992"));
            notes.Add(new Note("Василий Васильевич", "+2 (923) 655-05-23)", "11.01.1991"));
            notes.Add(new Note("Петр Петрович", "+1 (456) 123-03-00)", "11.01.1995"));
            notes.Add(new Note("Сергей Сергеевич", "+3 (333) 547-47-12)", "11.01.1991"));
            notes.Add(new Note("Виталий Витальевич", "+1 (789) 010-11-99)", "11.01.1993"));
            notes.Add(new Note("Иван Иванович", "+1 (234) 567-89-00)", "11.01.2001"));
            return notes;
        }
        /// <summary>
        /// Перегрузка метода ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Фамилия Имя: {0}; Телефон: {1}; Дата рождения: {2}", SurnameName, Phone, DOB);
        }
    }
}
