using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterialsGenerator
{
    public class MaterialsFactory
    {
        private ILog log;
        private Canvas canvas;

        public MaterialsFactory(ILog log, Canvas canvas)
        {
            this.log = log;
            this.canvas = canvas;
        }

        public string ProcessWidgets(List<Widget> widgets)
        {
            try
            {
                StringBuilder output = new StringBuilder();
                output.AppendLine("----------------------------------------------------------------");
                output.AppendLine("Bill of Materials");
                output.AppendLine("----------------------------------------------------------------");
                foreach (var widget in widgets)
                {
                    if(!widget.Validate(canvas, out string error))
                    {
                        log.Error($"Validation failed for {widget.WidgetType}. {error}");
                        return "+++++Abort+++++";
                    }
                    output.AppendLine(widget.WriteOutput());
                }
                output.Append("----------------------------------------------------------------");
                return output.ToString();
            }
            catch (Exception ex)
            {
                log.Error("Error occured processing widgets",ex);
                return "+++++Abort+++++";
            }
        }
    }
}
