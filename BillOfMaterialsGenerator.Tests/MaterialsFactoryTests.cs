using NUnit.Framework;
using Moq;
using log4net;
using System.Collections.Generic;
using System;

namespace BillOfMaterialsGenerator.Tests
{
    public class MaterialsFactoryTests
    {
        private ILog log;
        private Canvas canvas;

        [SetUp]
        public void Setup()
        {
            var logMock = new Mock<ILog>();
            log = logMock.Object;
            canvas = new Canvas { Height = 1000, Width = 1000 };
        }

        [Test]
        public void MaterialsFactory_NoWidgets_EmptyResponse()
        {
            var materialsFactory = new MaterialsFactory(log, canvas);
            var result = materialsFactory.ProcessWidgets(new List<Widget>());
            Assert.AreEqual($"{Header}{Environment.NewLine}{Footer}", result);
        }


        [Test]
        public void MaterialsFactory_OneWidget_SingleLineResponse()
        {
            var rectangle = new Rectangle(10, 10, 30, 40);
            var rectangleOutput = "Rectangle (10,10) width=30 height=40";
            var materialsFactory = new MaterialsFactory(log, canvas);
            var result = materialsFactory.ProcessWidgets(new List<Widget> { rectangle });
            Assert.AreEqual($"{Header}{Environment.NewLine}{rectangleOutput}{Environment.NewLine}{Footer}", result);
        }

        [Test]
        public void MaterialsFactory_ThreeWidgets_MultiLineResponse()
        {
            var square = new Square(15, 30, 35);
            var squareOutput = "Square (15,30) size=35";
            var ellipse = new Ellipse(100, 150, 300, 200);
            var ellipseOutput = "Ellipse (100,150) diameterH = 300 diameterV = 200";
            var textbox = new Textbox(5, 5, 200, 100, "sample text");
            var textboxOutput = "Textbox (5,5) width=200 height=100 text=\"sample text\"";
            var materialsFactory = new MaterialsFactory(log, canvas);
            var result = materialsFactory.ProcessWidgets(new List<Widget> { square, ellipse, textbox});
            Assert.AreEqual($"{Header}{Environment.NewLine}{squareOutput}{Environment.NewLine}{ellipseOutput}{Environment.NewLine}{textboxOutput}{Environment.NewLine}{Footer}", result);
        }

        private string Header = $"----------------------------------------------------------------{Environment.NewLine}Bill of Materials{Environment.NewLine}----------------------------------------------------------------";
        private string Footer =  "----------------------------------------------------------------";
    }
}
