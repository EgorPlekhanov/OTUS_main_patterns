namespace SpaceBattle.Exceptions
{
    /// <summary>
    /// Ошибка неверно введёного значения
    /// </summary>
    public class InvalidInputValueException : Exception
    {
        public InvalidInputValueException(
            string? message)
            : base(message)
        {
        }
    }
}
