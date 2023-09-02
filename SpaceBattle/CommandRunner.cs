using SpaceBattle.Contracts;
using SpaceBattle.Exceptions;
using System.Collections.Concurrent;

namespace SpaceBattle
{
    /// <summary>
    /// Раннер команд
    /// </summary>
    public class CommandRunner
    {
        /// <summary>
        /// Очередь команд
        /// </summary>
        private readonly ConcurrentQueue<ICommand> queue;

        /// <summary>
        /// Обработчик ошибок
        /// </summary>
        private readonly ExceptionHandler exceptionHandler;

        public CommandRunner(
            ConcurrentQueue<ICommand> queue,
            ExceptionHandler exceptionHandler)
        {
            this.queue = queue;
            this.exceptionHandler = exceptionHandler;
        }

        public void Run()
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
