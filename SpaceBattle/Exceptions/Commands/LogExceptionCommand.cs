using SpaceBattle.Contracts;

namespace SpaceBattle.Exceptions
{
    /// <summary>
    /// Команда для записи исключения в лог
    /// </summary>
    public class LogExceptionCommand : ICommand
    {
        /// <summary>
        /// Для простоты сделал лог в виде списка строк
        /// </summary>
        private readonly IList<string> loggerMessages;
        private readonly Exception exception;

        public LogExceptionCommand(
            IList<string> loggerMessages,
            Exception exception)
        {
            this.loggerMessages = loggerMessages;
            this.exception = exception;
        }

        public void Execute()
            => loggerMessages.Add(exception.ToString());
    }
}
