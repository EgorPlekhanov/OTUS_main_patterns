using SpaceBattle.Contracts;
using System.Collections.Concurrent;

namespace SpaceBattle.Exceptions
{
    /// <summary>
    /// Обработчик ошибок, который ставит команду для обработки ошибки в конец очереди
    /// </summary>
    public class AddCommandToQueueExceptionHandler : DefaultExceptionHandler, IExceptionHandler
    {
        /// <summary>
        /// Основная очередь команд
        /// </summary>
        private readonly ConcurrentQueue<ICommand> queue;

        public AddCommandToQueueExceptionHandler(
            IDictionary<Type, IDictionary<Type, Func<Exception, ICommand>>> commandTypeExceptionHandlers,
            ConcurrentQueue<ICommand> queue)
            : base(commandTypeExceptionHandlers)
        {
            this.queue = queue;
        }

        public ICommand Handle(ICommand command, Exception exception)
        {
            ICommand exceptionCommand = base.Handle(command, exception);
            queue.Enqueue(exceptionCommand);
            return exceptionCommand;
        }
    }
}
