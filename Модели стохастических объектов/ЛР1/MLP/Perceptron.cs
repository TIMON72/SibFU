using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MLP
{
    public static class Perceptron
    {
        static double[] input = new double[50]; // Входной слой
        static double[] layer1 = new double[5]; // Скрытый слой 1
        static double[] output = new double[10]; // Выходной слой
        static double[,] w1 = new double[input.Length, layer1.Length]; // Веса между входным и 1 скрытым слоем + w10 смещения
        static double[,] w2 = new double[layer1.Length, output.Length]; // Веса между 1 скрытым слоем и выходным + w20 смещения
        // Обучаюая выборка для входа
        static double[] num0 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num1 = new double[] { 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, };
        static double[] num2 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num3 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num4 = new double[] { 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, };
        static double[] num5 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num6 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num7 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, };
        static double[] num8 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num9 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        // Тестовая выборка
        static double[] num00 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, };
        static double[] num01 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num02 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num10 = new double[] { 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, };
        static double[] num11 = new double[] { 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, };
        static double[] num12 = new double[] { 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, };
        static double[] num20 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num21 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num22 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, };
        static double[] num30 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num31 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num32 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, };
        static double[] num40 = new double[] { 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, };
        static double[] num41 = new double[] { 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, };
        static double[] num42 = new double[] { 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, };
        static double[] num50 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num51 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, };
        static double[] num52 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, };
        static double[] num60 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num61 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num62 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, };
        static double[] num70 = new double[] { 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, };
        static double[] num71 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, };
        static double[] num72 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, };
        static double[] num80 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num81 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num82 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, };
        static double[] num90 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num91 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, };
        static double[] num92 = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, };
        static double[][] numbers = new double[][] { num0, num1, num2, num3, num4, num5, num6, num7, num8, num9 };
        static double[][] testNumbers = new double[][] { num00, num01, num02, num10, num11, num12, num20, num21,
            num22, num30, num31, num32, num40, num41, num42, num50, num51, num52, num60, num61, num62, num70,
            num71, num72, num80, num81, num82, num90, num91, num92 };

        /// <summary>
        /// Инициализация весов
        /// </summary>
        static void InitializeWeights()
        {
            Random rnd = new Random();
            for (int i = 1; i < w1.GetLength(0); i++)
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
        static double ActivationFunc(double t) => 1 / (1 + Math.Exp(-t));
        /// <summary>
        /// Ответ нейросети
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static int Answer(double[] input)
        {
            // Проход через скрытый слой layer1
            for (int i = 0; i < layer1.Length; i++)
            {
                double sumW = Adder(input, w1, i); // Сумматор i-го нейрона
                layer1[i] = ActivationFunc(sumW); // Функция активации для сумматора + смещение bias скрытого слоя layer1
            }
            // Проход через выходной слой output
            for (int i = 0; i < output.Length; i++)
            {
                double sumW = Adder(layer1, w2, i); // Сумматор i-го нейрона
                output[i] = ActivationFunc(sumW); // Функция активации для сумматора + смещение bias выходного слоя output
            }
            // Возвращаем число, которое соответствует максимальному весу в выходном слое 
            return Array.IndexOf(output, output.Max());
        }
        /// <summary>
        /// Метод обратного распространения ошибки
        /// </summary>
        /// <param name="expOut"></param>
        /// <param name="eta"></param>
        static void Backpropagation(int expOut, double eta)
        {
            double outQ = 0; // Реальный выход слоя Q
            double outP = 0; // Реальный выход слоя P
            double tQ = 1; // Ожидаемый выход слоя Q
            double[] delta2 = new double[output.Length]; // Различие между реальным и ожидаемым результатом слоев layer1-output
            double[] delta1 = new double[layer1.Length]; // Различие между реальным и ожидаемым результатом слоев input-layer1
            // Корректируем веса между слоями output(Q) и layer1(P)
            for (int i = 0; i < w2.GetLength(0); i++) // i <= 5
                for (int j = 0; j < w2.GetLength(1); j++) // j < 10
                {
                    if (j == expOut)
                        tQ = 1;
                    else
                        tQ = 0;
                    outQ = output[j];
                    outP = layer1[i];
                    delta2[j] = outQ * (1 - outQ) * (tQ - outQ);
                    w2[i, j] = w2[i, j] + eta * delta2[j] * outP;
                }
            // Корректируем веса между слоями layer1(Q) и input(P)
            for (int i = 0; i < w1.GetLength(0); i++) // i <= 15
                for (int j = 0; j < w1.GetLength(1); j++) // j < 5
                {
                    double sum = 0;
                    for (int k = 0; k < output.Length; k++) // k < 10
                    {
                        sum += delta2[k] * w2[j, k];
                    }
                    outQ = layer1[j];
                    outP = input[i];
                    delta1[j] = outQ * (1 - outQ) * sum;
                    w1[i, j] = w1[i, j] + eta * delta1[j] * outP;
                }
        }
        /// <summary>
        /// Обучение нейросети
        /// </summary>
        public static string Teaching(int n, double eta)
        {
            bool success;
            do
            {
                success = true;
                InitializeWeights(); // Генерируем веса
                Random rnd = new Random();
                // Начинаем цикл обучения
                for (int i = 0; i < n; i++)
                {
                    int num = rnd.Next(0, 10); // Выбираем случайно какое-либо число от 0 до 9
                    input = numbers[num]; // Подаем на вход значение из выборки, соответствующее num
                    int answer = Answer(input); // Получаем ответ нейросети (из выходного слоя)
                                                // Ответ выходного слоя совпал с ожидаемым числом?
                    if (answer != num) // нет
                        Backpropagation(num, eta); // Запускаем алгоритм обратного распространения ошибки
                }
                // Проверяем корректность обучения
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (Answer(numbers[i]) != i)
                        success = false;
                }
            } while (!success);
            return TestTeaching();
        }
        public static double ExperienceTeaching(int n, double eta, int errors_size)
        {
            double[] errors = new double[errors_size];
            for (int k = 0; k < errors_size; k++)
            {
                InitializeWeights(); // Генерируем веса
                Random rnd = new Random();
                // Начинаем цикл обучения
                for (int i = 0; i < n; i++)
                {
                    int num = rnd.Next(0, 10); // Выбираем случайно какое-либо число от 0 до 9
                    input = numbers[num]; // Подаем на вход значение из выборки, соответствующее num
                    int answer = Answer(input); // Получаем ответ нейросети (из выходного слоя)
                                                // Ответ выходного слоя совпал с ожидаемым числом?
                    if (answer != num) // нет
                        Backpropagation(num, eta); // Запускаем алгоритм обратного распространения ошибки
                }
                errors[k] = TestExperienceTeaching(); // записываем ошибку k-ой обученной нейросети
            }
            return errors.Sum() / errors_size;
        }
        /// <summary>
        /// Тест обученной нейросети
        /// </summary>
        /// <returns></returns>
        static string TestTeaching()
        {
            string answer = "";
            int expNum = 0;
            int j = 0;
            int counter = 0;
            double wrong = 0;
            do
            {
                if (Answer(testNumbers[j]) != expNum)
                {
                    wrong++;
                    answer += "testing num" + expNum.ToString() + counter.ToString() + "... false\n";
                }
                else
                {
                    answer += "testing num" + expNum.ToString() + counter.ToString() + "... true\n";
                }
                j++;
                counter++;
                if (j % 3 == 0)
                {
                    expNum++;
                    counter = 0;
                }
            } while (expNum != 10);
            double error = wrong / testNumbers.Length * 100;
            answer += "Ошибка: " + error + "%\n";
            return answer;
        }
        static double TestExperienceTeaching()
        {
            int expNum = 0;
            int j = 0;
            int counter = 0;
            double wrong = 0;
            do
            {
                if (Answer(testNumbers[j]) != expNum)
                    wrong++;
                j++;
                counter++;
                if (j % 3 == 0)
                {
                    expNum++;
                    counter = 0;
                }
            } while (expNum != 10);
            double error = wrong / testNumbers.Length;
            return error;
        }
        /// <summary>
        /// Преобразование входных данных в сигналы для персептрона
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        static double[] Sensing(Rectangle[,] matrix)
        {
            double[] input = new double[matrix.GetLength(0) * matrix.GetLength(1)];
            //w0 = input.Length / 2;
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j].Fill == Brushes.Black)
                        input[counter] = 1;
                    else
                        input[counter] = 0;
                    counter++;
                }
            return input;
        }
        /// <summary>
        /// Запуск персептрона
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        static public string Run(Rectangle[,] matrix)
        {
            input = Sensing(matrix); // Этап 1 - восприятие сенсорами входных данных
            string answer = "Ответ персептрона: " + Answer(input).ToString() + "\n";
            return answer;
        }
    }
}
