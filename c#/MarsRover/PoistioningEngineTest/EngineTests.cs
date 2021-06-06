using FluentAssertions;
using MarsRover;
using NUnit.Framework;

namespace PoistioningEngineTest
{
    class EngineTests
    {
        [Test]
        public void WhenEngineMoveForwardItReturnsMinusOne()
        {
            int expectedValue = 1;

            MarsRoverEngine engine = new MarsRoverEngine();
            int result = engine.Move(MarsRoverEngineDirection.Forward);
            result.Should().Be(expectedValue);

        }
    }
}
