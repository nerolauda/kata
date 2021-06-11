using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Rover
    {
        private readonly IPlanetGrid planetGrid;
        public Coords Position { get; private set; }
        private IRotor rotor;
        private Dictionary<Rotation, Action> rotationActions;






        public Rover(IPlanetGrid planetGrid, Coords landingPositionposition, IRotor rotor)
        {
            this.planetGrid = planetGrid;
            this.Position = landingPositionposition;
            this.rotor = rotor;
            rotationActions = new Dictionary<Rotation, Action>();
            rotationActions.Add(Rotation.Left, () => rotor.RotateLeft());
            rotationActions.Add(Rotation.Right, () => rotor.RotateRight());
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
