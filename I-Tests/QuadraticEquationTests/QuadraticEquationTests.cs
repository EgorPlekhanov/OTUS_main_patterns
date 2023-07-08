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

        private static string GetErrorMessage(string startMessage, double expectedValue, double actualValue)
            => $"{startMessage}. x1 = {actualValue}, а ожидалось {expectedValue}";

        /// <summary>
        /// Тест на то, что при x^2+1=0 метод вернёт пустой массив
        /// </summary>
        [TestMethod]
        public void AIs1_BIs0_CIs1()
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
        public void AIs1_BIs0_CIsMinus1()
        {
            double a = 1.0;
            double b = 0.0;
            double c = -1.0;
            double[] expected = new[] { 1.0, -1.0 };

            double[] actual = QuadraticEquation.Solve(a, b, c);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(expected[i], actual[i], GetErrorMessage($"Ошибка при вычислении уравнения x^2-1 = 0", expected[i], actual[i]));
            }
        }

        /// <summary>
        /// Тест, который проверяет, что для уравнения x^2+2x+1 = 0 есть один корень кратности 2 (x1= x2 = -1)
        /// </summary>
        [TestMethod]
        public void AIs1_BIs2_CIs1()
        {
            double a = 1.0;
            double b = 2.0;
            double c = 1.0;
            double[] expected = new[] { -1.0, -1.0 };

            double[] actual = QuadraticEquation.Solve(a, b, c);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(expected[i], actual[i], GetErrorMessage($"Ошибка при вычислении уравнения x^2+2x+1 = 0", expected[i], actual[i]));
            }
        }

        /// <summary>
        /// Тест, который проверяет, что коэффициент a не может быть равен 0. В этом случае solve выбрасывает исключение
        /// </summary>
        [TestMethod]
        public void AIsNot0()
        {
            double a = 0.0;
            double b = 2.0;
            double c = 1.0;
            Assert.ThrowsException<ArgumentException>(() => QuadraticEquation.Solve(a, b, c));
        }
    }
}