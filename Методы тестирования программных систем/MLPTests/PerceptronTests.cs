using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLP;

namespace MLPTests
{
    [TestClass]
    public class PerceptronTests
    {
        private static readonly double[] input = new double[3] { 1, 0, 1 };
        private static readonly double[] layer1 = new double[2];
        private static readonly double[] output = new double[1];
        private static readonly double[,] w1 = new double[3, 2] { { 0.6, 0.5 }, { 0.4, 0.3 }, { 0.2, 0.1 } };
        private static readonly double[,] w2 = new double[2, 1] { { 0.2 }, { 0.1 } };
        /// <summary>
        /// Тест сумматора персептрона
        /// </summary>
        [TestMethod]
        public void AdderTest()
        {
            double expected = 0.8;
            double actual = Perceptron.Adder(input, w1, 0);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Тест функции активации
        /// </summary>
        [TestMethod]
        public void ActivationFuncTest()
        {
            double expected = 0.66818777216816616;
            double actual = Perceptron.ActivationFunc(0.7);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Тест ответа персептрона
        /// </summary>
        [TestMethod]
        public void AnswerTest()
        {
            double expected = 0.20256052684810205;
            Perceptron.Initialize(input, layer1, output, w1, w2);
            double actual = Perceptron.Answer(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
