using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.classes
{
    class Reader
    {
        public string id { get; set; }
        public List<Book> listBooks = new List<Book>(); // Список книг читателя
        // Конструктор класса
        public Reader(string id)
        {
            this.id = id;
            Model.AddReader(this); // Добавляет объект к списку при его создании
        }
    }
}
