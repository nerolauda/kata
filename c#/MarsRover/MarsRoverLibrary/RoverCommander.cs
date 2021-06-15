using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class RoverCommander
    {
        private IRover Rover { get; }
        private readonly Dictionary<char, Func<IRover, bool>> commands;
        public RoverCommander(IRover rover)
        {
            Rover = rover;
            commands = new Dictionary<char, Func<IRover, bool>>
            {
                {'f', rover => rover.Move(Versus.Forward).ObstacleFound()},
                {'b', rover => rover.Move(Versus.Backward).ObstacleFound()},
                {
                    'r', rover =>
                    {
                        rover.Rotate(Rotation.Right);
                        return false;
                    }
                },
                {
                    'l', rover =>
                    {
                        rover.Rotate(Rotation.Left);
                        return false;
                    }
                }
            };
        }

        public void ExecuteCommands(string commandString)
        {
            foreach (var commandChar in commandString)
            {
                bool obstacleDetected = commands[commandChar](Rover);
                if (obstacleDetected) break;
            }

        }
    }
}
