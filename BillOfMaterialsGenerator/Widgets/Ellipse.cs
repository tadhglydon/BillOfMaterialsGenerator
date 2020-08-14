using System;

namespace BillOfMaterialsGenerator
{
    public class Ellipse : Widget
    {
        private readonly string widgetType;
        public Ellipse(int positionX, int positionY, int horizontalDiameter, int verticalDiameter)
        {
            widgetType = "Ellipse";
            PositionX = positionX;
            PositionY = positionY;
            HorizontalDiameter = horizontalDiameter;
            VerticalDiameter = verticalDiameter;
        }
        public override string WidgetType => widgetType;
        public int HorizontalDiameter { get; }
        public int VerticalDiameter { get; }
        public override string AdditionalOutput()
        {
            return $"diameterH = {HorizontalDiameter} diameterV = {VerticalDiameter}";
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

            if (HorizontalDiameter < 0)
            {
                error = "Horizontal Diameter must be positive";
                return false;
            }

            if (VerticalDiameter < 0)
            {
                error = "Vertical Diameter must be positive";
                return false;
            }

            if (PositionX + HorizontalDiameter > canvas.Width)
            {
                error = $"Too wide for canvas width {canvas.Width}";
                return false;
            }

            if (PositionY + VerticalDiameter > canvas.Height)
            {
                error = $"Too tall for canvas height {canvas.Height}";
                return false;
            }
            return true;
        }
    }
}
