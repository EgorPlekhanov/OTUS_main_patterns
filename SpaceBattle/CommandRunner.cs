using SpaceBattle.Contracts;
using System.Collections.Concurrent;

namespace SpaceBattle
{
    /// <summary>
    /// Раннер команд
    /// </summary>
    public class CommandRunner : ICommand
    {
        /// <summary>
        /// Очередь команд
        /// </summary>
        private readonly ConcurrentQueue<ICommand> queue;

        /// <summary>
        /// Обработчик ошибок
        /// </summary>
        private readonly IExceptionHandler exceptionHandler;

        public CommandRunner(
            ConcurrentQueue<ICommand> queue,
            IExceptionHandler exceptionHandler)
        {
            this.queue = queue;
            this.exceptionHandler = exceptionHandler;
        }

        public void Execute()
        {
            while (!queue.IsEmpty)
            {
                _ = queue.TryDequeue(out ICommand command);
                try
                {
                    command.Execute();
                }
                catch (Exception e)
                {
                    exceptionHandler.Handle(command, e).Execute();
                }
            }
        }
    }
}
