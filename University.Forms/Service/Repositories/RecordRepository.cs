using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Entities;
using UniversityApp.Forms.Service.Abstractions;

namespace UniversityApp.Forms.Service.Repositories
{
    class RecordRepository : RepositoryBase<Record>, IRecordRepository
    {
        private readonly DataAccessProvider _dataAccessProvider;

        public RecordRepository()
        {
            _dataAccessProvider = new DataAccessProvider();
        }

        public override void Create(Record record)
        {
            var mark = record.Mark;
            var studentId = record.StudentId;
            var subjectId = record.SubjectId;

            if (mark < 0 || mark > 100)
            {
                throw new ArgumentException($"Mark can't be lower then 0 and higher than 100'");
            }

            if (studentId == 0)
            {
                throw new ArgumentException($"Student ID is zero");
            }

            if (subjectId == 0)
            {
                throw new ArgumentException($"Subject ID is zero");
            }

            _dataAccessProvider.ExecuteNonQuery($"INSERT INTO Records (Mark, StudentID, SubjectID) " +
                                        $"values ({mark}, {studentId}, {subjectId})");
        }

        public override void Delete(int recordId)
        {
            if (recordId == 0)
            {
                throw new ArgumentException($"Record ID is zero");
            }

            _dataAccessProvider.ExecuteNonQuery($"DELETE Records WHERE RecordID = {recordId}");
        }

        public override void Update(Record record)
        {
            var recordId = record.StudentId;
            var mark = record.Mark;
            var studentId = record.StudentId;
            var subjectId = record.SubjectId;

            if (recordId == 0)
            {
                throw new ArgumentException($"Record ID is zero");
            }

            if (mark < 0 || mark > 100)
            {
                throw new ArgumentException($"Mark can't be lower then 0 and higher than 100'");
            }

            if (studentId == 0)
            {
                throw new ArgumentException($"Student ID is zero");
            }

            if (subjectId == 0)
            {
                throw new ArgumentException($"Subject ID is zero");
            }

            _dataAccessProvider.ExecuteNonQuery($"UPDATE Records SET Mark = {mark}, StudentID = {studentId}, SubjectID = {subjectId} WHERE RecordID = {recordId}");
        }

        public override DataTable FindAll()
        {
            var table = _dataAccessProvider.ExecuteQuery("SELECT * FROM Records");

            return table;
        }

        public DataTable FindAllFrom(int studentId)
        {
            var table = _dataAccessProvider.ExecuteQuery($"SELECT * FROM Records WHERE StudentID = {studentId}");

            return table;
        }
    }
}
