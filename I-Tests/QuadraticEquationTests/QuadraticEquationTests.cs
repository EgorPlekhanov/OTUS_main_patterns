using I_Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace QuadraticEquationTests
{
    /// <summary>
    /// ����� ������ ��� �������� ������ ���������� ������ ����������� ���������
    /// </summary>
    [TestClass]
    public class QuadraticEquationTests
    {
        /// <summary>
        /// ���� �� ��, ��� ��� x^2+1=0 ����� ����� ������ ������
        /// </summary>
        [TestMethod]
        public void AIs1_BIsZero_CIs1()
        {
            double a = 1.0;
            double b = 0.0;
            double c = 1.0;
            double[] expected = Array.Empty<double>();

            double[] actual = QuadraticEquation.Solve(a, b, c);

            Assert.AreEqual(expected, actual, "������ ��� ���������� ��������� x^2+1=0");
        }
    }
}