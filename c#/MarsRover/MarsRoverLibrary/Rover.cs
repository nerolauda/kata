using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Rover
    {
        private readonly IPlanetGrid planetGrid;
        private Coords position;
        private Direction direction;

        public Rover(IPlanetGrid planetGrid, Coords landingPositionposition, Direction initialDirection)
        {
            this.planetGrid = planetGrid;
            this.position = landingPositionposition;
            this.direction = initialDirection;
        }
        public void Move(Versus versus)
        {
            Coords nextPosition = planetGrid.NextCoords(position, direction, versus);
        }
    }
}
