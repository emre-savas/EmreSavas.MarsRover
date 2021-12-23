using System.Collections.Generic;
using System.Runtime.InteropServices;
using EmreSavas.MarsRover.Core.Enums;
using EmreSavas.MarsRover.Core.Exception;

namespace EmreSavas.MarsRover.Core.Extensions
{
    public static class DirectionExtension
    {
        public static bool IsDirectionType(this string directionType)
        {
            return new List<string>() { "N" , "S", "E", "W" }.Contains(directionType.ToUpper());
        }
        public static DirectionType ToDirectionType(this object directionType)
        {
            switch (directionType)
            {
                case "N":
                    return DirectionType.North;
                case "S":
                    return DirectionType.South;
                case "E":
                    return DirectionType.East;
                case "W":
                    return DirectionType.West;
                default:
                    throw new BusinessException(BusinessExceptionCode.ParsedDirectionTypeError.GetHashCode());
            }
        }

        public static string ToDirection(this DirectionType directionType)
        {
            switch (directionType)
            {
                case DirectionType.North:
                    return "N";
                case DirectionType.South:
                    return "S";
                case DirectionType.East:
                    return "E";
                case DirectionType.West:
                    return "W";
                default:
                    throw new BusinessException(BusinessExceptionCode.ParsedDirectionTypeError.GetHashCode());
            }
        }
    }
}
