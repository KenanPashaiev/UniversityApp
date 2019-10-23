using System;
using UniversityApp.Entities;
using UniversityApp.Forms.Service;
using UniversityApp.Forms.Service.Abstractions;

namespace UniversityApp.Forms.Validation
{
    public class TeacherValidation
    {
        private static readonly IDataAccessProvider DataAccessProvider;

        static TeacherValidation()
        {
            DataAccessProvider = new DataAccessProvider();
        }

        public static bool IsValidTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            if (string.IsNullOrEmpty(teacher.TeacherName))
            {
                throw new ArgumentException($"Invalid teacher name \'{teacher.TeacherName}\'");
            }

            if (string.IsNullOrEmpty(teacher.TeacherSurname))
            {
                throw new ArgumentException($"Invalid teacher surname \'{teacher.TeacherSurname}\'");
            }

            if (teacher.TeacherAge <= 24 || teacher.TeacherAge >= 90)
            {
                throw new ArgumentException($"Invalid teacher age \'{teacher.TeacherAge}\'");
            }

            return true;
        }

        public static bool IsValidTeacherId(int teacherId)
        {
            if (teacherId <= 0)
            {
                throw new ArgumentException($"Invalid teacher id \'{teacherId}\'");
            }

            return true;
        }

        public static bool IsPresent(Teacher teacher)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Teachers WHERE " +
                                                        $"TeacherName = \'{teacher.TeacherName}\'" +
                                                        $"TeacherSurname = \'{teacher.TeacherSurname}\'" +
                                                        $"TeacherAge = {teacher.TeacherAge}");
            return table.Rows.Count <= 0;
        }
    }
}
