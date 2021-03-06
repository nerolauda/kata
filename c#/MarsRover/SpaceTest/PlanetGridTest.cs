using FluentAssertions;
using NUnit.Framework;
using Space;
using System;


namespace MarsRoverTest
{
    [TestFixture]
    public class PlanetGridTest
    {
        [Test]
        public void WhenBorderLimitsAreRegularPlanetGridContructDoesNotThrowExceptions()
        {
            Coords minCoord = new Coords(-10, -20);
            Coords maxCoord = new Coords(20, 40);
            Action action = () => new PlanetGrid(minCoord, maxCoord);
            action.Should().NotThrow();
        }

        [Test]
        public void WhenXMinGTEXMaxPlanetGridConstructThrowsArgumentException()
        {
            Coords minCoord = new Coords(20, -20);
            Coords maxCoord = new Coords(20, 40);
            Action action = () => new PlanetGrid(minCoord, maxCoord);
            action.Should().Throw<ArgumentException>();
            minCoord = new Coords(21, -20);
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void WhenYMinGTEYMaxPlanetGridConstructThrowsArgumentException()
        {
            Coords minCoord = new Coords(-10, 40);
            Coords maxCoord = new Coords(20, 40);
            Action action = () => new PlanetGrid(minCoord, maxCoord);
            action.Should().Throw<ArgumentException>();
            minCoord = new Coords(-10, 50);
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        [TestCase(Versus.Forward, Direction.East, 0, 0, 1, 0)]
        [TestCase(Versus.Forward, Direction.North, 0, 0, 0, 1)]
        [TestCase(Versus.Forward, Direction.West, 0, 0, -1, 0)]
        [TestCase(Versus.Forward, Direction.South, 0, 0, 0, -1)]
        [TestCase(Versus.Backward, Direction.East, 0, 0, -1, 0)]
        [TestCase(Versus.Backward, Direction.North, 0, 0, 0, -1)]
        [TestCase(Versus.Backward, Direction.West, 0, 0, 1, 0)]
        [TestCase(Versus.Backward, Direction.South, 0, 0, 0, 1)]
        [Parallelizable(ParallelScope.All)]
        public void NextCoordsIsCoeherentWithExpectation(Versus versus, Direction direction, int startX, int startY, int expectedX, int expectedY)
        {
            Coords minCoord = new Coords(-10, -20);
            Coords maxCoord = new Coords(10, 20);
            var planetGrid = new PlanetGrid(minCoord, maxCoord);

            Coords origin = new Coords(startX, startY);

            Coords result = planetGrid.NextCoords(origin, direction, versus);
            result.X.Should().Be(expectedX);
            result.Y.Should().Be(expectedY);
        }

        [Test]
        [TestCase(Versus.Forward, Direction.East, 15, 2, -10, 2)]
        [TestCase(Versus.Forward, Direction.West, -10, 2, 15, 2)]
        [TestCase(Versus.Forward, Direction.North, 2, 25, 2, -20)]
        [TestCase(Versus.Forward, Direction.South, 2, -20, 2, 25)]
        [TestCase(Versus.Backward, Direction.East, -10, 2, 15, 2)]
        [TestCase(Versus.Backward, Direction.West, 15, 2, -10, 2)]
        [TestCase(Versus.Backward, Direction.South, 2, 25, 2, -20)]
        [TestCase(Versus.Backward, Direction.North, 2, -20, 2, 25)]
        [Parallelizable(ParallelScope.All)]
        public void NextCoordsIsCoeherentWithPacmanEffect(Versus versus, Direction direction, int startX, int startY, int expectedX, int expectedY)
        {
            Coords minCoord = new Coords(-10, -20);
            Coords maxCoord = new Coords(15, 25);
            var planetGrid = new PlanetGrid(minCoord, maxCoord);

            Coords origin = new Coords(startX, startY);

            Coords result = planetGrid.NextCoords(origin, direction, versus);
            result.X.Should().Be(expectedX);
            result.Y.Should().Be(expectedY);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(-15, 10)]
        [TestCase(10, 32)]
        [Parallelizable(ParallelScope.All)]
        public void WhenObstacleIsInsideGridAddbObstacleReturnPlanetGridItself(int obstacleX, int obstacleY)
        {
            Coords minCoord = new Coords(-15, -10);
            Coords maxCoord = new Coords(10, 32);
            var planetGrid = new PlanetGrid(minCoord, maxCoord);

            IPlanetGrid result = planetGrid.AddObstacle(obstacleX, obstacleY);
            result.Should().Be(planetGrid);

        }


        [Test]
        [TestCase(-16, 0)]
        [TestCase(11, 0)]
        [TestCase(0, -11)]
        [TestCase(0, 33)]
        [TestCase(11, 33)]
        [Parallelizable(ParallelScope.All)]
        public void WhenObstacleIsOutsideGridAddbObstacleThrowsArgumentException(int obstacleX, int obstacleY)
        {
            Coords minCoord = new Coords(-15, -10);
            Coords maxCoord = new Coords(10, 32);
            var planetGrid = new PlanetGrid(minCoord, maxCoord);

            Action action = () => planetGrid.AddObstacle(obstacleX, obstacleY);
            action.Should().Throw<ArgumentException>();

        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(8, 11)]
        [TestCase(9, 11)]
        [TestCase(8, 13)]
        [TestCase(9, 12)]
        public void WhenObstacleIsNotAtCoordsCheckObstacleReturnFalse(int checkX, int checkY)
        {
            Coords minCoord = new Coords(-15, -10);
            Coords maxCoord = new Coords(10, 32);
            Coords obstacleCoords = new Coords(8, 12);
            Coords checkCoords = new Coords(checkX, checkY);
            var planetGrid = new PlanetGrid(minCoord, maxCoord);

            planetGrid.AddObstacle(obstacleCoords.X, obstacleCoords.Y);
            bool result = planetGrid.CheckObstacle(checkCoords);
            result.Should().BeFalse();

        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(8, 11)]
        [TestCase(9, 11)]
        [TestCase(8, 13)]
        [TestCase(9, 12)]
        public void WhenObstacleIsAtCoordsCheckObstacleReturnTrue(int checkX, int checkY)
        {
            Coords minCoord = new Coords(-15, -10);
            Coords maxCoord = new Coords(10, 32);
            
            Coords checkCoords = new Coords(checkX, checkY);
            var planetGrid = new PlanetGrid(minCoord, maxCoord);

            planetGrid.AddObstacle(checkX, checkY);
            bool result = planetGrid.CheckObstacle(checkCoords);
            result.Should().BeTrue();

        }

    }
}
