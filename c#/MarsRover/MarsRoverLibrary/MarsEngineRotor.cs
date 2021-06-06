using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class MarsEngineRotor
    {
        public MarsEngineDirection Direction { get; internal set; }

        public MarsEngineRotor(MarsEngineDirection direction)
        {
            this.Direction = direction;
        }

        public MarsEngineDirection RotateLeft()
        {
            Direction += 90;
            while ((int)Direction >= 360)
                Direction -= 360;
            return Direction;
        }



        public MarsEngineDirection RotateRight()
        {
            Direction -= 90;
            while ((int)Direction < 0)
                Direction += 360;
            return Direction;
        }
    }

    public enum MarsEngineDirection : short
    {
        East = 0,
        North = 90,
        West = 180,
        South = 270
    }
}
