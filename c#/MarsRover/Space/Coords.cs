using System;
using System.Drawing;

namespace Space
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

		public override int GetHashCode() => Combine(X, Y);

		private int Combine(int h1, int h2)
		{
			uint rol5 = ((uint)h1 << 5) | ((uint)h1 >> 27);
			return ((int)rol5 + h1) ^ h2;
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
