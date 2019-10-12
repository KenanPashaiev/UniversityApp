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
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        private readonly DataAccess _dataAccess;

        public GroupRepository()
        {
            _dataAccess = new DataAccess();
        }

        public override void Create(Group entity)
        {
            var groupName = entity.GroupName;
            var universityId = entity.UniversityId;

            if (groupName == string.Empty)
            {
                throw new ArgumentNullException($"Group name is empty");
            }

            if (universityId == 0)
            {
                throw new ArgumentNullException($"University ID is zero");
            }

            _dataAccess.ExecuteNonQuery($"INSERT INTO Groups (GroupName) values (\'{groupName}\')");
        }

        public override void Delete(int groupId)
        {
            if (groupId == 0)
            {
                throw new ArgumentNullException($"Group ID is zero");
            }

            _dataAccess.ExecuteNonQuery($"DELETE Groups WHERE GroupID = {groupId}");
        }

        public override void Update(Group entity)
        {
            var groupId = entity.GroupId;
            var groupName = entity.GroupName;
            var universityId = entity.UniversityId;

            if (groupId == 0)
            {
                throw new ArgumentNullException($"Group ID is zero");
            }

            if (groupName == string.Empty)
            {
                throw new ArgumentNullException($"Group name is empty");
            }

            if (universityId == 0)
            {
                throw new ArgumentNullException($"University ID is zero");
            }

            _dataAccess.ExecuteNonQuery($"UPDATE Groups SET GroupName = {groupName}, UniversityID = {universityId} WHERE UniversityID = {groupId}");
        }

        public override DataTable FindAll()
        {
            var table = _dataAccess.ExecuteQuery("SELECT * FROM Groups");

            return table;
        }

        public DataTable FindAllFrom(int universityId)
        {
            var table = _dataAccess.ExecuteQuery($"SELECT * FROM Groups WHERE UniversityID = {universityId}");

            return table;
        }
    }
}
