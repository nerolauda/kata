﻿using System;
using System.Collections.Generic;
using System.Text;
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
            Direction initialDirection = Direction.East;
			Versus versus = Versus.Forward;

            var planetGridMock = new Mock<IPlanetGrid>(MockBehavior.Strict);
			planetGridMock.Setup(grid => grid.NextCoords(landingCoords,initialDirection,versus)).Returns(It.IsAny<Coords>());
            Rover rover = new Rover(planetGridMock.Object, landingCoords, initialDirection);
            rover.Move(versus);
        }
    }


}