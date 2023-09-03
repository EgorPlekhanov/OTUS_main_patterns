using SpaceBattle.Contracts;

namespace SpaceBattle.Exceptions
{
    /// <summary>
    /// Обработчик ошибок
    /// </summary>
    public class ExceptionHandler
    {
        /// <summary>
        /// Словарь (Тип конкретной команды, Словарь(Тип конкретной ошибки, Стратегия обработки ошибки))
        /// </summary>
        private readonly IDictionary<Type, IDictionary<Type, Func<object[], ICommand>>> commandTypeExceptionHandlers;

        public ExceptionHandler(
            IDictionary<Type, IDictionary<Type, Func<object[], ICommand>>> commandTypeExceptionHandlers)
        {
            this.commandTypeExceptionHandlers = commandTypeExceptionHandlers;
        }

        public ICommand Handle(params object[] args)
        {
            Type commandType = args[0].GetType();
            Type exceptionType = args[1].GetType();
            return commandTypeExceptionHandlers[commandType][exceptionType].Invoke(args);
        }
    }
}
