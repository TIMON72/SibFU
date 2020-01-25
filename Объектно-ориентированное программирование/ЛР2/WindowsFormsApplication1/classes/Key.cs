using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.classes
{
    class Key
    {
        public int keyOfList { get; set; } // Индекс в списке
        public string keyOfTable { get; set; } // Индекс в таблице

        public static List<Key> keys = new List<Key>(); // Список ключей для поиска
    }
}
