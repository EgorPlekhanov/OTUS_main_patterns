using System;

namespace I_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            double a = 1.0;
            double b = 2.0;
            double c = 1.0;
            double[] actual = QuadraticEquation.Solve(a, b, c);
        }
    }
}
