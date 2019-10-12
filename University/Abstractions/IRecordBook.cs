using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    interface IRecordBook
    {
        bool AddSubject(Subject subject);
        bool AddMark(int mark, Subject subject);

        MarkedSubject GetMaximalMarkedSubjectOfStudent();
        MarkedSubject GetMinimalMarkedSubjectOfStudent();

        string GetFormattedRecordBook();
    }
}
