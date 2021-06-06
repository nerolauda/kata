using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverLibrary
{
    public class PlanetGrid
    {
        public Coords MinPos { get; }
        public Coords MaxPos { get; }

        public PlanetGrid(Coords minCoord, Coords maxCoord)
        {
            MinPos = minCoord;
            MaxPos = maxCoord;
            ValidateLimits();
        }

        private void ValidateLimits()
        {
            if (MaxPos.X <= MinPos.X) throw new ArgumentException("MinPos.X MUST be lower than MaxPos.X");
            if (MaxPos.Y <= MinPos.Y) throw new ArgumentException("MinPos.Y MUST be lower than MaxPos.Y");
        }

    }
}
