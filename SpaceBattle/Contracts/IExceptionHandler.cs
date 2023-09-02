namespace SpaceBattle.Contracts
{
    /// <summary>
    /// Контракт для обработчиков исключений
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// Обработка исключения <paramref name="exception"/>, которое было выбрашено при выполнении команды <paramref name="command"/>
        /// </summary>
        /// <param name="command"></param>
        /// <param name="exception"></param>
        /// <returns>Возваращает команду, которая должна выполнится при обработке исключения</returns>
        ICommand Handle(ICommand command, Exception exception);
    }
}
