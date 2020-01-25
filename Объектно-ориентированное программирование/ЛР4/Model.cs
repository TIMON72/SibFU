using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.classes;

namespace WindowsFormsApplication1
{
    class Model
    {
        public enum Fields
        {
            ID,
            name,
            author,
            year,
            publisher,
            amount
        };
        static List<Book> books = new List<Book>(); // БД книг
        static List<Reader> readers = new List<Reader>(); // БД читателей
        /// <summary>
        /// Добавление новой книги в БД книг
        /// </summary>
        /// <param name="newBook"></param>
        public static void AddBook(Book newBook)
        {
            books.Add(newBook);
        }
        /// <summary>
        /// Добавление нового читателя в БД читателей
        /// </summary>
        /// <param name="newReader"></param>
        public static void AddReader(Reader newReader)
        {
            readers.Add(newReader);
        }
        /// <summary>
        /// Проверка ID читателя в БД читателей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Identification(string id)
        {
            for (int i = 0; i < readers.Count; i++)
            {
                if (id == readers[i].id)
                {
                    return 1;
                }
            }
            return 0;
        }
        /// <summary>
        /// Получение данных о книге
        /// </summary>
        /// <param name="index"></param>
        /// <param id="id"></param>
        /// <param column="column"></param>
        /// <returns></returns>
        public string GetFieldOfBook(int index, int column)
        {
            string value;
            switch ((Fields)column)
            {
                case Fields.ID:
                    value = books[index].id;
                    return value;
                case Fields.name:
                    value = books[index].name;
                    return value;
                case Fields.author:
                    value = books[index].author;
                    return value;
                case Fields.year:
                    value = books[index].year;
                    return value;
                case Fields.publisher:
                    value = books[index].publisher;
                    return value;
                case Fields.amount:
                    value = books[index].amount;
                    return value;
            }
            return "error";
        }
        public string GetFieldOfBook(int index, int id, int column)
        {
            string value;
            switch ((Fields)column)
            {
                case Fields.ID:
                    value = readers[id].listBooks[index].id;
                    return value;
                case Fields.name:
                    value = readers[id].listBooks[index].name;
                    return value;
                case Fields.author:
                    value = readers[id].listBooks[index].author;
                    return value;
                case Fields.year:
                    value = readers[id].listBooks[index].year;
                    return value;
                case Fields.publisher:
                    value = readers[id].listBooks[index].publisher;
                    return value;
                case Fields.amount:
                    value = readers[id].listBooks[index].amount;
                    return value;
            }
            return "error";
        }
        /// <summary>
        /// Добавление книги читателю
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nameOfBook"></param>
        /// <returns></returns>
        public int[] AddBookToReader(int id, string ID_book)
        {
            int[] result = new int[3];
            // Поиск запрашиваемой книги у читателя
            for (int i = 0; i < readers[id].listBooks.Count; i++)
            {
                // Если книга уже есть у читателя
                if (ID_book == readers[id].listBooks[i].id)
                {
                    int position = Convert.ToInt32(readers[id].listBooks[i].id);
                    // Если количество книг в БД равно "0"
                    if (books[position].amount == "0")
                    {
                        result[0] = 0;
                        return result;
                    }
                    // Понижаем кол-во книг в БД книг и увеличиваем кол-во книг у читателя
                    int amount = Convert.ToInt32(readers[id].listBooks[i].amount);
                    amount++;
                    readers[id].listBooks[i].amount = amount.ToString();
                    result[0] = amount;
                    amount = Convert.ToInt32(books[position].amount);
                    amount--;
                    books[position].amount = amount.ToString();
                    result[1] = amount;
                    result[2] = i;
                    return result;
                }
            }
            // Если запрашиваемой книги нет у читателя
            for (int i = 0; i < books.Count; i++)
            {
                // Если запрашиваемая книга есть в БД библиотеки
                if (ID_book == books[i].id)
                {
                    // Если количество книг в БД равно "0"
                    if (books[i].amount == "0")
                    {
                        result[0] = 0;
                        return result;
                    }
                    // Понижаем кол-во книг в БД книг и увеличиваем кол-во книг у читателя
                    Book book = new Book(books[i].id, books[i].name, books[i].author, books[i].year, books[i].publisher, "1");
                    readers[id].listBooks.Add(book);
                    result[0] = Convert.ToInt32(readers[id].listBooks[readers[id].listBooks.Count - 1].amount);
                    int amount = Convert.ToInt32(books[i].amount);
                    amount--;
                    books[i].amount = Convert.ToString(amount);
                    result[1] = amount;
                    return result;
                }
            }
            return result;
        }
        /// <summary>
        /// Удаление книги у читателя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nameOfBook"></param>
        /// <returns></returns>
        public int[] DeleteBookOfReader(int id, string ID_book)
        {
            int[] result = new int[3];
            // Поиск запрашиваемой книги у читателя
            for (int i = 0; i < readers[id].listBooks.Count; i++)
            {
                // Если запрашиваемая книга есть у читателя
                if (ID_book == readers[id].listBooks[i].id)
                {
                    // Если книга у читателя одна
                    if (readers[id].listBooks[i].amount == "1")
                    {
                        result[0] = 0;
                        int position = Convert.ToInt32(readers[id].listBooks[i].id);
                        result[2] = position;
                        int amount = Convert.ToInt32(books[position].amount);
                        amount++;
                        result[1] = amount;
                        books[position].amount = amount.ToString();
                        readers[id].listBooks.RemoveAt(i);
                        return result;
                    }
                    // Если книг более, чем одна
                    else
                    {
                        int amount = Convert.ToInt32(readers[id].listBooks[i].amount);
                        amount--;
                        result[0] = amount;
                        readers[id].listBooks[i].amount = amount.ToString();
                        int position = Convert.ToInt32(readers[id].listBooks[i].id);
                        result[2] = position;
                        amount = Convert.ToInt32(books[position].amount);
                        amount++;
                        result[1] = amount;
                        books[position].amount = amount.ToString();
                        return result;
                    }
                }
            }
            return result;
        } 
        /// <summary>
        /// Получение количества книг читателя
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetCountOfBooksOfReader(int index)
        {
            int count = readers[index].listBooks.Count;
            return count;
        }
        /// <summary>
        /// Заполнение списков readers (10) и books (5) тестовыми данными
        /// </summary>
        /// <returns></returns>
        public int FillTestData()
        {
            Reader reader1 = new Reader("0");
            Reader reader2 = new Reader("1");
            Reader reader3 = new Reader("2");
            Reader reader4 = new Reader("3");
            Reader reader5 = new Reader("4");
            Reader reader6 = new Reader("5");
            Reader reader7 = new Reader("6");
            Reader reader8 = new Reader("7");
            Reader reader9 = new Reader("8");
            Reader reader10 = new Reader("9");
            Book book1 = new Book("0", "book1", "author1", "2000", "publisher1", "1");
            Book book2 = new Book("1", "book2", "author1", "2003", "publisher2", "3");
            Book book3 = new Book("2", "book1", "author2", "2003", "publisher2", "4");
            Book book4 = new Book("3", "book3", "author3", "2003", "publisher2", "2");
            Book book5 = new Book("4", "book4", "author4", "2005", "publisher1", "5");
            return 1;
        }
    }
}
