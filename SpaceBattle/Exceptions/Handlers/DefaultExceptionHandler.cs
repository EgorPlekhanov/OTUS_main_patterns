using SpaceBattle.Contracts;

namespace SpaceBattle.Exceptions
{
    /// <summary>
    /// Дефолтный обработчик ошибок
    /// </summary>
    public class DefaultExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Словарь (Тип конкретной команды, Словарь(Тип конкретной ошибки, Стратегия обработки ошибки))
        /// </summary>
        private readonly IDictionary<Type, IDictionary<Type, Func<Exception, ICommand>>> commandTypeExceptionHandlers;

        public DefaultExceptionHandler(
            IDictionary<Type, IDictionary<Type, Func<Exception, ICommand>>> commandTypeExceptionHandlers)
        {
            this.commandTypeExceptionHandlers = commandTypeExceptionHandlers;
        }

        public ICommand Handle(ICommand command, Exception exception)
        {
            Type commandType = command.GetType();
            Type exceptionType = exception.GetType();
            return commandTypeExceptionHandlers[commandType][exceptionType].Invoke(exception);
        }
    }
}
