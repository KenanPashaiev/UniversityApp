using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    interface IUniversity
    {
        bool AddGroup(string name);

        bool AddTeacher(string name, string surname, int age);
        bool AddSubject(string name);
        bool SetTeacherToSubject(int teacher, int subject);
        bool AddStudentToGroup(int group, string name, string surname, int age);
        bool AddSubjectToRecordBook(int group, int student, int subject);
        bool AddMarkToRecordBook(int group, int student, int mark, int subject);

        string GetFormattedGroups();
        string GetFormattedTeachers();
        string GetFormattedSubjects();
        string GetFormattedStudents();
        string GetFormattedRecordBook(int group, int student);
        string GetFormattedInfo();

        int GetAmountOfGroups();
        int GetAmountOfTeachers();
        int GetAmountOfSubjects();
        int GetAmountOfStudents();
        int GetAmountOfStudentsInGroup(int group);
    }
}
