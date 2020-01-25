using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ViewModel
    {
        static ViewModel viewModel { get; set; }
        Model model = new Model();
        /// <summary>
        /// Создание объекта класса ViewModel
        /// </summary>
        /// <returns></returns>
        public static ViewModel GetObjectOfViewModel()
        {
            if (viewModel == null)
                viewModel = new ViewModel();
            return viewModel;
        }
        /// <summary>
        /// ViewModel идентификации читателя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Identification(string id)
        {
            int result = model.Identification(id);
            if (result == 1)
            {
                return "Идентификация прошла успешно";
            }
            return "Ошибка идентификации";
        }
        /// <summary>
        /// ViewModel получения данных о книге
        /// </summary>
        /// <param name="index"></param>
        /// <param id="id"></param>
        /// <returns></returns>
        public string GetFieldOfBook(int index, int column)
        {
            string value = model.GetFieldOfBook(index, column);
            if (value != "error")
            {
                return value;
            }
            value = "---";
            return value;
        }
        public string GetFieldOfBook(int index, int id, int column)
        {
            string value = model.GetFieldOfBook(index, id, column);
            if (value != "error")
            {
                return value;
            }
            value = "---";
            return value;
        }
        /// <summary>
        /// ViewModel добавления книги читателю
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nameOfBook"></param>
        /// <returns></returns>
        public int[] AddBookToReader(int id, string ID_book)
        {
            int[] result = model.AddBookToReader(id, ID_book);
            if (result[0] >= 0)
            {
                return result;
            }
            result[0] = -1;
            return result;
        }
        /// <summary>
        /// ViewModel удаления книги у читателя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nameOfBook"></param>
        /// <returns></returns>
        public int[] DeleteBookOfReader(int id, string ID_book)
        {
            int[] result = model.DeleteBookOfReader(id, ID_book);
            if (result[0] >= 0)
            {
                return result;
            }
            result[0] = -1;
            return result;
        }
        /// <summary>
        /// ViewModel полученя количества книг читателя
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetCountOfBooksOfReader(int index)
        {
            int count = model.GetCountOfBooksOfReader(index);
            if (count >= 0)
            {
                return count;
            }
            count = 0;
            return count;
        }
        /// <summary>
        /// ViewModel заполнения списков тестовыми данными
        /// </summary>
        /// <returns></returns>
        public string FillTestData()
        {
            int result = model.FillTestData();
            if (result == 1)
            {
                return "Успех";
            }
            return "Ошибка заполнения тестовых объектов БД";
        }
    }
}