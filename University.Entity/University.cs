using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.Entities
{
    public class University
    {
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }

        public University(string universityName)
        {
            UniversityName = universityName;
        }
    }
}
