using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int StudentAge { get; set; }
        public int GroupId { get; set; }

        public Student(string studentName, string studentSurname, int studentAge)
        {
            StudentName = studentName;
            StudentSurname = studentSurname;
            StudentAge = studentAge;
        }

        public Student(string studentName, string studentSurname, int studentAge, int groupId) : this(studentName,
            studentSurname, studentAge)
        {
            GroupId = groupId;
        }
    }
}
