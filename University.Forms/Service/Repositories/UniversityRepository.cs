using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Entities;
using UniversityApp.Forms.Service.Abstractions;

namespace UniversityApp.Forms.Service
{
    public class UniversityRepository : RepositoryBase<University>, IUniversityRepository
    {
        private readonly DataAccessProvider _dataAccessProvider;

        public UniversityRepository()
        {
            _dataAccessProvider = new DataAccessProvider();
        }

        public override void Create(University university)
        {
            var universityName = university.UniversityName;

            if (universityName == string.Empty)
            {
                throw new ArgumentNullException($"University name is empty");
            }

            _dataAccessProvider.ExecuteNonQuery($"INSERT INTO Universities (UniversityName) values (\'{universityName}\')");
        }

        public override void Delete(int universityId)
        {
            if (universityId == 0)
            {
                throw new ArgumentNullException($"University ID is zero");
            }

            _dataAccessProvider.ExecuteNonQuery($"DELETE Universities WHERE UniversityID = {universityId}");
        }

        public override void Update(University university)
        {
            var universityId = university.UniversityId;
            var universityName = university.UniversityName;

            if (universityId == 0)
            {
                throw new ArgumentNullException($"University ID is zero");
            }

            if (universityName == string.Empty)
            {
                throw  new ArgumentNullException($"University name is empty");
            }

            _dataAccessProvider.ExecuteNonQuery($"UPDATE Universities SET UniversityName = \'{universityName}\' WHERE UniversityID = {universityId}");
        }

        public override DataTable FindAll()
        {
            var table = _dataAccessProvider.ExecuteQuery("SELECT * FROM Universities");

            return table;
        }
    }
}
