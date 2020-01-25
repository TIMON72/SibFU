using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.classes
{
    class TTransport : Form
    {
        public string speed { get; set; }
        public string weight { get; set; }
        public string numberOfSeats { get; set; }
        // Список транспорта
        private static List<TTransport> transports = new List<TTransport>();
        /// <summary>
        /// Конструктор TTransport
        /// </summary>
        public TTransport()
        {
            transports.Add(this); // Добавляет объект к списку при его создании
        }
        /// <summary>
        /// Метод получения индекса транспорта в списке
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static TTransport GetTransport(int index)
        {
            return transports[index];
        }
        /// <summary>
        /// Расширяемый метод получения информации об объекте
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual string GetObjectInformation(int index)
        {
            return "";
        }
    }
}
