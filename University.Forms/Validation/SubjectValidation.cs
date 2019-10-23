using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Entities;
using UniversityApp.Forms.Service;

namespace UniversityApp.Forms.Validation
{
    public class SubjectValidation
    {
        private static readonly DataAccessProvider DataAccessProvider;

        static SubjectValidation()
        {
            DataAccessProvider = new DataAccessProvider();
        }

        public static bool IsValidSubject(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            if (string.IsNullOrEmpty(subject.SubjectName))
            {
                throw new ArgumentException($"Invalid subject name \'{subject.SubjectName}\'");
            }

            if (subject.UniversityId <= 0)
            {
                throw new ArgumentException($"Invalid university id \'{subject.UniversityId}\'");
            }

            return true;
        }

        public static bool IsValidSubjectId(int subjectId)
        {
            if (subjectId <= 0)
            {
                throw new ArgumentException($"Invalid subject id \'{subjectId}\'");
            }

            return true;
        }

        public static bool IsPresent(Subject subject)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Subjects WHERE " +
                                                        $"SubjectName = {subject.SubjectName}");
            return table.Rows.Count <= 0;
        }
    }
}
