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
            if (a.Equals(1.0))
            {
                if (b.Equals(0))
                {
                    if (c >= 0)
                        return Array.Empty<double>();
                }
                double x1 = (-b + Math.Sqrt(GetDiscriminant(b, a, c))) / 2 * a;
                double x2 = (-b - Math.Sqrt(GetDiscriminant(b, a, c))) / 2 * a;
                return new double[] { x1, x2 };
            }
            throw new NotImplementedException();
        }

        private static double GetDiscriminant(double b, double a, double c)
            => b * b - 4 * a * c;
    }
}