using System;
using NUnit.Framework;
using ShapesSquare;
namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TriangleSquareTest()
        {
            Triangle triangle = new Triangle(1, 1, 1);
            var result = triangle.Square();
            Assert.IsTrue(result.Equals(0.4330127018922193),"error");
        }
        
        [Test]
        public void RoundSquareTest()
        {
           Circle circle = new Circle(1);
           var result = circle.Square();
           Assert.IsTrue(result.Equals(Math.PI*1),"error");
        }

        [Test]
        public void UnknownShapeTest()
        {
            UnknownShape unknownShape1 = new UnknownShape(1);
            UnknownShape unknownShape2 = new UnknownShape(1,1,1);
            var result1 = unknownShape1.Square();
            var result2 = unknownShape2.Square();
            Assert.IsTrue(result1.Equals(Math.PI*1) && result2.Equals(0.4330127018922193),"error");
        }
    }
}