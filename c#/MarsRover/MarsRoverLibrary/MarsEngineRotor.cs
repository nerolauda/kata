using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class MarsEngineRotor
    {
        public MarsEngineDirection Direction { get; }

        public MarsEngineRotor(MarsEngineDirection direction)
        {
            this.Direction = direction;
        }

        public MarsEngineDirection RotateLeft()
        {
            return MarsEngineDirection.North;
        }
    }

    public enum MarsEngineDirection : ushort
    {
        East = 0,
        North = 90,
        West = 180,
        South = 275
    }
}
