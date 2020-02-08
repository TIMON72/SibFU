using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MLP
{
    public static class Perceptron
    {
        // Списки данных
        static List<string> columnNames = new List<string>(); // Инициализация колонок данных
        static List<string[]> inputTeachingData = new List<string[]>(); // Инициализация обучающих входных данных
        static List<string> outputTeachingData = new List<string>(); // Инициализация обучающих выходных данных
        static List<string[]> inputRealData = new List<string[]>(); // Инициализация реальных входных данных
        static List<string> outputRealData = new List<string>(); // Инициализация реальных выходных данных
        // Параметры нейронной сети
        static double[] input; // Входной слой
        static double[] layer1 = new double[4]; // Скрытый слой 1
        //static double[] output; // Выходной слой
        static double[] output = new double[1]; // Выходной слой
        static double[,] w1; // Веса между входным и 1 скрытым слоем
        static double[,] w2; // Веса между 1 скрытым слоем и выходным

        /// <summary>
        /// Считывание обучающей выборки из файла с N входами и 2 выходами
        /// </summary>
        /// <param name="resourceFileName"></param>
        static void ReadFileCSV(string resourceFileName, List<string[]> inputData, List<string> outputData, bool clear)
        {
            string file = (string)Properties.Resources.ResourceManager.GetObject(resourceFileName);
            file = file.Replace("\"", "");
            string[] reader = file.Split('\n');
            string[] str;
            List<Data> dataList = new List<Data>();
            // Очистка данных
            columnNames.Clear();
            inputData.Clear();
            outputData.Clear();
            // Считываем построчно и преобразуем данные в нужный формат
            for (int i = 0; i < reader.Length; i++)
            {
                str = reader[i].Split(';');
                if (i == 0)
                {
                    for (int j = 0; j < str.Length; j++)
                        columnNames.Add(str[j]);
                    if (clear)
                    {
                        input = new double[columnNames.Count - 1]; // Инициализация количества входов
                        w1 = new double[input.Length, layer1.Length]; // Инициализация весов между входным и скрытым слоями
                        //output = new double[] { 0, 1 }; // Инициализация количества выходов со значениями 0 и 1
                        w2 = new double[layer1.Length, output.Length]; // Инициализация весов между скрытым и выходным слоями
                    }
                }
                // Иначе извлекаем данные и конвертируем в нужный формат
                else
                {
                    string[] newInputData = new string[input.Length];
                    string[] newOutputData = new string[output.Length];
                    for (int j = 0; j < str.Length; j++)
                    {
                        // Если считана пустая строка, то заканчиваем извлечение данных
                        if (str[j] == "")
                            break;
                        // Иначе конвертируем данные
                        else
                        {
                            dataList.Add(new Data(j, str[j]));
                            string field = str[j];
                            if (j < input.Length)
                                newInputData[j] = field;
                            else
                                newOutputData[0] = field;
                        }
                    }
                    inputData.Add(newInputData);
                    outputData.Add(newOutputData[0]);
                }
            }
            // Выполняем нормализацию значений
            List<Data> dataValueList = Data.GroupAndDistinct(dataList); // Получаем уникальные значения колонок
            inputData = Data.ChangeColumns(dataValueList, inputData, input.Length); // Нормализуем входные параметры
            outputData = Data.ChangeColumns(dataValueList, outputData, input.Length); // Нормализуем выходные параметры
        }
        /// <summary>
        /// Инициализация данных
        /// </summary>
        static public void InitializeData()
        {
            ReadFileCSV("sgemm_product_study", inputTeachingData, outputTeachingData, true);
            ReadFileCSV("sgemm_product_real", inputRealData, outputRealData, false);
        }
        /// <summary>
        /// Конвертирование входных данных из строки в числовые значения входов
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        static double[] ConvertInputStringToInputDouble(string[] inputStr)
        {
            double[] inputDbl = new double[input.Length];
            for (int i = 0; i < inputDbl.Length; i++)
                inputDbl[i] = Convert.ToDouble(inputStr[i]);
            return inputDbl;
        }
        /// <summary>
        /// Инициализация весов
        /// </summary>
        static void InitializeWeights()
        {
            Random rnd = new Random();
            for (int i = 0; i < w1.GetLength(0); i++)
                for (int j = 0; j < w1.GetLength(1); j++)
                {
                    w1[i, j] = rnd.Next(-5, 6) * 0.1;
                }
            for (int i = 0; i < w2.GetLength(0); i++)
                for (int j = 0; j < w2.GetLength(1); j++)
                {
                    w2[i, j] = rnd.Next(-5, 6) * 0.1;
                }
        }
        /// <summary>
        /// Сумматор
        /// </summary>
        /// <param name="x"></param>
        /// <param name="w"></param>
        /// <param name="neuron"></param>
        /// <returns></returns>
        static double Adder(double[] x, double[,] w, int neuron)
        {
            double sumW = 0;
            for (int i = 0; i < x.Length; i++)
                sumW += x[i] * w[i, neuron];
            return sumW;
        }
        /// <summary>
        /// Функция активации
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        static double ActivationFunc(double t) => 1.0 / (1.0 + Math.Exp(-t));
        /// <summary>
        /// Ответ нейросети
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static double Answer(double[] input)
        {
            // Проход через скрытый слой layer1
            for (int i = 0; i < layer1.Length; i++)
            {
                double sumW = Adder(input, w1, i); // Сумматор i-го нейрона
                layer1[i] = ActivationFunc(sumW); // Функция активации для сумматора
            }
            // Проход через выходной слой output
            for (int i = 0; i < output.Length; i++)
            {
                double sumW = Adder(layer1, w2, i); // Сумматор i-го нейрона
                output[i] = sumW;
            }
            return output[0];
        }
        /// <summary>
        /// Метод обратного распространения ошибки
        /// </summary>
        /// <param name="expOut"></param>
        /// <param name="eta"></param>
        static void Backpropagation(double expOut, double eta)
        {
            double outQ = 0; // Реальный выход слоя Q
            double outP = 0; // Реальный выход слоя P
            double tQ = 0; // Ожидаемый выход слоя Q
            double[] delta2 = new double[output.Length]; // Различие между реальным и ожидаемым результатом слоев layer1-output
            double[] delta1 = new double[layer1.Length]; // Различие между реальным и ожидаемым результатом слоев input-layer1
                                                         // Корректируем веса между слоями output(Q) и layer1(P)
            for (int i = 0; i < w2.GetLength(0); i++)
                for (int j = 0; j < w2.GetLength(1); j++)
                {
                    outQ = output[j];
                    outP = layer1[i];
                    tQ = expOut;
                    delta2[j] = 1 * (tQ - outQ);
                    w2[i, j] = w2[i, j] + eta * delta2[j] * outP;
                }
            // Корректируем веса между слоями layer1(Q) и input(P)
            for (int i = 0; i < w1.GetLength(0); i++)
                for (int j = 0; j < w1.GetLength(1); j++)
                {
                    double sum = 0;
                    for (int k = 0; k < output.Length; k++)
                    {
                        sum += delta2[k] * w2[j, k];
                    }
                    outQ = layer1[j];
                    outP = input[i];
                    delta1[j] = outQ * (1 - outQ) * sum;
                    w1[i, j] = w1[i, j] + eta * delta1[j] * outP;
                }
        }
        static void ModifiedBackpropagation(double expOut, double eta, double momentum)
        {
            double outQ = 0; // Реальный выход слоя Q
            double outP = 0; // Реальный выход слоя P
            double tQ = 0; // Ожидаемый выход слоя Q
            double[] delta2 = new double[output.Length]; // Различие между реальным и ожидаемым результатом слоев layer1-output
            double[] delta1 = new double[layer1.Length]; // Различие между реальным и ожидаемым результатом слоев input-layer1
                                                         // Корректируем веса между слоями output(Q) и layer1(P)
            for (int i = 0; i < w2.GetLength(0); i++)
                for (int j = 0; j < w2.GetLength(1); j++)
                {
                    outQ = output[j];
                    outP = layer1[i];
                    tQ = expOut;
                    delta2[j] = 1 * (tQ - outQ);
                    w2[i, j] = w2[i, j] * momentum + eta * delta2[j] * outP;
                }
            // Корректируем веса между слоями layer1(Q) и input(P)
            for (int i = 0; i < w1.GetLength(0); i++)
                for (int j = 0; j < w1.GetLength(1); j++)
                {
                    double sum = 0;
                    for (int k = 0; k < output.Length; k++)
                    {
                        sum += delta2[k] * w2[j, k];
                    }
                    outQ = layer1[j];
                    outP = input[i];
                    delta1[j] = outQ * (1 - outQ) * sum;
                    w1[i, j] = w1[i, j] * momentum + eta * delta1[j] * outP;
                }
        }
        /// <summary>
        /// Обучение нейросети
        /// </summary>
        public static string Teaching(int n, double eta)
        {
            InitializeWeights();
            Random rnd = new Random();
            // Начинаем цикл обучения
            for (int i = 0; i < n; i++)
            {
                int k = rnd.Next(0, inputTeachingData.Count);
                input = ConvertInputStringToInputDouble(inputTeachingData[k]); // Подаем на вход значение из обучающей выборки, соответствующее n
                double answer = Answer(input); // Получаем ответ нейросети (из выходного слоя)
                double expOut = Convert.ToDouble(outputTeachingData[k]); // Инициализируем ожидаемый выход
                // Присваиваем ожидаемому выходу значение в соответствии со списком выходов
                if (answer != expOut) // нет
                    Backpropagation(expOut, eta); // Запускаем алгоритм обратного распространения ошибки
            }
            return TestTeaching();
        }
        public static string ModifiedTeaching(int n, double eta, double momentum)
        {
            InitializeWeights();
            Random rnd = new Random();
            // Начинаем цикл обучения
            for (int i = 0; i < n; i++)
            {
                int k = rnd.Next(0, inputTeachingData.Count);
                input = ConvertInputStringToInputDouble(inputTeachingData[k]); // Подаем на вход значение из обучающей выборки, соответствующее n
                double answer = Answer(input); // Получаем ответ нейросети (из выходного слоя)
                double expOut = Convert.ToDouble(outputTeachingData[k]); // Инициализируем ожидаемый выход
                // Присваиваем ожидаемому выходу значение в соответствии со списком выходов
                if (answer != expOut) // нет
                    ModifiedBackpropagation(expOut, eta, momentum); // Запускаем алгоритм обратного распространения ошибки
            }
            return TestTeaching();
        }
        public static double ExperienceTeaching(int n, double eta, int m)
        {
            double[] accuracy = new double[m];
            for (int i = 0; i < m; i++)
            {
                InitializeWeights();
                Random rnd = new Random();
                // Начинаем цикл обучения
                for (int j = 0; j < n; j++)
                {
                    int k = rnd.Next(0, inputTeachingData.Count);
                    input = ConvertInputStringToInputDouble(inputTeachingData[k]); // Подаем на вход значение из обучающей выборки, соответствующее n
                    double answer = Answer(input); // Получаем ответ нейросети (из выходного слоя)
                    // Нормализуем аномальные выходы
                    if (answer > 1)
                        answer = 1;
                    double expOut = Convert.ToDouble(outputTeachingData[k]); // Инициализируем ожидаемый выход
                    // Присваиваем ожидаемому выходу значение в соответствии со списком выходов
                    if (answer != expOut) // нет
                        Backpropagation(expOut, eta); // Запускаем алгоритм обратного распространения ошибки
                }
                accuracy[i] = TestExperienceTeaching(); // записываем ошибку i-ой обученной нейросети
            }
            return accuracy.Sum() / m;
        }
        /// <summary>
        /// Тест обученной нейросети
        /// </summary>
        /// <returns></returns>
        static string TestTeaching()
        {
            string result = "";
            int counter = 0;
            double sumAccuracy = 0;
            do
            {
                double answer = Answer(ConvertInputStringToInputDouble(inputRealData[counter]));
                double expOut = Convert.ToDouble(outputRealData[counter]);
                double n_accuracy = Math.Abs(expOut - answer);
                //string n_accuracyStr = String.Format("{0:F2}", n_accuracy);
                //result += "testing data" + counter.ToString() + ": " + n_accuracyStr + "\n";
                sumAccuracy += n_accuracy;
                counter++;
            } while (counter != inputRealData.Count - 1);
            string accuracy = String.Format("{0:F3}", sumAccuracy / outputRealData.Count);
            result += "Accuracy: " + accuracy;
            return result;
        }
        static double TestExperienceTeaching()
        {
            int counter = 0;
            double sumAccuracy = 0;
            do
            {
                double answer = Answer(ConvertInputStringToInputDouble(inputRealData[counter]));
                double expOut = Convert.ToDouble(outputRealData[counter]);
                double n_accuracy = Math.Abs(expOut - answer);
                sumAccuracy += n_accuracy;
                counter++;
            } while (counter != inputRealData.Count - 1);
            double accuracy = sumAccuracy / outputRealData.Count;
            return accuracy;
        }
    }
}
