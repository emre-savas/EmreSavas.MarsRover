using EmreSavas.MarsRover.Core.Abstract;

namespace EmreSavas.MarsRover.Core.Commands
{
    public class TurnLeftCommand : ICommand
    {
        readonly IRover rover;

        public TurnLeftCommand(IRover rover)
        {
            this.rover = rover;
        }

        public void Process()
        {
            this.rover.TurnLeft();
        }
    }
}
