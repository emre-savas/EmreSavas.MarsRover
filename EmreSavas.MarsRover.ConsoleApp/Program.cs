using EmreSavas.MarsRover.Core.Abstract;
using System;
using EmreSavas.MarsRover.Core.Concrete;
using EmreSavas.MarsRover.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace EmreSavas.MarsRover.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependencyInjection.Configure();
            var plateauGrid = serviceProvider.GetService<IPlateauGrid>();

            while (plateauGrid is { CheckInit: false })
            {
                Console.WriteLine("Plateau grid size :");
                var plateauGridSizeInput = Console.ReadLine();
                Console.WriteLine(plateauGrid.DrawPlateauGrid(plateauGridSizeInput));
            }

            var addAnotherRover = true;

            while (addAnotherRover)
            {
                Console.WriteLine("Rover position :");
                var roverPositionInput = Console.ReadLine();
                Console.WriteLine("Rover command :");
                var roverCommandInput = Console.ReadLine();

                var rover = serviceProvider.GetService<IRover>();
                if (rover != null && rover.SetRoverPosition(roverPositionInput))
                {
                    rover.PlateauGrid = plateauGrid;
                    rover.CommandParse(roverCommandInput);
                    plateauGrid.Rovers.Add(rover);
                }

                Console.WriteLine("Do you want to deploy another rover ? (Y)");
                var addAnotherRoverInput = Console.ReadLine();
                if (addAnotherRoverInput != null && addAnotherRoverInput.ToUpper() != "Y")
                {
                    addAnotherRover = false;
                }
            }

            Console.WriteLine("Expected Output :");
            foreach (var rover in plateauGrid.Rovers)
            {
                var roverCommandManager = serviceProvider.GetService<IRoverCommandManager>();
                if (roverCommandManager != null)
                {
                    roverCommandManager.Rover = rover;

                    foreach (var roverCommand in rover.Commands)
                    {
                        roverCommandManager.AddCommand(roverCommand);
                    }

                    roverCommandManager.ProcessCommands();

                    Console.WriteLine($"{roverCommandManager.Rover.CurrentPosition.X} " +
                                      $"{roverCommandManager.Rover.CurrentPosition.Y} " +
                                      $"{roverCommandManager.Rover.CurrentPosition.DirectionType.ToDirection()}");
                }
            }

            Console.ReadKey();
        }
    }
}
