using FluentAssertions;
using MarsRover;
using NUnit.Framework;

namespace PoistioningEngineTest
{
    class EngineTests
    {
        [Test]
        public void WhenEngineMoveForwardItReturnsOne()
        {
            int expectedValue = 1;

            MarsRoverEngine engine = new MarsRoverEngine();
            int result = engine.Move(MarsRoverEngineDirection.Forward);
            result.Should().Be(expectedValue);

        }
        [Test]
        public void WhenEngineMoveBackwardItReturnsMinusOne()
        {
            int expectedValue = -1;

            MarsRoverEngine engine = new MarsRoverEngine();
            int result = engine.Move(MarsRoverEngineDirection.Backward);
            result.Should().Be(expectedValue);

        }
    }
}
