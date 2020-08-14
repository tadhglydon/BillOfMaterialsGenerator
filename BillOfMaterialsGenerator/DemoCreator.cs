using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterialsGenerator
{
    public class DemoCreator    
    {
        public ILog Log { get; set; }
        public void RunDemoWidgetCreation()
        {
            var canvas = new Canvas { Height = 1000, Width = 1000 };
            var materialFactory = new MaterialsFactory(Log, canvas);
            var exampleWidgets = new List<Widget> { Rectangle, Square, Ellipse, Circle, Textbox };
            Console.WriteLine(materialFactory.ProcessWidgets(exampleWidgets));
        }

        private Widget Rectangle => new Rectangle(10, 10, 30, 40);

        private Widget Square => new Square(15, 30, 35);

        private Widget Ellipse => new Ellipse(100, 150, 300, 200);

        private Widget Circle => new Circle(1, 1, 300);

        private Widget Textbox => new Textbox(5, 5, 200, 100, "sample text");
    }
}
