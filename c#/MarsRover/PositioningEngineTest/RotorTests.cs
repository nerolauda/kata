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
            foreach (MarsEngineDirection expectedDirection in Enum.GetValues(typeof(MarsEngineDirection)))
            {
                MarsEngineRotor rotor = new MarsEngineRotor(expectedDirection);
                MarsEngineDirection result = rotor.Direction;
                result.Should().Be(expectedDirection);
            }
        }

        [Test]
        public void WhenInitialDirectionIsEastAfterRotateLeftDirectionIsNorth()
        {
            var expectedDirection = MarsEngineDirection.East;
            MarsEngineRotor rotor = new MarsEngineRotor(expectedDirection);
            MarsEngineDirection result = rotor.RotateLeft();
            result.Should().Be(MarsEngineDirection.North);
        }


        [Test]
        public void WhenInitialDirectionIsNorthAfterRotateLeftDirectionIsWest()
        {
            var expectedDirection = MarsEngineDirection.North;
            MarsEngineRotor rotor = new MarsEngineRotor(expectedDirection);
            MarsEngineDirection result = rotor.RotateLeft();
            result.Should().Be(MarsEngineDirection.West);
        }

        [Test]
        public void WhenInitialDirectionIsWestAfterRotateLeftDirectionIsSouth()
        {
            var expectedDirection = MarsEngineDirection.West;
            MarsEngineRotor rotor = new MarsEngineRotor(expectedDirection);
            MarsEngineDirection result = rotor.RotateLeft();
            result.Should().Be(MarsEngineDirection.South);
        }

        [Test]
        public void WhenInitialDirectionIsSouthAfterRotateLeftDirectionIsEast()
        {
            var expectedDirection = MarsEngineDirection.South;
            MarsEngineRotor rotor = new MarsEngineRotor(expectedDirection);
            MarsEngineDirection result = rotor.RotateLeft();
            result.Should().Be(MarsEngineDirection.East);
        }

        [Test]
        public void WhenInitialDirectionIsEasthAfterRotateRightDirectionIsSouth()
        {
            var expectedDirection = MarsEngineDirection.East;
            MarsEngineRotor rotor = new MarsEngineRotor(expectedDirection);
            MarsEngineDirection result = rotor.RotateRight();
            result.Should().Be(MarsEngineDirection.South);
        }


        [Test]
        public void WhenInitialDirectionIsSouthAfterRotateRightDirectionIsWest()
        {
            var expectedDirection = MarsEngineDirection.South;
            MarsEngineRotor rotor = new MarsEngineRotor(expectedDirection);
            MarsEngineDirection result = rotor.RotateRight();
            result.Should().Be(MarsEngineDirection.West);
        }


        [Test]
        public void WhenInitialDirectionIsWestAfterRotateRightDirectionIsNorth()
        {
            var expectedDirection = MarsEngineDirection.West;
            MarsEngineRotor rotor = new MarsEngineRotor(expectedDirection);
            MarsEngineDirection result = rotor.RotateRight();
            result.Should().Be(MarsEngineDirection.North);
        }





    }
}
