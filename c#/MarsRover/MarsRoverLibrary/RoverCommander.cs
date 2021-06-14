using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class RoverCommander
    {
        public IRover Rover { get; }
        private Dictionary<char, Action<IRover>> commands;
        public RoverCommander(IRover rover)
        {
            Rover = rover;
            commands = new Dictionary<char, Action<IRover>>();
            commands.Add('f', rover => rover.Move(Versus.Forward));
            commands.Add('b', rover => rover.Move(Versus.Backward));
            commands.Add('r', rover => rover.Rotate(Rotation.Right));
            commands.Add('l', rover => rover.Rotate(Rotation.Left));


        }

        public void ExecuteCommands(string commandString)
        {
            commands[commandString[0]](Rover);
        }
    }
}
