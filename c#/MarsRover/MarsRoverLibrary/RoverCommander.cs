using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class RoverCommander
    {
        public IRover Rover { get; }
        public RoverCommander(IRover rover)
        {
            Rover = rover;
        }

        public void ExecuteCommands(string commandString)
        {
            Rover.Move(Versus.Forward);
        }
    }
}
