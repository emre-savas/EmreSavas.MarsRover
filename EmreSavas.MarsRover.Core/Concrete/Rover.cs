using EmreSavas.MarsRover.Core.Abstract;
using EmreSavas.MarsRover.Core.Commands;
using EmreSavas.MarsRover.Core.Enums;
using EmreSavas.MarsRover.Core.Exception;
using EmreSavas.MarsRover.Core.Extensions;
using System.Collections.Generic;

namespace EmreSavas.MarsRover.Core.Concrete
{
    public class Rover : IRover
    {
        public IRoverPosition CurrentPosition { get; private set; }
        public IPlateauGrid PlateauGrid { get; set; }
        public IList<ICommand> Commands { get; set; }

        public Rover()
        {
            Commands = new List<ICommand>();
        }

        public Rover(IRoverPosition roverPosition, IPlateauGrid plateauGrid) : this()
        {
            CurrentPosition = roverPosition;
            PlateauGrid = plateauGrid;
            Commands = new List<ICommand>();
        }

        public void Move()
        {
            CheckRoverIsAtValidGridBoundaries();
            CurrentPosition = RoverAction.Move(CurrentPosition);
        }

        public void TurnLeft()
        {
            CurrentPosition.DirectionType = RoverAction.TurnLeft(CurrentPosition.DirectionType);
        }

        public void TurnRight()
        {
            CurrentPosition.DirectionType = RoverAction.TurnRight(CurrentPosition.DirectionType);
        }

        public bool SetRoverPosition(string roverPosition)
        {
            var roverPositionArray = roverPosition.Split(' ');
            if (roverPosition.Length != 3) return false;
            try
            {
                var x = int.Parse(roverPositionArray[0]);
                var y = int.Parse(roverPositionArray[1]);
                var direction = roverPositionArray[2].ToUpper();

                if (direction.IsDirectionType())
                {
                    CurrentPosition.DirectionType = direction.ToDirectionType();
                    CurrentPosition.X = x;
                    CurrentPosition.Y = y;
                    return true;
                }
            }
            catch (System.Exception e)
            {
                throw new BusinessException(BusinessExceptionCode.RoverPositionError.GetHashCode(), e.Message);
            }
            return false;
        }

        public void CommandParse(string roverCommands)
        {
            foreach (var letter in roverCommands.ToCharArray())
            {
                switch (char.ToUpper(letter))
                {
                    case 'L':
                        Commands.Add(new TurnLeftCommand(this));
                        break;
                    case 'R':
                        Commands.Add(new TurnRightCommand(this));
                        break;
                    case 'M':
                        Commands.Add(new MoveCommand(this));
                        break;
                    default:
                        throw new BusinessException(BusinessExceptionCode.ParsedCommandError.GetHashCode());
                }
            }
        }

        private void CheckRoverIsAtValidGridBoundaries()
        {
            var gridX = PlateauGrid.GridX;
            var gridY = PlateauGrid.GridY;
            var currentRoverPosition = CurrentPosition;

            if (currentRoverPosition.X > gridX || currentRoverPosition.X < 0)
            {
                throw new BusinessException(BusinessExceptionCode.PlateauXOutOfBoundaryError.GetHashCode());
            }

            if (currentRoverPosition.Y > gridY || currentRoverPosition.Y < 0)
            {
                throw new BusinessException(BusinessExceptionCode.PlateauYOutOfBoundaryError.GetHashCode());
            }
        }
    }
}
