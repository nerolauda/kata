using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space
{
    public class PlanetGrid : IPlanetGrid
    {
        private Coords MinPos { get; }
        private Coords MaxPos { get; }
        private readonly List<Obstacle> obstacles;

        public PlanetGrid(Coords minCoord, Coords maxCoord)
        {
            MinPos = minCoord;
            MaxPos = maxCoord;
            ValidateLimits();
            obstacles = new List<Obstacle>();
        }

        private void ValidateLimits()
        {
            if (MaxPos.X <= MinPos.X) throw new ArgumentException("MinPos.X MUST be lower than MaxPos.X");
            if (MaxPos.Y <= MinPos.Y) throw new ArgumentException("MinPos.Y MUST be lower than MaxPos.Y");
        }



        public Coords NextCoords(Coords coords, Direction direction, Versus versus)
        {
            double radiantAngle = (short)direction * Math.PI / 180.0;

            int newX = coords.X + (int)versus * (int)Math.Cos(radiantAngle);
            int newY = coords.Y + (int)versus * (int)Math.Sin(radiantAngle);

            newX = ApplyPacmManPrinciple(newX, MinPos.X, MaxPos.X);
            newY = ApplyPacmManPrinciple(newY, MinPos.Y, MaxPos.Y);

            return new Coords(newX, newY);
        }

        private static int ApplyPacmManPrinciple(int p, int minLim, int maxLim)
        {
            if (p > maxLim)
                return minLim;
            if (p < minLim)
                return maxLim;
            return p;
        }

        public IPlanetGrid AddObstacle(int obstacleX, int obstacleY)
        {
            Coords obstacleCoords = new Coords(obstacleX, obstacleY);
            ValidateCoords(obstacleCoords);
            obstacles.Add(new Obstacle(obstacleCoords));
            return this;
        }

        private void ValidateCoords(Coords coords)
        {
            if (coords.X < MinPos.X) throw new ArgumentException($"coord.X ({coords.X}) cannot be lower than {MinPos.X}");
            if (coords.X > MaxPos.X) throw new ArgumentException($"coord.X ({coords.X}) cannot be greater than {MaxPos.X}");
            if (coords.Y < MinPos.Y) throw new ArgumentException($"coord.Y ({coords.Y}) cannot be lower than {MinPos.Y}");
            if (coords.Y > MaxPos.Y) throw new ArgumentException($"coord.Y ({coords.Y}) cannot be greater than {MaxPos.Y}");
        }

        public bool CheckObstacle(Coords checkCoords)
        {
            return obstacles.Exists(o => o.Matches(checkCoords));
        }
    }
}
