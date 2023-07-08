using I_Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace QuadraticEquationTests
{
    /// <summary>
    /// Набор тестов для проверки метода вычисления корней квадратного уравнения
    /// </summary>
    [TestClass]
    public class QuadraticEquationTests
    {
        private static string GetErrorMessage(string startMessage, double[] values) 
            => $"{startMessage}. Метод вернул: ({string.Join(", ", values)})";

        /// <summary>
        /// Тест на то, что при x^2+1=0 метод вернёт пустой массив
        /// </summary>
        [TestMethod]
        public void AIs1_BIsZero_CIs1()
        {
            double a = 1.0;
            double b = 0.0;
            double c = 1.0;
            double[] expected = Array.Empty<double>();

            double[] actual = QuadraticEquation.Solve(a, b, c);

            Assert.AreEqual(expected, actual, GetErrorMessage("Ошибка при вычислении уравнения x^2+1=0", actual));
        }

        /// <summary>
        /// Тест, который проверяет, что для уравнения x^2-1 = 0 есть два корня кратности 1 (x1=1, x2=-1)
        /// </summary>
        [TestMethod]
        public void AIs1_BIsZero_CIsMinus1()
        {
            double a = 1.0;
            double b = 0.0;
            double c = -1.0;
            double[] expected = new[] { 1.0, -1.0 };

            double[] actual = QuadraticEquation.Solve(a, b, c);

            Assert.AreEqual(expected, actual, GetErrorMessage($"Ошибка при вычислении уравнения x^2-1 = 0", actual));
        }
    }
}