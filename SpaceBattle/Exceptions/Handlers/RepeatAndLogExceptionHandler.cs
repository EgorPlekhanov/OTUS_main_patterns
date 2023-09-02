using Microsoft.Extensions.Logging;
using SpaceBattle.Contracts;

namespace SpaceBattle.Exceptions
{
    public class RepeatAndLogExceptionHandler : IExceptionHandler
    {
        private readonly ILogger logger;
        private readonly int repetitionCount;
        private readonly IDictionary<ICommand, int> CommandCounters = new Dictionary<ICommand, int>();

        public RepeatAndLogExceptionHandler(
            ILogger logger,
            int repetitionCount)
        {
            this.logger = logger;
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
            return new LogExceptionCommand(logger, exception);
        }
    }
}
