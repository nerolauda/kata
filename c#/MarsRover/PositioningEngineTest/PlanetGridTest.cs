using FluentAssertions;
using MarsRover;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PositioningEngineTest
{
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
        [TestCase(Versus.Forward, Direction.East, 10, 2, -10, 2)]
        
        [Parallelizable(ParallelScope.All)]
        public void NextCoordsIsCoeherentWithPacmanEffect(Versus versus, Direction direction, int startX, int startY, int expectedX, int expectedY)
        {
            Coords minCoord = new Coords(-10, -20);
            Coords maxCoord = new Coords(10, 20);
            var planetGrid = new PlanetGrid(minCoord, maxCoord);

            Coords origin = new Coords(startX, startY);

            Coords result = planetGrid.NextCoords(origin, direction, versus);
            result.X.Should().Be(expectedX);
            result.Y.Should().Be(expectedY);
        }



    }
}
