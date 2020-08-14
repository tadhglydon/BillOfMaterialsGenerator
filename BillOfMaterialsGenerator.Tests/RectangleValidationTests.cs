using NUnit.Framework;

namespace BillOfMaterialsGenerator.Tests
{
    public class RectangleValidationTests
    {
        private Canvas canvas;

        [SetUp]
        public void Setup()
        {
            canvas = new Canvas { Height = 1000, Width = 1000 };
        }

        [Test]
        public void RectangleValidate_WithinBoundary_ReturnsTrue()
        {
            string error;
            var rectangle = new Rectangle(10, 10, 30, 40);
            Assert.IsTrue(rectangle.Validate(canvas, out error));
        }

        [Test]
        public void RectangleValidate_MinusValue_ReturnsFalse()
        {
            string error;
            var rectangle1 = new Rectangle(-10, 10, 30, 40);
            Assert.IsFalse(rectangle1.Validate(canvas, out error));

            var rectangle2 = new Rectangle(10, -10, 30, 40);
            Assert.IsFalse(rectangle2.Validate(canvas, out error));

            var rectangle3 = new Rectangle(10, 10, -30, 40);
            Assert.IsFalse(rectangle3.Validate(canvas, out error));

            var rectangle4 = new Rectangle(10, 10, 30, -40);
            Assert.IsFalse(rectangle4.Validate(canvas, out error));
        }


        [Test]
        public void RectangleValidate_TooWide_ReturnsFalse()
        {
            string error;
            var rectangle = new Rectangle(10, 10, 4000, 30);
            Assert.IsFalse(rectangle.Validate(canvas, out error));
        }

        [Test]
        public void RectangleValidate_TooTall_ReturnsFalse()
        {
            string error;
            var rectangle = new Rectangle(10, 1500, 40, 30);
            Assert.IsFalse(rectangle.Validate(canvas, out error));
        }
    }
}
