using EmreSavas.MarsRover.Core.Abstract;
using EmreSavas.MarsRover.Core.Enums;
using EmreSavas.MarsRover.Core.Exception;

namespace EmreSavas.MarsRover.Core.Concrete
{
    public class RoverAction
    {
        public static IRoverPosition Move(IRoverPosition roverPosition)
        {
            return roverPosition.DirectionType switch
            {
                DirectionType.North => new RoverPosition(roverPosition.DirectionType, roverPosition.X,
                    roverPosition.Y + 1),
                DirectionType.South => new RoverPosition(roverPosition.DirectionType, roverPosition.X,
                    roverPosition.Y - 1),
                DirectionType.West => new RoverPosition(roverPosition.DirectionType, roverPosition.X - 1,
                    roverPosition.Y),
                DirectionType.East => new RoverPosition(roverPosition.DirectionType, roverPosition.X + 1,
                    roverPosition.Y),
                _ => throw new BusinessException(BusinessExceptionCode.InvalidDirectionType.GetHashCode())
            };
        }

        public static DirectionType TurnRight(DirectionType DirectionType)
        {
            return DirectionType switch
            {
                DirectionType.North => DirectionType.East,
                DirectionType.East => DirectionType.South,
                DirectionType.South => DirectionType.West,
                DirectionType.West => DirectionType.North,
                _ => throw new BusinessException(BusinessExceptionCode.InvalidDirectionType.GetHashCode()),
            };
        }

        public static DirectionType TurnLeft(DirectionType DirectionType)
        {
            return DirectionType switch
            {
                DirectionType.North => DirectionType.West,
                DirectionType.East => DirectionType.North,
                DirectionType.South => DirectionType.East,
                DirectionType.West => DirectionType.South,
                _ => throw new BusinessException(BusinessExceptionCode.InvalidDirectionType.GetHashCode()),
            };
        }
    }
}
