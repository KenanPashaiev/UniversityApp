using System;
using System.Collections.Generic;
using System.Text;

namespace University.Abstractions
{
    interface IGroup
    {
        bool AddStudent(Student student);

        string GetFormattedStudents();
        string GetFormattedInfo();
    }
}
