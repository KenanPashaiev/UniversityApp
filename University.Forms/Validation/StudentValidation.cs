using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Entities;
using UniversityApp.Forms.Service;

namespace UniversityApp.Forms.Validation
{
    public class StudentValidation
    {
        protected readonly DataAccessProvider DataAccessProvider;

        public StudentValidation()
        {
            DataAccessProvider = new DataAccessProvider(); ;
        }

        public bool IsValidStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (student.StudentName == string.Empty)
            {
                throw new ArgumentException($"Invalid student name \'{student.StudentName}\'");
            }

            if (student.StudentSurname == string.Empty)
            {
                throw new ArgumentException($"Invalid student surname \'{student.StudentSurname}\'");
            }

            if (student.StudentAge <= 16 || student.StudentAge >= 30)
            {
                throw new ArgumentException($"Invalid student age \'{student.StudentAge}\'");
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
