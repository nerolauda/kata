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

    }
}
