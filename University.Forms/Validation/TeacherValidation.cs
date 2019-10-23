using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Entities;
using UniversityApp.Forms.Service;

namespace UniversityApp.Forms.Validation
{
    public class TeacherValidation
    {
        private static readonly DataAccessProvider DataAccessProvider;

        static TeacherValidation()
        {
            DataAccessProvider = new DataAccessProvider();
        }

        public bool IsValidTeacher(Teacher teacher)
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

        public bool IsPresent(Teacher teacher)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Teachers WHERE " +
                                                        $"TeacherName = \'{teacher.TeacherName}\'" +
                                                        $"TeacherSurname = \'{teacher.TeacherSurname}\'" +
                                                        $"TeacherAge = {teacher.TeacherAge}");
            return table.Rows.Count <= 0;
        }
    }
}
