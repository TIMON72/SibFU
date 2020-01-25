using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP
{
    class Data : IComparable<Data>
    {
        // Свойства класса
        public int Column { get; set; }
        public string Value { get; set; }
        public static int DeviationLimit { get; set; } = 25; // Коэффициент для умножения на среднее значение для выявления аномальных значений 
        // Переменные класса
        static bool initialization = false;
        static int columnCount;
        static int inputColumnCount;
        //static int outputColumnCount;
        static double[] minValues;
        static double[] maxValues;
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
        /// <param name="inputData"></param>
        /// <param name="outputData"></param>
        /// <returns></returns>
        public static void Normalization(ref List<string[]> inputData, ref List<string> outputData)
        {
            List<double[]> dataList_double = new List<double[]>();
            columnCount = inputData[0].Length + 1;
            inputColumnCount = inputData[0].Length;
            //int outputColumnCount = 1;
            if (!initialization)
            {
                minValues = new double[columnCount];
                maxValues = new double[columnCount];
            }
            // Инициализация вложенных массивов списка
            for (int i = 0; i < inputData.Count; i++)
                dataList_double.Add(new double[columnCount]);
            // Преобразуем список строковых данных в double-данные
            for (int i = 0; i < inputData.Count; i++)
                for (int j = 0; j < columnCount; j++)
                {
                    if (j < inputColumnCount)
                        dataList_double[i][j] = double.Parse(inputData[i][j].Replace(".", ","));
                    else
                        dataList_double[i][j] = double.Parse(outputData[i].Replace(".", ","));
                }
            // Работа с каждой из колонок
            for (int j = 0; j < columnCount; j++)
            {
                double[] columnValues = new double[inputData.Count];
                for (int i = 0; i < inputData.Count; i++)
                {
                    columnValues[i] = dataList_double[i][j];
                }
                double averageValue = columnValues.Average();
                if (!initialization)
                {
                    maxValues[j] = columnValues.Max();
                    minValues[j] = columnValues.Min();
                }
                // Поиск и исключение аномальных данных
                // Среднее значение между 0 и 1?
                if (Math.Abs(averageValue) < 1)
                    averageValue = 1;
                // Максимальное значение превышает среднее в 5 раз?
                if (Math.Abs(maxValues[j]) > Math.Abs(averageValue * DeviationLimit))
                {
                    int index = Array.IndexOf(columnValues, maxValues[j]);
                    inputData.RemoveAt(index);
                    outputData.RemoveAt(index);
                    dataList_double.RemoveAt(index);
                    j--;
                }
                // Минимальное значение превышает среднее в 5 раз?
                else if (Math.Abs(minValues[j]) > Math.Abs(averageValue) * DeviationLimit)
                {
                    int index = Array.IndexOf(columnValues, minValues[j]);
                    inputData.RemoveAt(index);
                    outputData.RemoveAt(index);
                    dataList_double.RemoveAt(index);
                    j--;
                }
            }
            initialization = true;
            // Выполним нормализацию
            for (int i = 0; i < inputData.Count; i++)
                for (int j = 0; j < columnCount; j++)
                {
                    double min = minValues[j];
                    double max = maxValues[j];
                    double curr = dataList_double[i][j];
                    if (max - min == 0)
                        if (j < inputColumnCount)
                            inputData[i][j] = "0,001";
                        else
                            outputData[i] = "0,001";
                    else if (curr - min == 0)
                        if (j < inputColumnCount)
                            inputData[i][j] = "0,001";
                        else
                            outputData[i] = "0,001";
                    else if (curr == max)
                        if (j < inputColumnCount)
                            inputData[i][j] = "0,999";
                        else
                            outputData[i] = "0,999";
                    else
                        if (j < inputColumnCount)
                        inputData[i][j] = ((curr - min) / (max - min)).ToString();
                    else
                        outputData[i] = ((curr - min) / (max - min)).ToString();
                }
        }
        /// <summary>
        /// Денормализация выходных значений
        /// </summary>
        /// <param name="normalizeValue"></param>
        /// <returns></returns>
        public static string OutputDenormalization(string normalizeValue)
        {
            string denormalizeValue = "";
            double norm = Convert.ToDouble(normalizeValue);
            double max = maxValues[columnCount - 1];
            double min = minValues[columnCount - 1];
            denormalizeValue = (norm * (max - min) + min).ToString();
            //OutputCategoryDictionary.TryGetValue(normalizeValue, out string denormalizeValue);
            return denormalizeValue;
        }
    }
}
