using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Rotor : IRotor
    {
        public Direction Direction { get; internal set; }

        public Rotor(Direction direction)
        {
            this.Direction = direction;
        }

        public Direction RotateLeft()
        {
            Direction += 90;
            while ((int)Direction >= 360)
                Direction -= 360;
            return Direction;
        }



        public Direction RotateRight()
        {
            Direction -= 90;
            while ((int)Direction < 0)
                Direction += 360;
            return Direction;
        }
    }
}
