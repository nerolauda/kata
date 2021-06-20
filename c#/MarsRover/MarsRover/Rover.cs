using Space;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Rover : IRover
    {
        private readonly IPlanetGrid planetGrid;
        public Coords Position { get; private set; }
        private readonly IRotor rotor;
        private readonly Dictionary<Rotation, Action> rotationActions;

        public Rover(IPlanetGrid planetGrid, Coords landingPositionposition, IRotor rotor)
        {
            this.planetGrid = planetGrid;
            this.Position = landingPositionposition;
            this.rotor = rotor;
            rotationActions = new Dictionary<Rotation, Action>
            {
                {Rotation.Left, () => rotor.RotateLeft()},
                {Rotation.Right, () => rotor.RotateRight()}
            };
        }
        public MoveResult Move(Versus versus)
        {
            MoveResult moveResult = new MoveResult();
            Coords nextPosition = planetGrid.NextCoords(Position, rotor.Direction, versus);
            if (!planetGrid.CheckObstacle(nextPosition))
            {
                Position = nextPosition;
            }
            else
            {
                moveResult.ObstacledAt(nextPosition);
            }
            return moveResult;
        }

        public void Rotate(Rotation rotation)
        {
            rotationActions[rotation]();
        }


    }
}
