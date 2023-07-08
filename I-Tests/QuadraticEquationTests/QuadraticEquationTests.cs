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

            Assert.AreEqual(expected, actual, "Ошибка при вычислении выражения x^2+1=0");
        }
    }
}