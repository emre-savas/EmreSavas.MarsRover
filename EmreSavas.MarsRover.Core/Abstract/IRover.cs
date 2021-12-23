using System.Collections.Generic;

namespace EmreSavas.MarsRover.Core.Abstract
{
    public interface IRover
    {
        IRoverPosition CurrentPosition { get; }
        IPlateauGrid PlateauGrid { get; set; }
        IList<ICommand> Commands { get; set; }
        bool SetRoverPosition(string roverPositionInput);
        void CommandParse(string roverCommandInput);
        void Move();
        void TurnRight();
        void TurnLeft();
    }
}
