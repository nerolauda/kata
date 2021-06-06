using FluentAssertions;
using MarsRover;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PositioningEngineTest
{
    public class ObstacleTests
    {
        [Test]
        public void WhenCoordsAreSameMatchReturnsTrue()
        {
            Coords obstacleCoords = new Coords(10, 30);
            Obstacle obstacle = new Obstacle(obstacleCoords);
            bool result = obstacle.Matches(obstacleCoords);

        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(10, 29)]
        [TestCase(11, 30)]
        [TestCase(11, 29)]
        [TestCase(10, 31)]
        public void WhenCoordsAreNotSameMatchReturnsFalse(int checkX, int checkY)
        {
            Coords obstacleCoords = new Coords(10, 30);
            Coords checkCoords = new Coords(checkX, checkY);
            Obstacle obstacle = new Obstacle(obstacleCoords);
            bool result = obstacle.Matches(checkCoords);
            result.Should().BeFalse();
        }
    }
}
