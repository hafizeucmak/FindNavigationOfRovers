using System;
using System.Linq;

namespace NASANavigateRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = "12N LMLMLMLMM 33E MMRMMRMRRM";
            var commandParts = command.Split(',', ' ');

            Astronaut astronaut = null;

            foreach (var commandPart in commandParts)
            {
                if (commandPart.Any(char.IsDigit))
                {
                    astronaut = new Astronaut();
                    astronaut.SetInitialPositionAndDirection(commandPart);
                }
                else
                {
                    var movementCommandList = commandPart.Select(c => c.ToString()).ToList();

                    foreach (var movementCommand in movementCommandList)
                    {
                        astronaut.Move(movementCommand);
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Astronaut {astronaut.FullName} {Environment.NewLine}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Name             : {astronaut.FullName} {Environment.NewLine}" +
                                      $"Age              : {astronaut.Age} {Environment.NewLine}" +
                                      $"Last Position    : ({astronaut.Position.XAxis}{astronaut.Position.YAxis}{astronaut.DirectionType.ToString()})");
                    Console.WriteLine("---------------------------------------------------");
                }
            }
        }
    }
}
