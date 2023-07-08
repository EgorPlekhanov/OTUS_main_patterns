using System;
using System.Linq;

namespace I_Tests
{
    public static class QuadraticEquation
    {
        public static readonly double[] INVALID_VALUES = { double.NaN, double.NegativeInfinity, double.PositiveInfinity };

        /// <summary>
        /// Метод нахождения квадратного уровнения
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>Массив корней</returns>
        public static double[] Solve(double a, double b, double c, double epsilon = double.Epsilon)
        {
            ValidateParameters(a, b, c, epsilon);
            double discriminant = GetDiscriminant(b, a, c);
            if (discriminant < -epsilon)
                return Array.Empty<double>();
            double x1 = (-b + Math.Sqrt(GetDiscriminant(b, a, c))) / 2 * a;
            double x2 = (-b - Math.Sqrt(GetDiscriminant(b, a, c))) / 2 * a;
            return new double[] { x1, x2 };
        }

        private static double GetDiscriminant(double b, double a, double c)
            => b * b - 4 * a * c;

        private static void ValidateParameters(double a, double b, double c, double epsilon)
        {
            if (Math.Abs(a) <= epsilon)
                throw new ArgumentException($@"Коэффициент ""a"" не может быть равен 0");
            if (INVALID_VALUES.Intersect(new[] { a, b, c }).Any())
                throw new ArgumentException($"Один из коэффициентов имеет недопустимое значение");
        }
    }
}