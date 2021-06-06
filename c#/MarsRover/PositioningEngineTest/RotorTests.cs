using FluentAssertions;
using MarsRover;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PositioningEngineTest
{
    class RotorTests
    {
        [Test]
        public void RotorDirectionReturnExpectedInitializedDirection()
        {
            foreach (Direction expectedDirection in Enum.GetValues(typeof(Direction)))
            {
                Rotor rotor = new Rotor(expectedDirection);
                Direction result = rotor.Direction;
                result.Should().Be(expectedDirection);
            }
        }

        [Test]
        public void WhenInitialDirectionIsEastAfterRotateLeftDirectionIsNorth()
        {
            var expectedDirection = Direction.East;
            Rotor rotor = new Rotor(expectedDirection);
            Direction result = rotor.RotateLeft();
            result.Should().Be(Direction.North);
        }


        [Test]
        public void WhenInitialDirectionIsNorthAfterRotateLeftDirectionIsWest()
        {
            var expectedDirection = Direction.North;
            Rotor rotor = new Rotor(expectedDirection);
            Direction result = rotor.RotateLeft();
            result.Should().Be(Direction.West);
        }

        [Test]
        public void WhenInitialDirectionIsWestAfterRotateLeftDirectionIsSouth()
        {
            var expectedDirection = Direction.West;
            Rotor rotor = new Rotor(expectedDirection);
            Direction result = rotor.RotateLeft();
            result.Should().Be(Direction.South);
        }

        [Test]
        public void WhenInitialDirectionIsSouthAfterRotateLeftDirectionIsEast()
        {
            var expectedDirection = Direction.South;
            Rotor rotor = new Rotor(expectedDirection);
            Direction result = rotor.RotateLeft();
            result.Should().Be(Direction.East);
        }

        [Test]
        public void WhenInitialDirectionIsEasthAfterRotateRightDirectionIsSouth()
        {
            var expectedDirection = Direction.East;
            Rotor rotor = new Rotor(expectedDirection);
            Direction result = rotor.RotateRight();
            result.Should().Be(Direction.South);
        }


        [Test]
        public void WhenInitialDirectionIsSouthAfterRotateRightDirectionIsWest()
        {
            var expectedDirection = Direction.South;
            Rotor rotor = new Rotor(expectedDirection);
            Direction result = rotor.RotateRight();
            result.Should().Be(Direction.West);
        }


        [Test]
        public void WhenInitialDirectionIsWestAfterRotateRightDirectionIsNorth()
        {
            var expectedDirection = Direction.West;
            Rotor rotor = new Rotor(expectedDirection);
            Direction result = rotor.RotateRight();
            result.Should().Be(Direction.North);
        }

        [Test]
        public void WhenInitialDirectionIsNorthAfterRotateRightDirectionIsEast()
        {
            var expectedDirection = Direction.North;
            Rotor rotor = new Rotor(expectedDirection);
            Direction result = rotor.RotateRight();
            result.Should().Be(Direction.East);
        }





    }
}
