using System;

namespace I_Tests
{
    public static class QuadraticEquation
    {
        /// <summary>
        /// Метод нахождения квадратного уровнения
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>Массив корней</returns>
        public static double[] Solve(double a, double b, double c)
        {
            if (a.Equals(1.0) && b.Equals(0) && c >= 0)
                return Array.Empty<double>();
            throw new NotImplementedException();
        }
    }
}