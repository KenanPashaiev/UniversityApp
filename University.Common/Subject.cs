using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UniversityApp.Common.Abstractions;

namespace UniversityApp.Common
{
    [Serializable()]
    public class Subject
    {
        public Teacher _teacher;

        public University University { get; }

        public string SubjectGuid { get; }

        public bool IsTeacherSet
        {
            get
            {
                return _teacher != null;
            }
        }

        public string TeacherName
        {
            get
            {
                if(IsTeacherSet)
                {
                    return _teacher.Name + _teacher.Surname;
                }
                return "Teacher is not set";
            }
        }

        public string Name { get; set; }

        public Subject()
        {
            Name = string.Empty;
            University = null;
            SubjectGuid = Guid.NewGuid().ToString();
        }

        public Subject(string name, University university)
        {
            Name = name;
            University = university;
            SubjectGuid = Guid.NewGuid().ToString();
        }

        public bool SetTeacher(Teacher teacher)
        {
            if (teacher.IsSubjectSet)
            {
                return false;
            }

            if (IsTeacherSet)
            {
                _teacher.RemoveSubject();
            }

            teacher.SetSubject(this);
            _teacher = teacher;

            return true;
        }

    }
}