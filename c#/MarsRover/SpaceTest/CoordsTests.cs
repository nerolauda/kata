using FluentAssertions;
using NUnit.Framework;
using Space;
using System;

namespace MarsRoverTest
{
    [TestFixture]
    public class CoordsTests
    {

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 3)]
        [TestCase(2, 6)]
        [TestCase(3, 8)]
        [TestCase(4, -10)]
        public void WhenConstructInstanceXYReflectsCOnstrutorParams(int x, int y)
        {
            Coords coords = new Coords(x, y);
            coords.X.Should().Be(x);
            coords.Y.Should().Be(y);
        }

        [TestCase(0, 0)]
        [TestCase(1, 3)]
        [TestCase(2, 6)]
        [TestCase(3, 8)]
        [TestCase(4, -10)]
        public void WhenCoordsHaveSameDataEqualsIsTrue(int x, int y)
        {
            Coords coords = new Coords(x, y);
            Coords coords1 = new Coords(x, y);

            coords.Equals(coords1).Should().BeTrue();
        }

        [Test]
        [TestCase(0, 0, 4, 1)]
        [TestCase(1, 3, 89, 232)]
        [TestCase(2, 6, 2, 7)]
        [TestCase(3, 8, 345, 8)]
        [TestCase(4, -10, 456, -4356)]
        public void WhenCoordsHaveDifferentDataEqualsIsFalse(int x, int y, int x1, int y1)
        {
            Coords coords = new Coords(x, y);
            Coords coords1 = new Coords(x1, y1);

            coords.Equals(coords1).Should().BeFalse();
        }

        [Test]
        public void WhenComparedWithNullEqualsIsFalse()
        {
            Coords coords = new Coords(10, 2);
            coords.Equals(null).Should().BeFalse();
        }

        [Test]
        public void WhenComparedWithDiffentTypeEqualsIsFalse()
        {
            Coords coords = new Coords(10, 2);
            coords.Equals("ANYSTRING").Should().BeFalse();
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 3)]
        [TestCase(2, 6)]
        [TestCase(3, 8)]
        [TestCase(4, -10)]
        public void WhenCoordsHaveSameDataHashIsSame(int x, int y)
        {
            Coords coords = new Coords(x, y);
            Coords coords1 = new Coords(x, y);

            coords.GetHashCode().Should().Be(coords1.GetHashCode());
        }
        [Test]
        [TestCase(0, 0, 4, 1)]
        [TestCase(1, 3, 89, 232)]
        [TestCase(2, 6, 2, 7)]
        [TestCase(3, 8, 345, 8)]
        [TestCase(4, -10, 456, -4356)]
        public void WhenCoordsHaveDifferentDataHashIsSame(int x, int y, int x1, int y1)
        {
            Coords coords = new Coords(x, y);
            Coords coords1 = new Coords(x1, y1);

            coords.GetHashCode().Should().NotBe(coords1.GetHashCode());
        }

        [TestCase(0, 0)]
        [TestCase(1, 3)]
        [TestCase(2, 6)]
        [TestCase(3, 8)]
        [TestCase(4, -10)]
        public void WhenCoordsHaveSameDataOperatorEqualIsTrue(int x, int y)
        {
            Coords coords = new Coords(x, y);
            Coords coords1 = new Coords(x, y);

            bool result = coords == coords1;
            result.Should().BeTrue();
        }

        [TestCase(0, 0)]
        [TestCase(1, 3)]
        [TestCase(2, 6)]
        [TestCase(3, 8)]
        [TestCase(4, -10)]
        public void WhenCoordsHaveSameDataOperatorNotEqualIsFalse(int x, int y)
        {
            Coords coords = new Coords(x, y);
            Coords coords1 = new Coords(x, y);

            bool result = coords != coords1;
            result.Should().BeFalse();
        }

        [Test]
        [TestCase(0, 0, 4, 1)]
        [TestCase(1, 3, 89, 232)]
        [TestCase(2, 6, 2, 7)]
        [TestCase(3, 8, 345, 8)]
        [TestCase(4, -10, 456, -4356)]
        public void WhenCoordsHaveDifferentDataOperatorNotEqualIsTrue(int x, int y, int x1, int y1)
        {
            Coords coords = new Coords(x, y);
            Coords coords1 = new Coords(x1, y1);

            bool result = coords != coords1;
            result.Should().BeTrue();
        }
        [Test]
        [TestCase(0, 0, 4, 1)]
        [TestCase(1, 3, 89, 232)]
        [TestCase(2, 6, 2, 7)]
        [TestCase(3, 8, 345, 8)]
        [TestCase(4, -10, 456, -4356)]
        public void WhenCoordsHaveDifferentDataOperatorEqualIsFalse(int x, int y, int x1, int y1)
        {
            Coords coords = new Coords(x, y);
            Coords coords1 = new Coords(x1, y1);

            bool result = coords == coords1;
            result.Should().BeFalse();
        }

    }
}
