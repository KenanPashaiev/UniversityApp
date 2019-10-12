using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.Entities
{
    public class Record
    {
        public int RecordId { get; set; }
        public int Mark { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public Record(int mark)
        {
            Mark = mark;
        }

        public Record(int mark, int studentId) : this(mark)
        {
            StudentId = studentId;
        }

        public Record(int mark, int studentId, int subjectId) : this(mark, studentId)
        {
            SubjectId = subjectId;
        }
    }
}
