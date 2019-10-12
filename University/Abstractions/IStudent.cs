using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    interface IStudent
    {
        string GetFormattedRecordBook();
        string GetFormattedInfo();

        bool AddSubjectToRecordBook(Subject subject);
        bool AddMarkToRecordBook(int mark, Subject subject);
    }
}
