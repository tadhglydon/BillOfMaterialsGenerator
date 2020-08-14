using NUnit.Framework;

namespace BillOfMaterialsGenerator.Tests
{
    public class TextboxValidationTests
    {
        private Canvas canvas;

        [SetUp]
        public void Setup()
        {
            canvas = new Canvas { Height = 1000, Width = 1000 };
        }

        [Test]
        public void TextboxValidate_WithinBoundary_ReturnsTrue()
        {
            string error;
            var Textbox = new Textbox(10, 10, 30, 40, "test");
            Assert.IsTrue(Textbox.Validate(canvas, out error));
        }

        [Test]
        public void TextboxValidate_MinusValue_ReturnsFalse()
        {
            string error;
            var Textbox1 = new Textbox(-10, 10, 30, 40, "test");
            Assert.IsFalse(Textbox1.Validate(canvas, out error));

            var Textbox2 = new Textbox(10, -10, 30, 40, "test");
            Assert.IsFalse(Textbox2.Validate(canvas, out error));

            var Textbox3 = new Textbox(10, 10, -30, 40, "test");
            Assert.IsFalse(Textbox3.Validate(canvas, out error));

            var Textbox4 = new Textbox(10, 10, 30, -40, "test");
            Assert.IsFalse(Textbox4.Validate(canvas, out error));
        }


        [Test]
        public void TextboxValidate_TooWide_ReturnsFalse()
        {
            string error;
            var Textbox = new Textbox(10, 10, 4000, 30, "test");
            Assert.IsFalse(Textbox.Validate(canvas, out error));
        }

        [Test]
        public void TextboxValidate_TooTall_ReturnsFalse()
        {
            string error;
            var Textbox = new Textbox(10, 1500, 40, 30, "test");
            Assert.IsFalse(Textbox.Validate(canvas, out error));
        }
    }
}
