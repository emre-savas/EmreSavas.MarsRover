using EmreSavas.MarsRover.Core.Enums;

namespace EmreSavas.MarsRover.Core.Abstract
{
    public interface IRoverPosition
    {
        int X { get; set; }
        int Y { get; set; }
        DirectionType DirectionType { get; set; }
    }
}
