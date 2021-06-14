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
        public void WhenReceiveFCommandFRoverInvokesMOveForward()
        {
            var roverMock = new Mock<IRover>(MockBehavior.Strict);
            roverMock.Setup(rover => rover.Move(Versus.Forward)).Returns(new MoveResult());
            RoverCommander commander = new RoverCommander(roverMock.Object);
            commander.ExecuteCommands("f");
        }
    }
}
