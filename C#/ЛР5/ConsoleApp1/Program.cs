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
            // Заполняем списки записей и картотек
            Console.WriteLine("\nЗаполняем списки записей и картотек\n");
            List<Note> notes = Note.GetCompletedList();
            for (int i = 0; i < notes.Count; i++)
            {
                Console.WriteLine(notes[i]);
            }
            List<CardIndex> cardIndexes = CardIndex.GetCompletedList();
            for (int i = 0; i < cardIndexes.Count; i++)
            {
                Console.WriteLine(cardIndexes[i]);
            }
            // Связываем записи с картотеками
            Console.WriteLine("\nСвязываем записи с картотеками\n");
            int counter = 0;
            for (int i = 0; i < notes.Count; i++, counter++)
            {
                if (counter > cardIndexes.Count - 1)
                    counter = 0;
                notes[i].CardIndex = cardIndexes[counter];
                Console.WriteLine(notes[i] + " --- связан с картотекой " + notes[i].CardIndexNumber);
            }
            // Запрос Inner Join
            Console.WriteLine("\nЗапрос Inner Join\n");
            var innerJoinQuery = from n in notes
                                 join ci in cardIndexes on n.CardIndexNumber equals ci.Number
                                 select new { SurnameName = n.SurnameName, Number = ci.Number };
            foreach (var item in innerJoinQuery)
                Console.WriteLine("{0} - {1}", item.SurnameName, item.Number);
            // Запрос Group Join и использование метода-расширения
            Console.WriteLine("\nЗапрос Group Join и использование метода-расширения\n");
            var groupJoin = cardIndexes.GroupJoin(
                        notes,
                        ci => ci.Number,
                        n => n.CardIndexNumber,
                        (cardIndex, nts) => new
                        {
                            Name = cardIndex.Name,
                            Number = cardIndex.Number,
                            Notes = nts.Select(n => n.SurnameName).OrderBy(s => s.StringLength())
                        });
            foreach (var cardIndex in groupJoin)
            {
                Console.WriteLine(cardIndex.Name);
                foreach (string note in cardIndex.Notes)
                {
                    Console.WriteLine(note + ", длина строки: " + note.StringLength());
                }
            }
            // Доп. задание - запрос GroupBy с применением .Key
            Console.WriteLine("\nЗапрос GroupBy с применением .Key\n");
            var groupBy = notes.GroupBy(n => n.CardIndexNumber);
            foreach (var groupNotes in groupBy)
            {
                Console.WriteLine("Картотека: " + groupNotes.Key);
                foreach (Note note in groupNotes)
                {
                    Console.WriteLine(note + ", длина строки: " + note.SurnameName.StringLength());
                }
            }
            Console.ReadKey();
        }
    }
}
