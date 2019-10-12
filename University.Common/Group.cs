using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Common.Abstractions;

namespace UniversityApp.Common
{
    [Serializable()]
    public class Group
    {
        public List<Student> StudentList { get; private set; }

        public string GroupName { get; set; }

        public University University { get; }

        public int AmountOfStudents { get; set; }

        public Group()
        {
            GroupName = string.Empty;
            University = null;
            StudentList = new List<Student>();
            AmountOfStudents = 0;
        }

        public Group(string groupName, University university)
        {
            GroupName = groupName;
            University = university;
            StudentList = new List<Student>();
            AmountOfStudents = 0;
        }
        
        public bool AddStudent(string name, string surname, int age)
        {
            var student = new Student(name, surname, age, this);
            if (AmountOfStudents < 24 && IsNewStudent(student))
            {
                StudentList.Add(student);
                AmountOfStudents++;
                return true;
            }
            return false;
        }

        public bool AddSubjectToRecordBook(int student, Subject subject) => 
            StudentList[student].AddSubjectToRecordBook(subject);

        public bool AddMarkToRecordBook(int student, int mark, Subject subject) => 
            StudentList[student].AddMarkToRecordBook(mark, subject);

        /*public DataTable GetFormattedStudents()
        {
            var table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Surname", typeof(string));
            table.Columns.Add("Age", typeof(int));
            for (int i = 0; i < _studentList.Count; i++)
            {
                table.Rows.Add(_studentList[i].Name,
                               _studentList[i].Surname,
                               _studentList[i].Age);
            }
            return table;
        }*/

        public Student GetGroup(int index) => StudentList[index];

        private bool IsNewStudent(Student student) => !StudentList.Any(stud => stud.Age == student.Age &&
                                                                               stud.Name == student.Name &&
                                                                               stud.Surname == student.Surname);
    }
}
