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
        private static string GetErrorMessage(string startMessage, double[] values)
            => $"{startMessage}. ����� ������: ({string.Join(", ", values)})";

        private static string GetErrorMessage(string startMessage, double expectedValue, double actualValue)
            => $"{startMessage}. x1 = {actualValue}, � ��������� {expectedValue}";

        /// <summary>
        /// ���� �� ��, ��� ��� x^2+1=0 ����� ����� ������ ������
        /// </summary>
        [TestMethod]
        public void AIs1_BIs0_CIs1()
        {
            double a = 1.0;
            double b = 0.0;
            double c = 1.0;
            double[] expected = Array.Empty<double>();

            double[] actual = QuadraticEquation.Solve(a, b, c);

            Assert.AreEqual(expected, actual, GetErrorMessage("������ ��� ���������� ��������� x^2+1=0", actual));
        }

        /// <summary>
        /// ����, ������� ���������, ��� ��� ��������� x^2-1 = 0 ���� ��� ����� ��������� 1 (x1=1, x2=-1)
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
                Assert.AreEqual(expected[i], actual[i], GetErrorMessage($"������ ��� ���������� ��������� x^2-1 = 0", expected[i], actual[i]));
            }
        }

        /// <summary>
        /// ����, ������� ���������, ��� ��� ��������� x^2+2x+1 = 0 ���� ���� ������ ��������� 2 (x1= x2 = -1)
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
                Assert.AreEqual(expected[i], actual[i], GetErrorMessage($"������ ��� ���������� ��������� x^2+2x+1 = 0", expected[i], actual[i]));
            }
        }

        /// <summary>
        /// ����, ������� ���������, ��� ����������� a �� ����� ���� ����� 0. � ���� ������ solve ����������� ����������
        /// </summary>
        [TestMethod]
        public void AIsNot0()
        {
            double a = 0.0;
            double b = 2.0;
            double c = 1.0;
            Assert.ThrowsException<ArgumentException>(() => QuadraticEquation.Solve(a, b, c));
        }

        /// <summary>
        /// ����, ������� ���������, ��� ��� ������������� ������ 0 ������������ ���� ������ ��������� 2
        /// </summary>
        [TestMethod]
        public void DiscriminantIs0()
        {
            double a = 1.0;
            double b = 6.0;
            double c = 9.0;
            double[] expected = new[] { -3.0, -3.0 };

            double[] actual = QuadraticEquation.Solve(a, b, c);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(expected[i], actual[i], GetErrorMessage($"������ ��� ���������� ��������� x^2+6x+9 = 0", expected[i], actual[i]));
            }
        }

        /// <summary>
        /// ����, ������� ���������, ��� ����� Solve �������� ������ ���� ���� �� ������������� ��������� ���������� ����� ���� double
        /// </summary>
        [TestMethod]
        public void InvalidParams()
        {
            double[] invalidValues = new[] { double.NaN, double.NegativeInfinity, double.PositiveInfinity };
            foreach (var value in invalidValues)
            {
                for (int i = 0; i < 3; i++)
                {
                    double[] args = new[] { 2.0, 6.0, 9.0 };
                    args[i] = value;
                    Assert.ThrowsException<ArgumentException>(() => QuadraticEquation.Solve(args[0], args[1], args[2]));
                }
            }
        }
    }
}