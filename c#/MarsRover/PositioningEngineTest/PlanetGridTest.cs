using FluentAssertions;
using MarsRoverLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PositioningEngineTest
{
    public class PlanetGridTest
    {
        [Test]
        public void ConstructWithRegularLimitsDoNotThwrowExceptions()
        {
            Coords minCoord = new Coords(-10, -20);
            Coords maxCoord = new Coords(20, 40);
            Action action = () => new PlanetGrid(minCoord, maxCoord);
            action.Should().NotThrow();

        }
    }
}
