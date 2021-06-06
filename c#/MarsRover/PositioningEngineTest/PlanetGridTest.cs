﻿using FluentAssertions;
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
        public void WhenDirectionIsEasthVersusIsForwardAndNotOnBorderNextCoordsRetunXplusOne()
        {
            Coords minCoord = new Coords(-10, -20);
            Coords maxCoord = new Coords(10, 20);
            Coords origin = new Coords(0, 0);
            Direction direction = Direction.East;
            Versus versus = Versus.Forward;
            var planetGrid = new PlanetGrid(minCoord, maxCoord);
            Coords result = planetGrid.NextCoords(origin, direction, versus);
            result.X.Should().Be(1);
            result.Y.Should().Be(0);
        }

        [Test]
        public void WhenDirectionIsNorthVersusIsForwardAndNotOnBorderNextCoordsRetunYplusOne()
        {
            Coords minCoord = new Coords(-10, -20);
            Coords maxCoord = new Coords(10, 20);
            Coords origin = new Coords(0, 0);
            Direction direction = Direction.North;
            Versus versus = Versus.Forward;
            var planetGrid = new PlanetGrid(minCoord, maxCoord);
            Coords result = planetGrid.NextCoords(origin, direction, versus);
            result.X.Should().Be(0);
            result.Y.Should().Be(1);
        }

        [Test]
        public void WhenDirectionIsWestVersusIsForwardAndNotOnBorderNextCoordsRetunXMinusOne()
        {
            Coords minCoord = new Coords(-10, -20);
            Coords maxCoord = new Coords(10, 20);
            Coords origin = new Coords(0, 0);
            Direction direction = Direction.West;
            Versus versus = Versus.Forward;
            var planetGrid = new PlanetGrid(minCoord, maxCoord);
            Coords result = planetGrid.NextCoords(origin, direction, versus);
            result.X.Should().Be(-1);
            result.Y.Should().Be(0);
        }

        [Test]
        public void WhenDirectionIsSouthVersusIsForwardAndNotOnBorderNextCoordsRetunYMinusOne()
        {
            Coords minCoord = new Coords(-10, -20);
            Coords maxCoord = new Coords(10, 20);
            Coords origin = new Coords(0, 0);
            Direction direction = Direction.South;
            Versus versus = Versus.Forward;
            var planetGrid = new PlanetGrid(minCoord, maxCoord);
            Coords result = planetGrid.NextCoords(origin, direction, versus);
            result.X.Should().Be(0);
            result.Y.Should().Be(-1);
        }

        

    }
}
