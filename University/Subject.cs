using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class Subject
    {
        private readonly ITableFormatter _tableFormatter;
        private Teacher _teacher;

        public University University { get; private set; }

        public string SubjectGuid { get; }

        private bool IsTeacherSet
        {
            get
            {
                return _teacher != null;
            }
        }

        public string Name { get; }

        public Subject(string name, University university, ITableFormatter tableFormatter)
        {
            Name = name;
            University = university;
            SubjectGuid = Guid.NewGuid().ToString();
            _tableFormatter = tableFormatter;
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

        public string GetFormattedInfo()
        {
            var result = new StringBuilder();
            result.Append(_tableFormatter.FormatRow(University.UniversityName, Name, GetTeacher()));
            return result.ToString();
        }

        public string GetTeacher() => 
            _teacher != null?_teacher.Name + " " + _teacher.Surname:"Teacher is not set";
    }
}