using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using FontFamily = System.Windows.Media.FontFamily;

namespace WinIO.Controls
{
    public class OutputDocument : FlowDocument
    {
        public OutputDocument()
        {
            this.Style = this.FindResource("OutputDocumentStyle") as Style;
        }

        public void AppendText(string text, string fm = null, double fs = 0)
        {
            // this.Document.Blocks.Add
            var pa = this.Blocks.LastBlock as Paragraph;
            var run = new Run(text);
            if (fs > 0) run.FontSize = fs;
            if (!string.IsNullOrEmpty(fm))
            {
                run.FontFamily = new FontFamily(fm);
            }
            pa.Inlines.Add(run);
        }

        public void AppendLine(string text, string fm = null, double fs = 0)
        {
            var pa = new Paragraph();
            var run = new Run(text);
            if (fs > 0) run.FontSize = fs;
            if (!string.IsNullOrEmpty(fm))
            {
                run.FontFamily = new FontFamily(fm);
            }
            pa.Inlines.Add(run);
            this.Blocks.Add(pa);
        }
    }
}
