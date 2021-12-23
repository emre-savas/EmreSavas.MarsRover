using EmreSavas.MarsRover.Core.Abstract;

namespace EmreSavas.MarsRover.Core.Commands
{
    public class MoveCommand : ICommand
    {
        readonly IRover rover;

        public MoveCommand(IRover rover)
        {
            this.rover = rover;
        }

        public void Process()
        {
            this.rover.Move();
        }
    }
}
