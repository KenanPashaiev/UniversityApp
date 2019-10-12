using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UniversityApp.Common.Abstractions;

namespace UniversityApp.Common
{
    [Serializable()]
    public class Student : Person, IStudent
    {
        private int _age;

        public RecordBook RecordBook { get; set; }

        public Group Group { get; }

        public override int Age
        {
            get { return _age; }
        }

        public Student() : base()
        {
            RecordBook = new RecordBook();
            Group = null;
            _age = 0;
        }

        public Student(string name, string surname, int age, Group group)
            : base(name, surname, age)
        {
            RecordBook = new RecordBook();
            Group = group;
            _age = age;
        }

        public bool AddSubjectToRecordBook(Subject subject) => RecordBook.AddSubject(subject);

        public bool AddMarkToRecordBook(int mark, Subject subject) => RecordBook.AddMark(mark, subject);
    }
}
