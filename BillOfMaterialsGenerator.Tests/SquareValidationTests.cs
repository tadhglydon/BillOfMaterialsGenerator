using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterialsGenerator.Tests
{
    public class SquareValidationTests
    {
        private Canvas canvas;

        [SetUp]
        public void Setup()
        {
            canvas = new Canvas { Height = 1000, Width = 1000 };
        }

        [Test]
        public void SquareValidate_WithinBoundary_ReturnsTrue()
        {
            var Square = new Square(10, 10, 30);
            Assert.IsTrue(Square.Validate(canvas, out string error));
        }

        [Test]
        public void SquareValidate_MinusValue_ReturnsFalse()
        {
            var Square1 = new Square(-10, 10, 30);
            Assert.IsFalse(Square1.Validate(canvas, out string error));

            var Square2 = new Square(10, -10, 30);
            Assert.IsFalse(Square2.Validate(canvas, out error));

            var Square3 = new Square(10, 10, -30);
            Assert.IsFalse(Square3.Validate(canvas, out error));
        }

        [Test]
        public void SquareValidate_TooWide_ReturnsFalse()
        {
            var Square = new Square(10, 10, 4000);
            Assert.IsFalse(Square.Validate(canvas, out string error));
        }

        [Test]
        public void SquareValidate_TooTall_ReturnsFalse()
        {
            var Square = new Square(10, 1500, 40);
            Assert.IsFalse(Square.Validate(canvas, out string error));
        }
    }
}
