using SpaceBattle.Contracts;

namespace SpaceBattle.Exceptions.Commands
{
    /// <summary>
    /// Команда, которая повторяет команду, которая завершилась с ошибкой
    /// </summary>
    public class RepeatFailedCommand : ICommand
    {
        private readonly ICommand failedCommand;

        public RepeatFailedCommand(
            ICommand failedCommand)
        {
            this.failedCommand = failedCommand;
        }

        public void Execute()
        {
            failedCommand.Execute();
        }
    }
}
