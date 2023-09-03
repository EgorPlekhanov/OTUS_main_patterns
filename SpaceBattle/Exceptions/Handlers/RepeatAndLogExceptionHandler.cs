using SpaceBattle.Contracts;

namespace SpaceBattle.Exceptions
{
    /// <summary>
    /// Обработчик ошибок, который повторяет команду указанное кол-во раз, а затем записывает ошибку в лог
    /// </summary>
    public class RepeatAndLogExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Для простоты сделал лог в виде списка строк
        /// </summary>
        private readonly IList<string> loggerMessages;
        private readonly int repetitionCount;
        private readonly IDictionary<ICommand, int> CommandCounters = new Dictionary<ICommand, int>();

        public RepeatAndLogExceptionHandler(
            IList<string> loggerMessages,
            int repetitionCount)
        {
            this.loggerMessages = loggerMessages;
            this.repetitionCount = repetitionCount;
        }

        public ICommand Handle(ICommand command, Exception exception)
        {
            if (!CommandCounters.TryGetValue(command, out int counter) || counter < repetitionCount)
            {
                CommandCounters[command] = counter++;
                return new RepeatFailedCommand(command);
            }
            CommandCounters[command] = default;
            return new LogExceptionCommand(loggerMessages, exception);
        }
    }
}
