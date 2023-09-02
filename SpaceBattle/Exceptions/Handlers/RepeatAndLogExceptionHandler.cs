using Microsoft.Extensions.Logging;
using SpaceBattle.Contracts;

namespace SpaceBattle.Exceptions
{
    public class RepeatAndLogExceptionHandler : IExceptionHandler
    {
        private readonly ILogger logger;
        private readonly IDictionary<ICommand, int> CommandCounters = new Dictionary<ICommand, int>();

        public RepeatAndLogExceptionHandler(
            ILogger logger)
        {
            this.logger = logger;
        }

        public ICommand Handle(ICommand command, Exception exception)
        {
            if (!CommandCounters.TryGetValue(command, out int counter) || counter.Equals(default))
            {
                CommandCounters[command] = 1;
                return new RepeatFailedCommand(command);
            }
            CommandCounters[command] = default;
            return new LogExceptionCommand(logger, exception);
        }
    }
}
