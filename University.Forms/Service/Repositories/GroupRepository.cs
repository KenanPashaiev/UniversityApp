using System.Data;
using UniversityApp.Entities;
using UniversityApp.Forms.Service.Abstractions;
using UniversityApp.Forms.Validation;

namespace UniversityApp.Forms.Service.Repositories
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public override void Create(Group group)
        {
            if (GroupValidation.IsValidGroup(group))
            {
                DataAccessProvider.ExecuteNonQuery($"INSERT INTO Groups (GroupName, UniversityID) " +
                                                          $"values (\'{group.GroupName}\'," +
                                                                    $"{group.UniversityId})");
            }
        }

        public override void Delete(int groupId)
        {
            if (GroupValidation.IsValidGroupId(groupId))
            {
                DataAccessProvider.ExecuteNonQuery($"DELETE Groups WHERE GroupID = {groupId}");
            }
        }

        public override void Update(Group group)
        {
            if (GroupValidation.IsValidGroup(group) && GroupValidation.IsValidGroupId(group.GroupId))
            {
                DataAccessProvider.ExecuteNonQuery($"UPDATE Groups SET " +
                                                    $"GroupName = \'{group.GroupName}\', " +
                                                    $"UniversityID = {group.UniversityId} " +
                                                    $"WHERE GroupID = {group.GroupId}");
            }
        }

        public override DataTable FindAll()
        {
            var table = DataAccessProvider.ExecuteQuery("SELECT * FROM Groups");

            return table;
        }

        public DataTable FindAllFrom(int universityId)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Groups " +
                                                               $"WHERE UniversityID = {universityId}");

            return table;
        }
    }
}
