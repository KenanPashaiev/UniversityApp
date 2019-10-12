using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace University
{
    class RecordBook : IRecordBook
    {
        private IList<MarkedSubject> _markedSubjectList;
        private readonly ITableFormatter _tableFormatter;

        public RecordBook(ITableFormatter tableFormatter)
        {
            _markedSubjectList = new List<MarkedSubject>();
            _tableFormatter = tableFormatter;
        }
        
        public bool AddSubject(Subject subject)
        {
            if (!_markedSubjectList.Any(markedSubject => markedSubject.Subject.SubjectGuid == subject.SubjectGuid))
            {
                _markedSubjectList.Add(new MarkedSubject(0, subject));
                return true;
            }

            return false;
        }

        public bool AddMark(int mark, Subject subject)
        {
            if (_markedSubjectList.Any(markedSubject => markedSubject.Subject.SubjectGuid == subject.SubjectGuid))
            {
                _markedSubjectList.First(markedSubject => markedSubject.Subject.Name == subject.Name).Mark = mark;
                return true;
            }

            return false;
        }

        public MarkedSubject GetMaximalMarkedSubjectOfStudent()
        {
            if (_markedSubjectList.Count > 0)
            {
                var maximalMark = _markedSubjectList.Max(subject => subject.Mark);
                var result = _markedSubjectList.FirstOrDefault(subject => subject.Mark == maximalMark);
                return result;
            }

            return default;
        }

        public MarkedSubject GetMinimalMarkedSubjectOfStudent()
        {
            if (_markedSubjectList.Count > 0)
            {
                var minimalMark = _markedSubjectList.Min(subject => subject.Mark);
                var result = _markedSubjectList.FirstOrDefault(subject => subject.Mark == minimalMark);
                return result;
            }

            return default;
        }

        public string GetFormattedRecordBook()
        {
            if(_markedSubjectList.Count == 0)
            {
                return "There are no subjects in this record book";
            }

            var result = new StringBuilder();
            result.Append(_tableFormatter.FormatRow("Subject", "Mark"));

            for (int i = 0; i < _markedSubjectList.Count; i++)
            {
                result.Append(_tableFormatter.FormatRow(_markedSubjectList[i].Subject.Name,
                                                    _markedSubjectList[i].Mark.ToString()));
            }
            return result.ToString();
        }
    }
}
