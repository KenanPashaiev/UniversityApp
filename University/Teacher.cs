using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class Teacher : Person
    {
        private readonly ITableFormatter _tableFormatter;

        public string UniversityName { get; private set; }

        public bool IsSubjectSet
        {
            get
            {
                return Subject != null;
            }
        }

        public Subject Subject { get; private set; }

        public Teacher(string name, string surname, int age, University university, ITableFormatter tableFormatter)
            : base(name, surname, age)
        {
            UniversityName = university.UniversityName;
            _tableFormatter = tableFormatter;
        }

        public void SetSubject(Subject subject)
        {
            Subject = subject;
        }

        public void RemoveSubject()
        {
            Subject = null;
        }

        public string GetFormattedInfo()
        {
            var result = new StringBuilder();
            result.Append(_tableFormatter.FormatRow(UniversityName, Name, Surname, Age.ToString(),
                                                IsSubjectSet ? Subject.Name : "Subject not set"));
            return result.ToString();
        }
    }
}
