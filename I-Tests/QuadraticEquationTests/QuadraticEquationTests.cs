namespace QuadraticEquationTests
{
    /// <summary>
    /// Ќабор тестов дл€ проверки метода вычислени€ корней квадратного уравнени€
    /// </summary>
    [TestClass]
    public class QuadraticEquationTests
    {
        /// <summary>
        /// “ест на то, что при x^2+1=0 метод вернЄт пустой массив
        /// </summary>
        [TestMethod]
        public void AIs1_BIsZero_CIs1()
        {
            double a = 1.0;
            double b = 0.0;
            double c = 1.0;
            double[] expected = Array.Empty<double>();

            double[] actual = I_Tests.Solve(a, b, c);
        }
    }
}