using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int UniversityId { get; set; }

        public Group(string groupName)
        {
            GroupName = groupName;
        }

        public Group(string groupName, int universityId) : this(groupName)
        {
            UniversityId = universityId;
        }
    }
}
