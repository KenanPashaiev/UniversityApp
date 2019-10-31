using System.Data;
using UniversityApp.Entities;
using UniversityApp.Forms.Service.Abstractions;
using UniversityApp.Forms.Validation;

namespace UniversityApp.Forms.Service.Repositories
{
    public class UniversityRepository : RepositoryBase<University>, IUniversityRepository
    {
        public override void Create(University university)
        {
            if (UniversityValidation.IsValidUniversity(university))
            {
                DataAccessProvider.ExecuteNonQuery($"INSERT INTO Universities (UniversityName) " +
                                                          $"values (\'{university.UniversityName}\')");
            }
        }

        public override void Delete(int universityId)
        {
            if (UniversityValidation.IsValidUniversityId(universityId))
            {
                DataAccessProvider.ExecuteNonQuery($"DELETE Universities " +
                                                          $"WHERE UniversityID = {universityId}");
            }
        }

        public override void Update(University university)
        {
            if (UniversityValidation.IsValidUniversity(university) && 
                UniversityValidation.IsValidUniversityId(university.UniversityId))
            {
                DataAccessProvider.ExecuteNonQuery($"UPDATE Universities " +
                                                          $"SET UniversityName = \'{university.UniversityName}\' " +
                                                          $"WHERE UniversityID = {university.UniversityId}");
            }
        }

        public override DataTable FindAll()
        {
            var table = DataAccessProvider.ExecuteQuery("SELECT * FROM Universities");

            return table;
        }
    }
}
