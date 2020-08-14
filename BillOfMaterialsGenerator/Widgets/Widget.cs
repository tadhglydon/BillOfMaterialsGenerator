using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterialsGenerator
{
    public abstract class Widget
    {
        public abstract string WidgetType { get; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public abstract bool Validate(Canvas canvas, out string error);
        public abstract string AdditionalOutput();
        public string WriteOutput()
        {
            return $"{WidgetType} ({PositionX},{PositionY}) {AdditionalOutput()}";
        }
    }
}
