using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP
{
    class Data : IComparable<Data>
    {
        public int Column { get; set; }
        public string Value { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public Data(int column, string value)
        {
            Column = column;
            Value = value;
        }
        /// <summary>
        /// Сортировка
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Data> Sort(List<Data> list)
        {
            return list.OrderBy(d => d.Column).ThenBy(d => double.Parse(d.Value)).ToList();
        }
        /// <summary>
        /// Группировка и очистка повторяющихся элементов
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Data> GroupAndDistinct(List<Data> list)
        {
            IEnumerable<Data> dataGroupAndDistinct = list.GroupBy(d => new { d.Column, d.Value }).Select(group => group.First());
            List<Data> resultList = new List<Data>();
            foreach (Data d in dataGroupAndDistinct)
                resultList.Add(d);
            return resultList;
        }
        /// <summary>
        /// Реализация интерфейса IComparable для сравнения объекта Data
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        int IComparable<Data>.CompareTo(Data other)
        {
            double otherDbl = double.Parse(other.Value);
            double thisDbl = double.Parse(Value);

            if (otherDbl > thisDbl)
                return -1;
            else if (otherDbl == thisDbl)
                return 0;
            else
                return 1;
        }
        /// <summary>
        /// Замена входных данных на нормализованные значения
        /// </summary>
        /// <param name="valueList"></param>
        /// <param name="outList"></param>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        public static List<string[]> ChangeColumns(List<Data> valueList, List<string[]> outList, int columnCount)
        {
            double[] minValues = new double[columnCount];
            double[] maxValues = new double[columnCount];
            // Преобразуем список строковых данных в данные категорий
            for (int i = 0; i < columnCount; i++)
            {
                List<Data> dataColumnList = valueList.FindAll(dv => dv.Column == i); // Получаем все значения колонки
                // Проверяем, является ли содержимое колонки числовым
                try
                {
                    double.Parse(dataColumnList[0].Value);
                    minValues[i] = double.Parse(dataColumnList.Min().Value);
                    maxValues[i] = double.Parse(dataColumnList.Max().Value);
                }
                catch (FormatException) // Выполняем категоризацию, если поле не числовое
                {
                    minValues[i] = 1;
                    maxValues[i] = dataColumnList.Count;
                    for (int j = 0; j < outList.Count; j++)
                    {
                        outList[j][i] = (dataColumnList.IndexOf(dataColumnList.Find(dc => dc.Value == outList[j][i])) + 1).ToString();
                    }
                }
            }
            // Выполним нормализацию
            for (int i = 0; i < outList.Count; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    double min = minValues[j];
                    double max = maxValues[j];
                    double curr = Convert.ToDouble(outList[i][j]);
                    if (max - min == 0)
                        outList[i][j] = "0,001";
                    else if (curr - min == 0)
                        outList[i][j] = "0,001";
                    else if (curr == max)
                        outList[i][j] = "0,999";
                    else
                        outList[i][j] = ((curr - min) / (max - min)).ToString();
                }
            }
            return outList;
        }
        public static List<string> ChangeColumns(List<Data> valueList, List<string> outList, int columnIndex)
        {
            double minValue = 0;
            double maxValue = 0;
            // Преобразуем список строковых данных в данные категорий
            List<Data> dataColumnList = valueList.FindAll(dv => dv.Column == columnIndex); // Получаем все значения колонки                                                                              // Проверяем, является ли содержимое колонки числовым
            // Проверяем, является ли содержимое колонки числовым
            try
            {
                double.Parse(dataColumnList[0].Value);
                minValue = double.Parse(dataColumnList.Min().Value);
                maxValue = double.Parse(dataColumnList.Max().Value);
            }
            catch (FormatException) // Выполняем категоризацию, если поле не числовое
            {
                minValue = 1;
                maxValue = dataColumnList.Count;
                for (int i = 0; i < outList.Count; i++)
                {
                    outList[i] = (dataColumnList.IndexOf(dataColumnList.Find(dc => dc.Value == outList[i])) + 1).ToString();
                }
            }
            // Выполним нормализацию
            for (int i = 0; i < outList.Count; i++)
            {
                double min = minValue;
                double max = maxValue;
                double curr = Convert.ToDouble(outList[i]);
                if (max - min == 0)
                    outList[i] = "0,001";
                else if (curr - min == 0)
                    outList[i] = "0,001";
                else if (curr == max)
                    outList[i] = "0,999";
                else
                    outList[i] = ((curr - min) / (max - min)).ToString();
            }
            return outList;
        }
    }
}
