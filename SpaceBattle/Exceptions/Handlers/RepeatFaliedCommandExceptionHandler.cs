using SpaceBattle.Contracts;

namespace SpaceBattle.Exceptions
{
    /// <summary>
    /// Обработчик ошибки, который в случае ошибки возвращает команду, которая повторяет вызвавшую ошибку команду 
    /// </summary>
    public class RepeatFaliedCommandExceptionHandler : IExceptionHandler
    {
        public ICommand Handle(ICommand command, Exception exception)
            => new RepeatFailedCommand(command);
    }
}
