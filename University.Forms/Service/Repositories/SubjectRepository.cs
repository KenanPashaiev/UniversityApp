using System.Data;
using UniversityApp.Entities;
using UniversityApp.Forms.Service.Abstractions;
using UniversityApp.Forms.Validation;

namespace UniversityApp.Forms.Service.Repositories
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public override void Create(Subject subject)
        {
            if (SubjectValidation.IsValidSubject(subject))
            {
                DataAccessProvider.ExecuteNonQuery($"INSERT INTO Subjects (SubjectName, UniversityID) " +
                                                          $"values (\'{subject.SubjectName}\', " +
                                                                    $"{subject.UniversityId})");
            }
        }

        public override void Delete(int subjectId)
        {
            if (GroupValidation.IsValidGroupId(subjectId))
            {
                DataAccessProvider.ExecuteNonQuery($"DELETE Subjects WHERE SubjectID = {subjectId}");
            }
        }

        public override void Update(Subject subject)
        {
            if (SubjectValidation.IsValidSubject(subject) && 
                SubjectValidation.IsValidSubjectId(subject.SubjectId))
            {
                DataAccessProvider.ExecuteNonQuery($"UPDATE Subjects SET " +
                                                   $"SubjectName = \'{subject.SubjectName}\', " +
                                                   $"UniversityID = {subject.UniversityId} " +
                                                   $"WHERE SubjectID = {subject.SubjectId}");
            }
        }

        public override DataTable FindAll()
        {
            var table = DataAccessProvider.ExecuteQuery("SELECT * FROM Subjects");

            return table;
        }

        public DataTable FindAllFrom(int universityId)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Subjects WHERE UniversityID = {universityId}");

            return table;
        }
    }
}
