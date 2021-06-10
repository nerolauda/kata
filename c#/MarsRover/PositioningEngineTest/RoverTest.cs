using FluentAssertions;
using MarsRover;
using Moq;
using NUnit.Framework;

namespace MarsRoverTest
{
    [TestFixture]
    class RoverTest
    {

        Coords landingCoords;
        Coords nextCoords;
        Direction initialDirection;
        Versus versus;

        [OneTimeSetUp]
        public void SetUp()
        {
            landingCoords = new Coords(10, 10);
            nextCoords = new Coords(11, 10);
            initialDirection = Direction.East;
            versus = Versus.Forward;
        }

        [Test]
        public void WhenRoverMovePlanetGridNextCoordIsInvokedProperly()
        {
            var planetGridMock = new Mock<IPlanetGrid>(MockBehavior.Strict);
            MockSequence sequence = new MockSequence();
            planetGridMock.InSequence(sequence).Setup(grid => grid.NextCoords(landingCoords, initialDirection, versus)).Returns(nextCoords);
            planetGridMock.InSequence(sequence).Setup(grid => grid.CheckObstacle(nextCoords)).Returns(It.IsAny<bool>());

            Rover rover = new Rover(planetGridMock.Object, landingCoords, initialDirection);
            rover.Move(versus);
        }

        [Test]
        public void WhenThereIsNoObstacleAndRoverMoveRoverCoordsChange()
        {
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
            var planetGridMock = new Mock<IPlanetGrid>(MockBehavior.Strict);
            planetGridMock.Setup(grid => grid.NextCoords(landingCoords, initialDirection, versus)).Returns(nextCoords);
            planetGridMock.Setup(grid => grid.CheckObstacle(nextCoords)).Returns(true);

            Rover rover = new Rover(planetGridMock.Object, landingCoords, initialDirection);
            rover.Move(versus);
            rover.Position.Should().Be(landingCoords);
        }

        [Test]
        public void WhenThereIsAnObstacleAndRoverMoveRoverReportsObstaclePresence()
        {
            var planetGridMock = new Mock<IPlanetGrid>(MockBehavior.Strict);
            planetGridMock.Setup(grid => grid.NextCoords(landingCoords, initialDirection, versus)).Returns(nextCoords);
            planetGridMock.Setup(grid => grid.CheckObstacle(nextCoords)).Returns(true);

            Rover rover = new Rover(planetGridMock.Object, landingCoords, initialDirection);
            MoveResult moveResult = rover.Move(versus);

            moveResult.ObstacleFound().Should().BeTrue();
            moveResult.ObstaclePosition.Should().Be(nextCoords);

        }

        [Test]
        public void WhenThereIsNoObstacleAndRoverMoveRoverReportsNoObstaclePresence()
        {
            var planetGridMock = new Mock<IPlanetGrid>(MockBehavior.Strict);
            planetGridMock.Setup(grid => grid.NextCoords(landingCoords, initialDirection, versus)).Returns(nextCoords);
            planetGridMock.Setup(grid => grid.CheckObstacle(nextCoords)).Returns(false);

            Rover rover = new Rover(planetGridMock.Object, landingCoords, initialDirection);
            MoveResult moveResult = rover.Move(versus);

            moveResult.ObstacleFound().Should().BeFalse();
        }
    }


}
