using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public int TeacherAge { get; set; }
        public int SubjectId { get; set; }

        public Teacher(string teacherName, string teacherSurname, int teacherAge)
        {
            TeacherName = teacherName;
            TeacherSurname = teacherSurname;
            TeacherAge = teacherAge;
        }

        public Teacher(string teacherName, string teacherSurname, int teacherAge, int subjectId) : this(teacherName,
            teacherSurname, teacherAge)
        {
            SubjectId = subjectId;
        }
    }
}
