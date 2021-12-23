using EmreSavas.MarsRover.Core.Abstract;
using System.Collections.Generic;

namespace EmreSavas.MarsRover.Core.Concrete
{
    public class RoverCommandManager : IRoverCommandManager
    {
        public IRover Rover { get; set; }
        private readonly Queue<ICommand> QueueCommands = new Queue<ICommand>();

        public RoverCommandManager(IRover rover)
        {
            this.Rover = rover;
        }

        public void AddCommand(ICommand command)
        {
            QueueCommands.Enqueue(command);
        }

        public void ProcessCommands()
        {
            while (QueueCommands.Count > 0)
            {
                var command = QueueCommands.Dequeue();
                command.Process();
            }
        }
    }
}
