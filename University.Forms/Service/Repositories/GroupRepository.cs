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
        private readonly DataAccessProvider _dataAccessProvider;

        public GroupRepository()
        {
            _dataAccessProvider = new DataAccessProvider();
        }

        public override void Create(Group group)
        {
            var groupName = group.GroupName;
            var universityId = group.UniversityId;

            if (groupName == string.Empty)
            {
                throw new ArgumentNullException($"Group name is empty");
            }

            if (universityId == 0)
            {
                throw new ArgumentNullException($"University ID is zero");
            }

            _dataAccessProvider.ExecuteNonQuery($"INSERT INTO Groups (GroupName) values (\'{groupName}\')");
        }

        public override void Delete(int groupId)
        {
            if (groupId == 0)
            {
                throw new ArgumentNullException($"Group ID is zero");
            }

            _dataAccessProvider.ExecuteNonQuery($"DELETE Groups WHERE GroupID = {groupId}");
        }

        public override void Update(Group group)
        {
            var groupId = group.GroupId;
            var groupName = group.GroupName;
            var universityId = group.UniversityId;

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

            _dataAccessProvider.ExecuteNonQuery($"UPDATE Groups SET GroupName = \'{groupName}\', UniversityID = {universityId} WHERE GroupID = {groupId}");
        }

        public override DataTable FindAll()
        {
            var table = _dataAccessProvider.ExecuteQuery("SELECT * FROM Groups");

            return table;
        }

        public DataTable FindAllFrom(int universityId)
        {
            var table = _dataAccessProvider.ExecuteQuery($"SELECT * FROM Groups WHERE UniversityID = {universityId}");

            return table;
        }
    }
}
