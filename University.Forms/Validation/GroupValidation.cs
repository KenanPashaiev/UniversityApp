using System;
using UniversityApp.Entities;
using UniversityApp.Forms.Service;

namespace UniversityApp.Forms.Validation
{
    public class GroupValidation
    {
        private static readonly DataAccessProvider DataAccessProvider;

        static GroupValidation()
        {
            DataAccessProvider = new DataAccessProvider(); ;
        }

        public static bool IsValidGroup(Group group)
        {
            if (group == null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(group.GroupName))
            {
                throw new ArgumentException($"Invalid group name \'{group.GroupName}\'");
            }

            return true;
        }

        public static bool IsValidGroupId(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException($"Invalid group Id \'{groupId}\'");
            }

            return true;
        }

        public static bool IsPresent(Group group)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Group WHERE " +
                                                        $"GroupName = {group.GroupName}");
            return table.Rows.Count <= 0;
        }
    }
}
