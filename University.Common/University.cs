using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using UniversityApp.Common.Abstractions;

namespace UniversityApp.Common
{
    [Serializable]
    public class University : IUniversity
    {
        public List<Group> GroupList { get; private set; }
        public List<Teacher> TeacherList { get; private set; }
        public List<Subject> SubjectList { get; private set; }

        //file with XML seriliazed objects(university, student ...) - service
        //forms with data about university, students at university etc.  windows forms, data grid view, data source - set 
        public string UniversityName { get; set; }

        public University()
        {
            UniversityName = string.Empty;
            GroupList = new List<Group>();
            TeacherList = new List<Teacher>();
            SubjectList = new List<Subject>();
        }

        public University(string universityName)
        {
            UniversityName = universityName;
            GroupList = new List<Group>();
            TeacherList = new List<Teacher>();
            SubjectList = new List<Subject>();
        }
        
        public bool AddGroup(string name)
        {
            var group = new Group(name, this);
            if(IsNewGroup(group))
            {
                GroupList.Add(group);
                return true;
            }
            return false;
        }

        //abstract factory(didn't read yet :P)
        public bool AddTeacher(string name, string surname, int age)
        {
            var teacher = new Teacher(name, surname, age, this);
            if (IsNewTeacher(teacher))
            {
                TeacherList.Add(teacher);
                return true;
            }
            return false;
        }

        public bool AddSubject(string name)
        {
            var subject = new Subject(name, this);
            if (IsNewSubject(subject))
            {
                SubjectList.Add(subject);
                return true;
            }
            return false;
        }

        public bool SetTeacherToSubject(Teacher teacher, Subject subject) => subject.SetTeacher(teacher);

        public bool AddStudentToGroup(string name, string surname, int age, Group group)
        {
            return group.AddStudent(name, surname, age);
        }

        public bool AddSubjectToRecordBook(int group, int student, int subject) =>
            GroupList[group].AddSubjectToRecordBook(student, SubjectList[subject]);

        public bool AddMarkToRecordBook(int group, int student, int mark, int subject) =>
            GroupList[group].AddMarkToRecordBook(student, mark, SubjectList[subject]);

        public Group GetGroup(int index) => GroupList[index];

        public int GetAmountOfGroups() => GroupList.Count;
        public int GetAmountOfTeachers() => TeacherList.Count;
        public int GetAmountOfSubjects() => SubjectList.Count;
        public int GetAmountOfStudents()
        {
            int summ = 0;
            for(int i = 0; i < GroupList.Count; i++)
            {
                summ += GroupList[i].AmountOfStudents;
            }
            return summ;
        }
        public int GetAmountOfStudentsInGroup(int group) => GroupList[group].AmountOfStudents;


        private bool IsNewTeacher(Teacher newTeacher) => !TeacherList.Any(teacher => teacher.Age == newTeacher.Age &&
                                                                                     teacher.Name == newTeacher.Name &&
                                                                                     teacher.Surname == newTeacher.Surname);
        private bool IsNewGroup(Group newGroup) => !GroupList.Any(group => group.GroupName == newGroup.GroupName);
        private bool IsNewSubject(Subject newSubject) => !SubjectList.Any(subject => subject.Name == newSubject.Name);
    }
}