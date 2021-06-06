using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class MarsRoverEngine
    {
        public int Move(MarsRoverEngineDirection direction)
        {
            return (int)direction;
        }
    }

    public enum MarsRoverEngineDirection : int
    {
        Forward = 1,
        Backward = -1,
    }
}
