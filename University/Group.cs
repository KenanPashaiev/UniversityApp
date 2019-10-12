using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace University
{
    class Group
    {
        private IList<Student> _studentList;  //replace
        private readonly ITableFormatter _tableFormatter;

        public string GroupName { get; }

        public University University { get; }

        public int AmountOfStudents { get; private set; } = 0;

        public Group(string groupName, University university, ITableFormatter tableFormatter)
        {
            GroupName = groupName;
            University = university;
            _studentList = new List<Student>();
            _tableFormatter = tableFormatter;
        }

        public bool AddStudent(string name, string surname, int age)
        {
            var student = new Student(name, surname, age, this, _tableFormatter);
            if (AmountOfStudents < 24 && IsNewStudent(student))
            {
                _studentList.Add(student);
                AmountOfStudents++;
                return true;
            }
            return false;
        }

        public bool AddSubjectToRecordBook(int student, Subject subject) => 
            _studentList[student].AddSubjectToRecordBook(subject);

        public bool AddMarkToRecordBook(int student, int mark, Subject subject) => 
            _studentList[student].AddMarkToRecordBook(mark, subject);

        public string GetFormattedStudents()
        {
            string result = string.Empty; //stringBUILDER, VAR!!!
            for(int i = 0; i < AmountOfStudents; i++)
            {
                result += _studentList[i].GetFormattedInfo();
            }
            return result;
        }

        public string GetFormattedRecordBook(int student) => _studentList[student].GetFormattedRecordBook();

        public string GetFormattedInfo()
        {
            var result = new StringBuilder();
            result.Append(_tableFormatter.FormatRow(University.UniversityName, GroupName, AmountOfStudents.ToString()));
            return result.ToString();
        }

        private bool IsNewStudent(Student student) => !_studentList.Any(stud => stud.Age == student.Age &&
                                                                               stud.Name == student.Name &&
                                                                               stud.Surname == student.Surname);
    }
}
