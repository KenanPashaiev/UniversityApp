using System;
using UniversityApp.Entities;
using UniversityApp.Forms.Service;
using UniversityApp.Forms.Service.Abstractions;

namespace UniversityApp.Forms.Validation
{
    public class RecordValidation
    {
        private static readonly IDataAccessProvider DataAccessProvider;

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

        public static bool IsValidRecordId(int recordId)
        {
            if (recordId <= 0)
            {
                throw new ArgumentException($"Invalid record id \'{recordId}\'");
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
