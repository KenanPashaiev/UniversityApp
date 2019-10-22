using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Entities;
using UniversityApp.Forms.Service;

namespace UniversityApp.Forms.Validation
{
    public class RecordValidation
    {
        private static readonly DataAccessProvider DataAccessProvider;

        static RecordValidation()
        {
            DataAccessProvider = new DataAccessProvider();
        }

        public static bool IsValidRecord(Record record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            if (record.Mark < 0 || record.Mark > 100)
            {
                throw new ArgumentException($"Invalid mark \'{record.Mark}\'");
            }

            if (record.StudentId <= 0)
            {
                throw new ArgumentException($"Invalid student id \'{record.StudentId}\'");
            }

            if (record.SubjectId <= 0)
            {
                throw new ArgumentException($"Invalid subject id \'{record.SubjectId}\'");
            }

            return true;
        }

        public static bool IsPresent(Record record)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Records WHERE " +
                                                        $"StudentId = {record.StudentId}, " +
                                                        $"SubjectId = {record.SubjectId}");
            return table.Rows.Count > 0;
        }
    }
}
