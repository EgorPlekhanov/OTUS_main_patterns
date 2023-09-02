using Microsoft.Extensions.Logging;
using SpaceBattle.Contracts;

namespace SpaceBattle.Exceptions
{
    /// <summary>
    /// Команда для записи исключения в лог
    /// </summary>
    public class LogExceptionCommand : ICommand
    {
        private readonly ILogger logger;
        private readonly Exception exception;

        public LogExceptionCommand(
            ILogger logger,
            Exception exception)
        {
            this.logger = logger;
            this.exception = exception;
        }

        public void Execute()
            => logger.Log(LogLevel.Error, exception.ToString());
    }
}
