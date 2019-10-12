using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    interface ITableFormatter
    {
        string FormatRow(params string[] columns);
    }
}
