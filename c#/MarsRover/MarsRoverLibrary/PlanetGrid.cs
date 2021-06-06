using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class PlanetGrid
    {
        Coords MinPos { get; }
        Coords MaxPos { get; }

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



        public Coords NextCoords(Coords coords, Direction direction, Versus versus)
        {
            int newX = coords.X + (int)versus * (int)Math.Cos((short)direction * Math.PI / 180.0);
            int newY = coords.Y + (int)versus * (int)Math.Sin((short)direction * Math.PI / 180.0);
            if (newX > MaxPos.X)
                newX = MinPos.X;
            if (newX < MinPos.X)
                newX = MaxPos.X;

            return new Coords(newX, newY);
        }


    }
}
