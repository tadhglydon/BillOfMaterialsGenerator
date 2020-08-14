using System;

namespace BillOfMaterialsGenerator
{
    public class Textbox : Widget
    {

        private readonly string widgetType;

        public Textbox(int positionX, int positionY, int width, int height, string sampleText = "")
        {
            widgetType = "Textbox";
            PositionX = positionX;
            PositionY = positionY;
            Width = width;
            Height = height;
            SampleText = sampleText;
        }
        
        public override string WidgetType => widgetType;
        public int Width { get; }
        public int Height { get; }
        public string SampleText { get; }

        public override string AdditionalOutput()
        {
            if(string.IsNullOrEmpty(SampleText))
            return $"width={Width} height={Height}";

            return $"width={Width} height={Height} text=\"{SampleText}\"";
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
            if (Height < 0)
            {
                error = "Height must be positive";
                return false;
            }

            if (PositionX + Width > canvas.Width)
            {
                error = $"Too wide for canvas width {canvas.Width}";
                return false;
            }

            if (PositionY + Height > canvas.Height)
            {
                error = $"Too tall for canvas height {canvas.Height}"; ;
                return false;
            }
            return true;
        }
    }
}
