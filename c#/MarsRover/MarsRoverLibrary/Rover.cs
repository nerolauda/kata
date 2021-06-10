using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Rover
    {
        private readonly IPlanetGrid planetGrid;
        public Coords Position { get; private set; }
        private Direction direction;

        public Rover(IPlanetGrid planetGrid, Coords landingPositionposition, Direction initialDirection)
        {
            this.planetGrid = planetGrid;
            this.Position = landingPositionposition;
            this.direction = initialDirection;
        }
        public void Move(Versus versus)
        {
            Position = planetGrid.NextCoords(Position, direction, versus);
        }
    }
}
