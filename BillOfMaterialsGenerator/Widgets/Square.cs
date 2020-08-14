using System;

namespace BillOfMaterialsGenerator
{
    public class Square : Widget
    {
        private readonly string widgetType;
        public Square(int positionX, int positionY, int width)
        {
            widgetType = "Square";
            PositionX = positionX;
            PositionY = positionY;
            Width = width;
        }
        public override string WidgetType => widgetType;

        public int Width { get; }
        public override string AdditionalOutput()
        {
            return $"size={Width}";
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

            if (Width < 0)
            {
                error = "Width must be positive";
                return false;
            }

            if (PositionX + Width > canvas.Width)
            {
                error = $"Too wide for canvas width {canvas.Width}";
                return false;
            }

            if (PositionY + Width > canvas.Height)
            {
                error = $"Too tall for canvas height {canvas.Height}"; ;
                return false;
            }

            return true;
        }
    }
}
