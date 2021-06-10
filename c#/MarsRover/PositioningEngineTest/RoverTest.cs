﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using MarsRover;
using Moq;
using NUnit.Framework;

namespace MarsRoverTest
{
    [TestFixture]
    class RoverTest
    {
        [Test]
        public void WhenRoverMovePlanetGridNextCoordIsInvokedProperly()
        {
            Coords landingCoords = new Coords(10, 10);
            Coords nextCoords = new Coords(11, 10);
            Direction initialDirection = Direction.East;
            Versus versus = Versus.Forward;

            var planetGridMock = new Mock<IPlanetGrid>(MockBehavior.Strict);
            planetGridMock.Setup(grid => grid.NextCoords(landingCoords, initialDirection, versus)).Returns(nextCoords);
            planetGridMock.Setup(grid => grid.CheckObstacle(nextCoords)).Returns(It.IsAny<bool>());

            Rover rover = new Rover(planetGridMock.Object, landingCoords, initialDirection);
            rover.Move(versus);
        }

        [Test]
        public void WhenThereIsNoObstacleAndRoverMoveRoverCoordsChange()
        {
            Coords landingCoords = new Coords(10, 10);
            Coords nextCoords = new Coords(11, 10);
            Direction initialDirection = Direction.East;
            Versus versus = Versus.Forward;

            var planetGridMock = new Mock<IPlanetGrid>(MockBehavior.Strict);
            planetGridMock.Setup(grid => grid.NextCoords(landingCoords, initialDirection, versus)).Returns(nextCoords);
            planetGridMock.Setup(grid => grid.CheckObstacle(nextCoords)).Returns(false);

            Rover rover = new Rover(planetGridMock.Object, landingCoords, initialDirection);
            rover.Move(versus);
            rover.Position.Should().Be(nextCoords);
        }

        [Test]
        public void WhenThereIsAnObstacleAndRoverMoveRoverCoordsDoNotChange()
        {
            Coords landingCoords = new Coords(10, 10);
            Coords nextCoords = new Coords(11, 10);
            Direction initialDirection = Direction.East;
            Versus versus = Versus.Forward;

            var planetGridMock = new Mock<IPlanetGrid>(MockBehavior.Strict);
            planetGridMock.Setup(grid => grid.NextCoords(landingCoords, initialDirection, versus)).Returns(nextCoords);
            planetGridMock.Setup(grid => grid.CheckObstacle(nextCoords)).Returns(true);

            Rover rover = new Rover(planetGridMock.Object, landingCoords, initialDirection);
            rover.Move(versus);
            rover.Position.Should().Be(landingCoords);
        }
    }


}
