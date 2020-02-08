using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CardIndex
    {
        public string Name { get; set; }
        public int Number { get; set; }

        static List<CardIndex> cardIndexes = new List<CardIndex>();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        public CardIndex(string name, int number)
        {
            Name = name;
            Number = number;
        }
        /// <summary>
        /// Заполнение и получение списка
        /// </summary>
        public static List<CardIndex> GetCompletedList()
        {
            cardIndexes.Add(new CardIndex("Картотека 1", 1));
            cardIndexes.Add(new CardIndex("Картотека 2", 2));
            cardIndexes.Add(new CardIndex("Картотека 3", 3));
            cardIndexes.Add(new CardIndex("Картотека 4", 4));
            cardIndexes.Add(new CardIndex("Картотека 5", 5));
            return cardIndexes;
        }
        /// <summary>
        /// Перегрузка метода ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Название: {0}; Номер: {1}", Name, Number);
        }
    }
}
