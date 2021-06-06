using FluentAssertions;
using MarsRover;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoistioningEngineTest
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

    }
}
