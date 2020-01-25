using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.classes
{
    class Book
    {
        public string id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string year { get; set; }
        public string publisher { get; set; }
        public string amount { get; set; }
        // Конструктор класса
        public Book(string id, string name, string author, string year, string publisher, string amount)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.year = year;
            this.publisher = publisher;
            this.amount = amount;
            Model.AddBook(this); // Добавляет объект к списку при его создании
        }
    }
}
