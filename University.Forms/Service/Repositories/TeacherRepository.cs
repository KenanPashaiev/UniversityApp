using System;
using System.Data;
using UniversityApp.Entities;
using UniversityApp.Forms.Service.Abstractions;
using UniversityApp.Forms.Validation;

namespace UniversityApp.Forms.Service.Repositories
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public override void Create(Teacher teacher)
        {
            if (TeacherValidation.IsValidTeacher(teacher))
            {
                DataAccessProvider.ExecuteNonQuery($"INSERT INTO Teachers " +
                                                   $"(TeacherName, TeacherSurname, TeacherAge) " +
                                                   $"values (\'{teacher.TeacherName}\'," +
                                                           $"\'{teacher.TeacherSurname}\'," +
                                                           $"  {teacher.TeacherAge})");
            }
        }

        public override void Delete(int teacherId)
        {
            if (TeacherValidation.IsValidTeacherId(teacherId))
            {
                DataAccessProvider.ExecuteNonQuery($"DELETE Teachers " +
                                                   $"WHERE TeacherID = {teacherId}");
            }
        }

        public override void Update(Teacher teacher)
        {
            if (TeacherValidation.IsValidTeacher(teacher) &&
                TeacherValidation.IsValidTeacherId(teacher.TeacherId))
            {
                DataAccessProvider.ExecuteNonQuery($"UPDATE Teachers " +
                                                   $"SET TeacherName = \'{teacher.TeacherName}\'," +
                                                   $" TeacherSurname = \'{teacher.TeacherName}\', " +
                                                   $" TeacherAge = {teacher.TeacherAge} " +
                                                   $"WHERE TeacherID = {teacher.TeacherId}");
            }
        }

        public override DataTable FindAll()
        {
            var table = DataAccessProvider.ExecuteQuery("SELECT * FROM Teachers");

            return table;
        }

        public DataTable FindAllFrom(int universityId)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Teachers " +
                                                               $"WHERE UniversityID = {universityId}");

            return table;
        }
    }
}
