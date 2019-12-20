using System;
using NUnit.Framework;

namespace test2.tests
{
    [TestFixture]
    public class Tests
    {
        Circle circle = new Circle(4, 2, 7);

        [Test]
        public void GetInfoTest()
        {
            string expected = "Radius: 4\nCoordinates: (2;7)";
            string actual = circle.GetInfo();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAreaTest()
        {
            double actual = circle.GetArea();
            double expected = Math.PI * 4 * 4;
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void GetPerimeterTest()
        {
            double actual = circle.GetPerimeter();
            double expected = Math.PI * 2 * 4;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void VectorShiftTest()
        {
            circle.VectorShift(new Vector(1,2));
            string expected = "Radius: 4\nCoordinates: (3;9)";
            string actual = circle.GetInfo();
            Assert.AreEqual(expected, actual);
        }
    }
}