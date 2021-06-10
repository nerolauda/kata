using FluentAssertions;
using MarsRover;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTest
{
    [TestFixture]
    public class TestMoveResult
    {
        [Test]
        public void WhenNotInvokedObstacleAtIsPresentReturnFalse()
        {
            MoveResult moveResult = new MoveResult();
            moveResult.ObstacleFound().Should().BeFalse();
        }


        [Test]
        public void WhenInvokedObstacleAtIsPresentReturnTrue()
        {
            MoveResult moveResult = new MoveResult();
            moveResult.ObstacledAt(new Coords(0, 0));
            moveResult.ObstacleFound().Should().BeTrue();
        }

        [Test]
        public void WhenInvokedObstacleAtObstaclPositionReturnsCoords()
        {
            Coords expectedCoords = new Coords(100, 100);
            MoveResult moveResult = new MoveResult();
            moveResult.ObstacledAt(expectedCoords);
            moveResult.ObstaclePosition.Should().Be(expectedCoords);
        }
    }
}
