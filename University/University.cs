using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace University
{
    class University : IUniversity
    {
        private readonly ITableFormatter _tableFormatter;
        private IList<Group> _groupList;
        private IList<Teacher> _teacherList;
        private IList<Subject> _subjectList;
        private int _amountOfStudents; 

        public string UniversityName { get; }

        public University(string universityName, ITableFormatter tableFormatter)
        {
            UniversityName = universityName;
            _groupList = new List<Group>();
            _teacherList = new List<Teacher>();
            _subjectList = new List<Subject>();
            _amountOfStudents = 0;
            _tableFormatter = tableFormatter;
        }
        
        public bool AddGroup(string name)
        {
            var group = new Group(name, this, _tableFormatter);
            if(IsNewGroup(group))
            {
                _groupList.Add(group);
                return true;
            }
            return false;
        }

        //abstract factory(didn't read yet :P)
        public bool AddTeacher(string name, string surname, int age)
        {
            var teacher = new Teacher(name, surname, age, this, _tableFormatter);
            if (IsNewTeacher(teacher))
            {
                _teacherList.Add(teacher);
                return true;
            }
            return false;
        }

        public bool AddSubject(string name)
        {
            var subject = new Subject(name, this, _tableFormatter);
            if (IsNewSubject(subject))
            {
                _subjectList.Add(subject);
                return true;
            }
            return false;
        }

        public bool SetTeacherToSubject(int teacher, int subject) =>
            _subjectList[subject].SetTeacher(_teacherList[teacher]);

        public bool AddStudentToGroup(int group, string name, string surname, int age)
        {
            _amountOfStudents++;
            return _groupList[group].AddStudent(name, surname, age);
        }

        public bool AddSubjectToRecordBook(int group, int student, int subject) =>
            _groupList[group].AddSubjectToRecordBook(student, _subjectList[subject]);

        public bool AddMarkToRecordBook(int group, int student, int mark, int subject) =>
            _groupList[group].AddMarkToRecordBook(student, mark, _subjectList[subject]);

        public string GetFormattedGroups()
        {
            if (_groupList.Count > 0)
            {
                var result = new StringBuilder();
                result.Append(_tableFormatter.FormatRow("University name", "Group name", "Amount of students"));
                for (int i = 0; i < _groupList.Count; i++)
                {
                    result.Append(_groupList[i].GetFormattedInfo());
                }
                return result.ToString();
            }

            return "There are no groups in this university";
        }

        public string GetFormattedTeachers()
        {
            if (_teacherList.Count > 0)
            {
                var result = new StringBuilder();
                result.Append( _tableFormatter.FormatRow("University name", "Name", "Surname", "Age", "Subject"));
                for (int i = 0; i < _teacherList.Count; i++)
                {
                    result.Append( _teacherList[i].GetFormattedInfo());
                }
                return result.ToString();
            }

            return "There are no teachers in this university";
        }

        public string GetFormattedSubjects()
        {
            if (_subjectList.Count > 0)
            {
                var result = new StringBuilder();
                result.Append( _tableFormatter.FormatRow("University name", "Subject", "Teacher"));
                for (int i = 0; i < _subjectList.Count; i++)
                {
                    result.Append( _subjectList[i].GetFormattedInfo());
                }
                return result.ToString();
            }

            return "There are no subjects in your university";
        }

        public string GetFormattedStudents()
        {
            if (_amountOfStudents > 0)
            {
                var result = new StringBuilder();
                result.Append( _tableFormatter.FormatRow("Name", "Surname", "Group", "Max mark", "Max mark subject", "Min mark", "Min mark subject"));
                for(int i = 0; i < _groupList.Count; i++)
                {
                    result.Append( _groupList[i].GetFormattedStudents());
                }
                return result.ToString();
            }

            return "There are no students in your university";
        }

        public string GetFormattedRecordBook(int group, int student) => 
            _groupList[group].GetFormattedRecordBook(student);

        public string GetFormattedInfo()
        {
            var result = new StringBuilder(); //stringBuilder vs string, concatenation
            result.Append(_tableFormatter.FormatRow("University name", "Amount of groups", "Amount of teachers"));
            result.Append( _tableFormatter.FormatRow(UniversityName, _groupList.Count.ToString(), _teacherList.Count.ToString()));
            return result.ToString();
        }


        public int GetAmountOfGroups() => _groupList.Count;
        public int GetAmountOfTeachers() => _teacherList.Count;
        public int GetAmountOfSubjects() => _subjectList.Count;
        public int GetAmountOfStudents() => _amountOfStudents;
        public int GetAmountOfStudentsInGroup(int group) => _groupList[group].AmountOfStudents;


        private bool IsNewTeacher(Teacher newTeacher) => !_teacherList.Any(teacher => teacher.Age == newTeacher.Age &&
                                                                                     teacher.Name == newTeacher.Name &&
                                                                                     teacher.Surname == newTeacher.Surname);
        private bool IsNewGroup(Group newGroup) => !_groupList.Any(group => group.GroupName == newGroup.GroupName);
        private bool IsNewSubject(Subject newSubject) => !_subjectList.Any(subject => subject.Name == newSubject.Name);
    }
}
