using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Entities;
using UniversityApp.Forms.Service.Abstractions;

namespace UniversityApp.Forms.Service.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        private readonly DataAccessProvider _dataAccessProvider;

        public StudentRepository()
        {
            _dataAccessProvider = new DataAccessProvider();
        }

        public override void Create(Student record)
        {
            var studentName = record.StudentName;
            var studentSurname = record.StudentSurname;
            var studentAge = record.StudentAge;
            var groupId = record.GroupId;

            if (studentName == string.Empty)
            {
                throw new ArgumentException($"Student name is empty");
            }

            if (studentSurname == string.Empty)
            {
                throw new ArgumentException($"Student surname is empty");
            }

            if (studentAge < 16 || studentAge > 30)
            {
                throw new ArgumentException($"Student age can't be lower than 16 and higher than 30");
            }

            if (groupId == 0)
            {
                throw new ArgumentException($"Group ID is zero");
            }

            _dataAccessProvider.ExecuteNonQuery($"INSERT INTO Students (StudentName, StudentSurname, StudentAge, GroupID) " +
                                        $"values (\'{studentName}\', \'{studentSurname}\', {studentAge}, {groupId})");
        }

        public override void Delete(int studentId)
        {
            if (studentId == 0)
            {
                throw new ArgumentException($"Student ID is zero");
            }

            _dataAccessProvider.ExecuteNonQuery($"DELETE Students WHERE StudentID = {studentId}");
        }

        public override void Update(Student student)
        {
            var studentId = student.StudentId;
            var studentName = student.StudentName;
            var studentSurname = student.StudentSurname;
            var studentAge = student.StudentAge;
            var groupId = student.GroupId;

            if (studentId == 0)
            {
                throw new ArgumentException($"Student ID is zero");
            }

            if (studentName == string.Empty)
            {
                throw new ArgumentException($"Student name is empty");
            }

            if (studentSurname == string.Empty)
            {
                throw new ArgumentException($"Student surname is empty");
            }

            if (studentAge < 16 || studentAge > 30)
            {
                throw new ArgumentException($"Student age can't be lower than 16 and higher than 30");
            }

            if (groupId == 0)
            {
                throw new ArgumentException($"Group ID is zero");
            }

            _dataAccessProvider.ExecuteNonQuery($"UPDATE Students SET StudentName = \'{studentName}\', StudentSurname = \'{studentSurname}\', StudentAge = {studentAge}, GroupID = {groupId} WHERE StudentID = {studentId}");
        }

        public override DataTable FindAll()
        {
            var table = _dataAccessProvider.ExecuteQuery("SELECT * FROM Students");

            return table;
        }

        public DataTable FindAllFrom(int groupId)
        {
            var table = _dataAccessProvider.ExecuteQuery($"SELECT * FROM Students WHERE GroupID = {groupId}");

            return table;
        }
    }
}
