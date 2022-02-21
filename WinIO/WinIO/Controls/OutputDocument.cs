using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using WinIO.Models;
using Brush = System.Windows.Media.Brush;
using FontFamily = System.Windows.Media.FontFamily;

namespace WinIO.Controls
{
    public class OutputDocument : FlowDocument
    {
        public OutputDocument()
        {
            this.Style = this.FindResource("OutputDocumentStyle") as Style;
        }

        public void InitContextMenu()
        {
            // ContextMenu
            var contextMenu = new ContextMenu();
            contextMenu.Style = contextMenu.FindResource("ContextMenuStyle") as Style;
            this.ContextMenu = contextMenu;
        }

        public void AppendText(string text, Brush fore = null, Brush back = null, string fm = null, double fs = 0)
        {
            // this.Document.Blocks.Add
            var pa = this.Blocks.LastBlock as Paragraph;
            if(pa == null)
            {
                AppendLine(text, fore, back, fm, fs);
                return;
            }
            var run = new Run(text);
            if (fs > 0) run.FontSize = fs;
            if (fore != null) run.Foreground = fore;
            if (back != null) run.Background = back;
            if (!string.IsNullOrEmpty(fm))
            {
                run.FontFamily = new FontFamily(fm);
            }
            pa.Inlines.Add(run);
        }

        public void AppendLine(string text, Brush fore = null, Brush back = null, string fm = null, double fs = 0)
        {
            var pa = new Paragraph();
            var run = new Run(text);
            if (fs > 0) run.FontSize = fs;
            if (fore != null) run.Foreground = fore;
            if (back != null) run.Background = back;
            if (!string.IsNullOrEmpty(fm))
            {
                run.FontFamily = new FontFamily(fm);
            }
            pa.Inlines.Add(run);
            this.Blocks.Add(pa);
        }
    }
}
