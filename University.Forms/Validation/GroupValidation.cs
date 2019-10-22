using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Entities;
using UniversityApp.Forms.Service;
using UniversityApp.Forms.Service.Abstractions;

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

            if (group.GroupName == string.Empty)
            {
                throw new ArgumentException($"Invalid group name \'{group.GroupName}\'");
            }

            return true;
        }

        public static bool IsPresent(Group group)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Group WHERE GroupName = {group.GroupName}");
            return table.Rows.Count <= 0;
        }
    }
}
