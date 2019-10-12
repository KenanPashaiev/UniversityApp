using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UniversityApp.Common.Abstractions;

namespace UniversityApp.Common
{
    [Serializable]
    public class Teacher : Person
    {
        private string _subjectName;

        public string UniversityName { get; set; }

        public bool IsSubjectSet
        {
            get
            {
                return _subjectName != string.Empty && _subjectName != null; ;
            }
        }
        
        public string SubjectName
        {
            get
            {
                if (IsSubjectSet)
                {
                    return _subjectName;
                }
                return "Subject is not set";
            }
            set
            {
                if(value != string.Empty && value != null)
                {
                    _subjectName = value;
                }
            }
        }

        public Teacher()
            : base()
        {
            UniversityName = string.Empty;
        }

        public Teacher(string name, string surname, int age, University university)
            : base(name, surname, age)
        {
            UniversityName = university.UniversityName;
        }

        public void SetSubject(Subject subject)
        {
            SubjectName = subject.Name;
        }

        public void RemoveSubject()
        {
            SubjectName = string.Empty;
        }
    }
}
