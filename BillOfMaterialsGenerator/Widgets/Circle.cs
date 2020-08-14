using System;

namespace BillOfMaterialsGenerator
{
    public class Circle : Widget
    {
        private readonly string widgetType;
        public Circle(int positionX, int positionY, int diameter)
        {
            widgetType = "Circle";
            PositionX = positionX;
            PositionY = positionY;
            Diameter = diameter;
        }
        public override string WidgetType => widgetType;
        public int Diameter  { get; }
        public override string AdditionalOutput()
        {
            return $"size={Diameter}";
        }
        public override bool Validate(Canvas canvas, out string error)
        {
            error = "";
            
            if (PositionX < 0)
            {
                error = "Position X must be positive";
                return false;
            }
            
            if (PositionY < 0)
            {
                error = "Position Y must be positive";
                return false;
            }
            
            if (Diameter < 0)
            {
                error = "Diameter must be positive";
                return false;
            }

            if (PositionX + Diameter > canvas.Width)
            {
                error = $"Too wide for canvas width {canvas.Width}";
                return false;
            }

            if (PositionY + Diameter > canvas.Height)
            {
                error = $"Too tall for canvas height {canvas.Height}"; ;
                return false;
            }
            return true;
        }
    }
}
