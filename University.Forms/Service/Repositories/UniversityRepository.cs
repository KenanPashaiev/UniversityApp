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
        private readonly DataAccess _dataAccess;

        public UniversityRepository()
        {
            _dataAccess = new DataAccess();
        }

        public override void Create(University entity)
        {
            var universityName = entity.UniversityName;

            if (universityName == string.Empty)
            {
                throw new ArgumentNullException($"University name is empty");
            }

            _dataAccess.ExecuteNonQuery($"INSERT INTO Universities (UniversityName) values (\'{universityName}\')");
        }

        public override void Delete(int universityId)
        {
            if (universityId == 0)
            {
                throw new ArgumentNullException($"University ID is zero");
            }

            _dataAccess.ExecuteNonQuery($"DELETE Universities WHERE UniversityID = {universityId}");
        }

        public override void Update(University entity)
        {
            var universityId = entity.UniversityId;
            var universityName = entity.UniversityName;

            if (universityId == 0)
            {
                throw new ArgumentNullException($"University ID is zero");
            }

            if (universityName == string.Empty)
            {
                throw  new ArgumentNullException($"University name is empty");
            }

            _dataAccess.ExecuteNonQuery($"UPDATE Universities SET UniversityName = {universityName} WHERE UniversityID = {universityId}");
        }

        public override DataTable FindAll()
        {
            var table = _dataAccess.ExecuteQuery("SELECT * FROM Universities");

            return table;
        }
    }
}
