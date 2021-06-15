using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class RoverCommander
    {
        public IRover Rover { get; }
        private Dictionary<char, Func<IRover, bool>> commands;
        public RoverCommander(IRover rover)
        {
            Rover = rover;
            commands = new Dictionary<char, Func<IRover, bool>>();
            commands.Add('f', rover => rover.Move(Versus.Forward).ObstacleFound());
            commands.Add('b', rover => rover.Move(Versus.Backward).ObstacleFound());
            commands.Add('r', rover =>
            {
                rover.Rotate(Rotation.Right);
                return false;
            });
            commands.Add('l', rover =>
            {
                rover.Rotate(Rotation.Left);
                return false;
            });
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
