using MarsRover;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTest
{
    [TestFixture]
    public class RoverCommanderTest
    {
        [Test]
        public void WhenReceiveFCommandRoverInvokesMoveForward()
        {
            var roverMock = new Mock<IRover>(MockBehavior.Strict);
            roverMock.Setup(rover => rover.Move(Versus.Forward)).Returns(new MoveResult());
            RoverCommander commander = new RoverCommander(roverMock.Object);
            commander.ExecuteCommands("f");
        }
        [Test]
        public void WhenReceiveBCommandRoverInvokesMoveBackward()
        {
            var roverMock = new Mock<IRover>(MockBehavior.Strict);
            roverMock.Setup(rover => rover.Move(Versus.Backward)).Returns(new MoveResult());
            RoverCommander commander = new RoverCommander(roverMock.Object);
            commander.ExecuteCommands("b");
        }

        [Test]
        public void WhenReceiveRCommandRoverInvokesRotateRigth()
        {
            var roverMock = new Mock<IRover>(MockBehavior.Strict);
            roverMock.Setup(rover => rover.Rotate(Rotation.Right));
            RoverCommander commander = new RoverCommander(roverMock.Object);
            commander.ExecuteCommands("r");
        }

        [Test]
        public void WhenReceiveLCommandRoverInvokesRotateLeft()
        {
            var roverMock = new Mock<IRover>(MockBehavior.Strict);
            roverMock.Setup(rover => rover.Rotate(Rotation.Left));
            RoverCommander commander = new RoverCommander(roverMock.Object);
            commander.ExecuteCommands("l");
        }
        [Test]
        public void WhenReceiveMoreCommandsAndMoveDoNotDetectObstaclesCommandRoverInvokesAllOfThemInSequence()
        {
            var roverMock = new Mock<IRover>(MockBehavior.Strict);
            var sequence = new MockSequence();
            roverMock.InSequence(sequence).Setup(rover => rover.Rotate(Rotation.Left));
            roverMock.InSequence(sequence).Setup(rover => rover.Move(Versus.Forward)).Returns(new MoveResult());
            roverMock.InSequence(sequence).Setup(rover => rover.Rotate(Rotation.Right));
            roverMock.InSequence(sequence).Setup(rover => rover.Move(Versus.Backward)).Returns(new MoveResult());
            RoverCommander commander = new RoverCommander(roverMock.Object);
            commander.ExecuteCommands("lfrb");
            roverMock.Verify(rover => rover.Rotate(Rotation.Left), Times.Once);
            roverMock.Verify(rover => rover.Move(Versus.Forward), Times.Once);
            roverMock.Verify(rover => rover.Rotate(Rotation.Right), Times.Once);
            roverMock.Verify(rover => rover.Move(Versus.Backward), Times.Once);

        }

        [Test]
        public void WhenReceiveMoreCommandsAndMoveDetectObstacleCommandRoverInvokesAllOfThemInSequenceAndStopBeforeObstacle()
        {
            var roverMock = new Mock<IRover>(MockBehavior.Strict);
            MoveResult resultWithObstacle = new MoveResult();
            resultWithObstacle.ObstacledAt(new Coords(10, 0));

            roverMock.Setup(rover => rover.Rotate(Rotation.Right));
            roverMock.Setup(rover => rover.Move(Versus.Forward)).Returns(resultWithObstacle);
            RoverCommander commander = new RoverCommander(roverMock.Object);
            commander.ExecuteCommands("rfbbrbfllf");
            roverMock.Verify(rover => rover.Rotate(Rotation.Right), Times.Once);
            roverMock.Verify(rover => rover.Move(Versus.Forward), Times.Once);
            roverMock.Verify(rover => rover.Rotate(Rotation.Left), Times.Never);
            roverMock.Verify(rover => rover.Move(Versus.Backward), Times.Never);
        }
    }
}
