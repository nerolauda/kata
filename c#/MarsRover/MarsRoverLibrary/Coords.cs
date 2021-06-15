using System;

namespace MarsRover
{
    public readonly struct Coords
    {
        public int X { get; }
        public int Y { get; }
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj)
        {
            return obj is Coords coords && Equals(coords);
        }

        private bool Equals(Coords other)
        {
            if (X != other.X)
            {
                return false;
            }

            return Y == other.Y;
        }

        public override int GetHashCode()
        {
            return (X << 2) ^ Y;
        }

        public static bool operator ==(Coords coord1, Coords coord2)
        {
            return coord1.Equals(coord2);
        }

        public static bool operator !=(Coords coord1, Coords coord2)
        {
            return !coord1.Equals(coord2);
        }


        public override string ToString()
        {
            return $"Coords({X}, {Y})";
        }
    }
}
