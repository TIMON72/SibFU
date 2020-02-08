using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class ExtentionMethods
    {
        /// <summary>
        /// Метод-расширение для вычисления длины строки
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int StringLength(this string s)
        {
            int result = s.Length;
            return result;
        }
    }
}
