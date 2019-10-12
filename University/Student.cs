using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class Student : Person, IStudent
    {
        private int _age;
        private RecordBook _recordBook;
        private readonly ITableFormatter _tableFormatter;

        public Group Group { get; }

        public override int Age
        {
            get { return _age; }
        }

        //TODO: update
        public Student(string name, string surname, int age, Group group, ITableFormatter tableFormatter)
            : base(name, surname, age)
        {
            _recordBook = new RecordBook(_tableFormatter);
            Group = group;
            _tableFormatter = tableFormatter;
        }

        public string GetFormattedRecordBook() => _recordBook.GetFormattedRecordBook();

        public string GetFormattedInfo()
        {
            var result = new StringBuilder();
            var maximalMarkedSubject = _recordBook.GetMaximalMarkedSubjectOfStudent();
            var minimalMarkedSubject = _recordBook.GetMinimalMarkedSubjectOfStudent();

            result.Append(_tableFormatter.FormatRow(Name, Surname, Group.GroupName,
                    maximalMarkedSubject?.Mark.ToString() ?? "",
                    maximalMarkedSubject?.Subject.Name ?? "",
                    minimalMarkedSubject?.Mark.ToString() ?? "",
                    minimalMarkedSubject?.Subject.Name ?? ""));

            return result.ToString();
        }

        public bool AddSubjectToRecordBook(Subject subject) => _recordBook.AddSubject(subject);

        public bool AddMarkToRecordBook(int mark, Subject subject) => _recordBook.AddMark(mark, subject);
    }
}
