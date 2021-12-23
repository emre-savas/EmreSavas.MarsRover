using EmreSavas.MarsRover.Core.Abstract;

namespace EmreSavas.MarsRover.Core.Commands
{
    public class TurnRightCommand : ICommand
    {
        readonly IRover rover;

        public TurnRightCommand(IRover rover)
        {
            this.rover = rover;
        }

        public void Process()
        {
           this.rover.TurnRight();
        }
    }
}
