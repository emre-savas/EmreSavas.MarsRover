using EmreSavas.MarsRover.Core.Abstract;
using EmreSavas.MarsRover.Core.Enums;

namespace EmreSavas.MarsRover.Core.Concrete
{
    public class RoverPosition : IRoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionType DirectionType { get; set; }

        public RoverPosition(DirectionType directionType = DirectionType.North, int x = default, int y = default)
        {
            this.X = x;
            this.Y = y;
            this.DirectionType = directionType;
        }
    }
}
