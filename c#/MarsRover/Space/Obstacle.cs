using System;

namespace Space
{
    public class Obstacle
    {
        private Coords obstacleCoords;

        public Obstacle(Coords obstacleCoords)
        {
            this.obstacleCoords = obstacleCoords;
        }

        public bool Matches(Coords checkCoords)
        {
            return checkCoords.X == obstacleCoords.X && checkCoords.Y == obstacleCoords.Y;
        }
    }
}