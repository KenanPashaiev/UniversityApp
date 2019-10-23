using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Entities;
using UniversityApp.Forms.Service.Abstractions;
using UniversityApp.Forms.Service.Validation;

namespace UniversityApp.Forms.Service
{
    public class UniversityRepository : RepositoryBase<University>, IUniversityRepository
    {
        public override void Create(University university)
        {
            if (UniversityValidation.IsValidUniversity(university))
            {
                DataAccessProvider.ExecuteNonQuery($"INSERT INTO Universities (UniversityName) values (\'{universityName}\')");
            }
        }

        public override void Delete(int universityId)
        {
            if (universityId == 0)
            {
                throw new ArgumentNullException($"University ID is zero");
            }

            DataAccessProvider.ExecuteNonQuery($"DELETE Universities WHERE UniversityID = {universityId}");
        }

        public override void Update(University university)
        {
            var universityId = university.UniversityId;
            var universityName = university.UniversityName;

            if (universityId == 0)
            {
                throw new ArgumentNullException($"University ID is zero");
            }

            if (UniversityValidation.IsValidUniversity(university))
            {
                DataAccessProvider.ExecuteNonQuery($"UPDATE Universities SET UniversityName = \'{universityName}\' WHERE UniversityID = {universityId}");
            }
        }

        public override DataTable FindAll()
        {
            var table = DataAccessProvider.ExecuteQuery("SELECT * FROM Universities");

            return table;
        }
    }
}
