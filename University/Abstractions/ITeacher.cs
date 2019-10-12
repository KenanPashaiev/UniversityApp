using System;
using System.Collections.Generic;
using System.Text;

namespace University.Abstractions
{
    interface ITeacher
    {
        void SetSubject();
        void RemoveSubject();

        string GetFormattedInfo();
    }
}
