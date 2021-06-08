using FluentAssertions;
using MarsRover;
using NUnit.Framework;

namespace MarsRoverTest
{
    [TestFixture]
    class EngineTests
    {
        [Test]
        public void WhenEngineMoveForwardItReturnsOne()
        {
            int expectedValue = 1;

            Engine engine = new Engine();
            int result = engine.Move(Versus.Forward);
            result.Should().Be(expectedValue);

        }
        [Test]
        public void WhenEngineMoveBackwardItReturnsMinusOne()
        {
            int expectedValue = -1;

            Engine engine = new Engine();
            int result = engine.Move(Versus.Backward);
            result.Should().Be(expectedValue);

        }
    }
}
