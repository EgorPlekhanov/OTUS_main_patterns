using SpaceBattle.Contracts;

namespace SpaceBattle.Exceptions
{
    /// <summary>
    /// Дефолтный обработчик ошибок
    /// </summary>
    public class DefaultExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Словарь (CommandType, Словарь(ExceptionType, HandleExceptionCommand))
        /// </summary>
        private readonly IDictionary<Type, IDictionary<Type, ICommand>> commandTypeExceptionHandlers;

        public DefaultExceptionHandler(
            IDictionary<Type, IDictionary<Type, ICommand>> commandTypeExceptionHandlers)
        {
            this.commandTypeExceptionHandlers = commandTypeExceptionHandlers;
        }

        public ICommand Handle(ICommand command, Exception exception)
        {
            Type commandType = command.GetType();
            Type exceptionType = exception.GetType();
            return commandTypeExceptionHandlers[commandType][exceptionType];
        }
    }
}
