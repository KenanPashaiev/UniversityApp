using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int TeacherId { get; set; }
        public int UniversityId { get; set; }

        public Subject(string subjectName)
        {
            SubjectName = subjectName;
        }

        public Subject(string subjectName, int universityId) : this(subjectName)
        {
            UniversityId = universityId;
        }

        public Subject(string subjectName, int teacherId, int universityId) : this(subjectName, universityId)
        {
            TeacherId = teacherId;
        }
    }
}
