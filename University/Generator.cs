using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class Generator
    {
        private readonly IUniversity _university;

        public Generator(IUniversity university)
        {
            _university = university;
        }

        public void GenerateGroups(int amount)
        {
            for (int i = 1; i < amount + 1; i++)
            {
                _university.AddGroup($"KIUKI 18 {i}");
            }
        }

        public void GenerateStudents(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _university.AddStudentToGroup(RandomInfo.GetRandomNumber(0, _university.GetAmountOfGroups()),
                    RandomInfo.GetRandomName(), RandomInfo.GetRandomName(), RandomInfo.GetRandomAge(18, 31));
            }
        }

        public void GenerateSubjectsAndTeachers(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _university.AddSubject(RandomInfo.GetRandomSubject());
                _university.AddTeacher(RandomInfo.GetRandomName(), 
                    RandomInfo.GetRandomName(), RandomInfo.GetRandomAge(24, 80));
                _university.SetTeacherToSubject(RandomInfo.GetRandomNumber(0, _university.GetAmountOfTeachers()),
                    RandomInfo.GetRandomNumber(0, _university.GetAmountOfSubjects()));
            }
        }

        public void GenerateMarksToStudents()
        {
            for (int i = 0; i < _university.GetAmountOfGroups(); i++)
            {
                for (int j = 0; j < _university.GetAmountOfStudentsInGroup(i); j++)
                {
                    for (int k = 0; k < _university.GetAmountOfSubjects(); k++)
                    {
                        _university.AddSubjectToRecordBook(i, j, k);
                        _university.AddMarkToRecordBook(i, j, RandomInfo.GetRandomMark(), k);
                    }
                }
            }
        }
    }
}
