using System;
using UniversityApp.Entities;
using UniversityApp.Forms.Service;
using UniversityApp.Forms.Service.Abstractions;

namespace UniversityApp.Forms.Validation
{
    public class StudentValidation
    {
        private static readonly IDataAccessProvider DataAccessProvider;

        static StudentValidation()
        {
            DataAccessProvider = new DataAccessProvider();
        }

        public static bool IsValidStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (string.IsNullOrEmpty(student.StudentName))
            {
                throw new ArgumentException($"Invalid student name \'{student.StudentName}\'");
            }

            if (string.IsNullOrEmpty(student.StudentSurname))
            {
                throw new ArgumentException($"Invalid student surname \'{student.StudentSurname}\'");
            }

            if (student.StudentAge <= 16 || student.StudentAge >= 30)
            {
                throw new ArgumentException($"Invalid student age \'{student.StudentAge}\'");
            }

            return true;
        }

        public static bool IsValidStudentId(int studentId)
        {
            if (studentId <= 0)
            {
                throw new ArgumentException($"Invalid student id \'{studentId}\'");
            }

            return true;
        }

        public bool IsPresent(Student student)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Students WHERE " +
                                                        $"StudentName = \'{student.StudentName}\'" +
                                                        $"StudentSurname = \'{student.StudentSurname}\'" +
                                                        $"StudentAge = {student.StudentAge}");
            return table.Rows.Count <= 0;
        }
    }
}
