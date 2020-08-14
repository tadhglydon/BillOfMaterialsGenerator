using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterialsGenerator.Tests
{
    public class EllipseValidationTests
    {
        private Canvas canvas;

        [SetUp]
        public void Setup()
        {
            canvas = new Canvas { Height = 1000, Width = 1000 };
        }

        [Test]
        public void EllipseValidate_WithinBoundary_ReturnsTrue()
        {
            var ellipse = new Ellipse(10, 10, 30, 40);
            Assert.IsTrue(ellipse.Validate(canvas, out string error));
        }

        [Test]
        public void EllipseValidate_MinusValue_ReturnsFalse()
        {
            var Ellipse1 = new Ellipse(-10, 10, 30, 40);
            Assert.IsFalse(Ellipse1.Validate(canvas, out string error));

            var Ellipse2 = new Ellipse(10, -10, 30, 40);
            Assert.IsFalse(Ellipse2.Validate(canvas, out error));

            var Ellipse3 = new Ellipse(10, 10, -30, 40);
            Assert.IsFalse(Ellipse3.Validate(canvas, out error));

            var Ellipse4 = new Ellipse(10, 10, 30, -40);
            Assert.IsFalse(Ellipse4.Validate(canvas, out error));
        }


        [Test]
        public void EllipseValidate_TooWide_ReturnsFalse()
        {
            var Ellipse = new Ellipse(10, 10, 4000, 30);
            Assert.IsFalse(Ellipse.Validate(canvas, out string error));
        }

        [Test]
        public void EllipseValidate_TooTall_ReturnsFalse()
        {
            var Ellipse = new Ellipse(10, 15, 40, 3000);
            Assert.IsFalse(Ellipse.Validate(canvas, out string error));
        }

        [Test]
        public void EllipseValidate_OffCanvas_ReturnsFalse()
        {            
            var Ellipse = new Ellipse(10, 1500, 40, 30);
            Assert.IsFalse(Ellipse.Validate(canvas, out string error));
        }
    }
}
