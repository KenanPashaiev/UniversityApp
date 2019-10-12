using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.Common.Abstractions
{
    public interface IUniversity
    {
        bool AddGroup(string name);

        bool AddTeacher(string name, string surname, int age);
        bool AddSubject(string name);
        bool SetTeacherToSubject(Teacher teacher, Subject subject);
        bool AddStudentToGroup(string name, string surname, int age, Group group);
        bool AddSubjectToRecordBook(int group, int student, int subject);
        bool AddMarkToRecordBook(int group, int student, int mark, int subject);

        /*string GetFormattedGroups();
        string GetFormattedTeachers();
        string GetFormattedSubjects();
        string GetFormattedStudents();
        string GetFormattedRecordBook(int group, int student);
        string GetFormattedInfo();*/

        int GetAmountOfGroups();
        int GetAmountOfTeachers();
        int GetAmountOfSubjects();
        int GetAmountOfStudents();
        int GetAmountOfStudentsInGroup(int group);
    }
}
