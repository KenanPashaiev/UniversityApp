using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class TableFormatter : ITableFormatter
    {
        private const int TableWidth = 175;

        public string FormatRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            var row = "|";
            
            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            return row + '\n';
        }

        private string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
