using SpaceBattle.Contracts;
using System.Collections.Concurrent;

namespace SpaceBattle.Exceptions
{
    public class AddCommandToQueueCommand : ICommand
    {
        private readonly ICommand commandToAdd;
        private readonly ConcurrentQueue<ICommand> queue;

        public AddCommandToQueueCommand(
            ICommand commandToAdd,
            ConcurrentQueue<ICommand> queue)
        {
            this.commandToAdd = commandToAdd;
            this.queue = queue;
        }

        public void Execute()
        {
            queue.Enqueue(commandToAdd);
        }
    }
}
