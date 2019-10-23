using System.Data;
using UniversityApp.Entities;
using UniversityApp.Forms.Service.Abstractions;
using UniversityApp.Forms.Validation;

namespace UniversityApp.Forms.Service.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public override void Create(Student student)
        {
            if (StudentValidation.IsValidStudent(student))
            {
                DataAccessProvider.ExecuteNonQuery($"INSERT INTO Students " + 
                                                    $"(StudentName, StudentSurname, StudentAge, GroupID) " +
                                                    $"values (\'{student.StudentName}\'," +
                                                            $"\'{student.StudentSurname}\'," +
                                                            $"  {student.StudentAge}, " +
                                                            $"  {student.GroupId})");
            }
        }

        public override void Delete(int studentId)
        {
            if (StudentValidation.IsValidStudentId(studentId))
            {
               DataAccessProvider.ExecuteNonQuery($"DELETE Students " +
                                                          $"WHERE StudentID = {studentId}");
            }
        }

        public override void Update(Student student)
        {
            if (StudentValidation.IsValidStudent(student) && 
                StudentValidation.IsValidStudentId(student.StudentId))
            {
               DataAccessProvider.ExecuteNonQuery($"UPDATE Students " +
                                                   $"SET StudentName = \'{student.StudentName}\'," +
                                                      $" StudentSurname = \'{student.StudentSurname}\', " +
                                                      $" StudentAge = {student.StudentAge}, " +
                                                      $" GroupID = {student.GroupId} " +
                                                   $"WHERE StudentID = {student.StudentId}");
            }
        }

        public override DataTable FindAll()
        {
            var table = DataAccessProvider.ExecuteQuery("SELECT * FROM Students");

            return table;
        }

        public DataTable FindAllFrom(int groupId)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Students " +
                                                               $"WHERE GroupID = {groupId}");

            return table;
        }
    }
}
