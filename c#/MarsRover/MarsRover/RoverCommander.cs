using Space;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class RoverCommander
    {
        private IRover Rover { get; }
        private readonly Dictionary<char, Func<IRover, MoveResult>> commands;
        public RoverCommander(IRover rover)
        {
            Rover = rover;
            commands = new Dictionary<char, Func<IRover, MoveResult>>
            {
                {'f', rover => rover.Move(Versus.Forward)},
                {'b', rover => rover.Move(Versus.Backward)},
                {
                    'r', rover =>
                    {
                        rover.Rotate(Rotation.Right);
                        return new MoveResult();
                    }
                },
                {
                    'l', rover =>
                    {
                        rover.Rotate(Rotation.Left);
                        return new MoveResult();
                    }
                }
            };
        }

        public string ExecuteCommands(string commandString)
        {
            string executedCommandsOutput = "";
            foreach (var commandChar in commandString)
            {
                MoveResult result = commands[commandChar](Rover);

                if (result.ObstacleFound())
                {
                    executedCommandsOutput += $"Ops: obstacle at ({result.ObstaclePosition.Value.X}:{result.ObstaclePosition.Value.Y})";
                    break;
                }

                executedCommandsOutput += commandChar;
            }
            return executedCommandsOutput;

        }
    }
}
