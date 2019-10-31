using System;
using System.Data;
using UniversityApp.Entities;
using UniversityApp.Forms.Service.Abstractions;
using UniversityApp.Forms.Validation;

namespace UniversityApp.Forms.Service.Repositories
{
    public class RecordRepository : RepositoryBase<Record>, IRecordRepository
    {
        public override void Create(Record record)
        {
            if (RecordValidation.IsValidRecord(record))
            {
                DataAccessProvider.ExecuteNonQuery($"INSERT INTO Records (Mark, StudentID, SubjectID) " +
                                                    $"values ({record.Mark}, " +
                                                            $"{record.StudentId}, " +
                                                            $"{record.SubjectId})");
            }
        }

        public override void Delete(int recordId)
        {
            if (RecordValidation.IsValidRecordId(recordId))
            {
               DataAccessProvider.ExecuteNonQuery($"DELETE Records WHERE RecordID = {recordId}");
            }

        }

        public override void Update(Record record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));
        }

        public override DataTable FindAll()
        {
            var table = DataAccessProvider.ExecuteQuery("SELECT * FROM Records");

            return table;
        }

        public DataTable FindAllFrom(int studentId)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Records WHERE StudentID = {studentId}");

            return table;
        }
    }
}
