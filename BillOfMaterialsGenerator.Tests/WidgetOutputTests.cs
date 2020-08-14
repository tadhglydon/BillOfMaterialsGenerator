using NUnit.Framework;

namespace BillOfMaterialsGenerator.Tests
{
    public class WidgetOutputTests
    {

        [Test]
        public void CreateRectangle_WriteOutput_FormatCorrect()
        {
            var rectangle = new Rectangle(10, 10, 30, 40);
            Assert.AreEqual("Rectangle (10,10) width=30 height=40", rectangle.WriteOutput());
        }

        [Test]
        public void CreateSquare_WriteOutput_FormatCorrect()
        {
            var square = new Square(15, 30, 35);
            Assert.AreEqual("Square (15,30) size=35", square.WriteOutput());
        }
        [Test]
        public void CreateEllipse_WriteOutput_FormatCorrect()
        {
            var ellipse = new Ellipse(100, 150, 300, 200);
            Assert.AreEqual("Ellipse (100,150) diameterH = 300 diameterV = 200", ellipse.WriteOutput());
        }
        [Test]
        public void CreateCircle_WriteOutput_FormatCorrect()
        {
            var circle = new Circle(1, 1, 300);
            Assert.AreEqual("Circle (1,1) size=300", circle.WriteOutput());
        }

        [Test]
        public void CreateTextbox_WriteOutput_FormatCorrect()
        {
            var textbox = new Textbox(5, 5, 200, 100, "sample text");
            Assert.AreEqual("Textbox (5,5) width=200 height=100 text=\"sample text\"", textbox.WriteOutput());
        }

        [Test]
        public void CreateTextbox_WriteOutputWithNoSample_FormatCorrect()
        {
            var textbox = new Textbox(5, 5, 200, 100);
            Assert.AreEqual("Textbox (5,5) width=200 height=100", textbox.WriteOutput());
        }
    }
}