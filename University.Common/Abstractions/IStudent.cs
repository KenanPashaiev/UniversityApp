using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.Common.Abstractions
{
    public interface IStudent
    {
        //string GetFormattedRecordBook();
        //string GetFormattedInfo();

        bool AddSubjectToRecordBook(Subject subject);
        bool AddMarkToRecordBook(int mark, Subject subject);
    }
}
