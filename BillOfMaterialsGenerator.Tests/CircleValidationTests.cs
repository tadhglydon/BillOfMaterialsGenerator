using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterialsGenerator.Tests
{
    public class CircleValidationTests
    {
        private Canvas canvas;

        [SetUp]
        public void Setup()
        {
            canvas = new Canvas { Height = 1000, Width = 1000 };
        }

        [Test]
        public void CircleValidate_WithinBoundary_ReturnsTrue()
        {
            var Circle = new Circle(10, 10, 30);
            Assert.IsTrue(Circle.Validate(canvas, out string error));
        }

        [Test]
        public void CircleValidate_MinusValue_ReturnsFalse()
        {
            var Circle1 = new Circle(-10, 10, 30);
            Assert.IsFalse(Circle1.Validate(canvas, out string error));

            var Circle2 = new Circle(10, -10, 30);
            Assert.IsFalse(Circle2.Validate(canvas, out error));

            var Circle3 = new Circle(10, 10, -30);
            Assert.IsFalse(Circle3.Validate(canvas, out error));
        }

        [Test]
        public void CircleValidate_TooWide_ReturnsFalse()
        {
            var Circle = new Circle(10, 10, 4000);
            Assert.IsFalse(Circle.Validate(canvas, out string error));
        }
    }
}
