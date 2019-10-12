using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.Common.Abstractions
{
    public interface IGroup
    {
        bool AddStudent(Student student);

        //string GetFormattedStudents();
        //string GetFormattedInfo();
    }
}
