using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using UniversityApp.Common.Abstractions;

namespace UniversityApp.Common
{
    [Serializable()]
    public class RecordBook : IRecordBook
    {
        public List<MarkedSubject> MarkedSubjectList { get; set; }

        public RecordBook()
        {
            MarkedSubjectList = new List<MarkedSubject>();
        }
        
        public bool AddSubject(Subject subject)
        {
            if (!MarkedSubjectList.Any(markedSubject => markedSubject.Subject.SubjectGuid == subject.SubjectGuid))
            {
                MarkedSubjectList.Add(new MarkedSubject(0, subject));
                return true;
            }

            return false;
        }

        public bool AddMark(int mark, Subject subject)
        {//MarkedSubjectList.Any(markedSubject => markedSubject.Subject.SubjectGuid == subject.SubjectGuid)
            if (MarkedSubjectList.Any(markedSubject => markedSubject.Subject.Name == subject.Name))
            {
                var editedSubject = MarkedSubjectList.First(markedSubject => markedSubject.Subject.Name == subject.Name);
                editedSubject.Mark = mark;
                return true;
            }

            MarkedSubjectList.Add(new MarkedSubject(mark, subject));
            return true;
        }

        public MarkedSubject GetMaximalMarkedSubjectOfStudent()
        {
            if (MarkedSubjectList.Count > 0)
            {
                var maximalMark = MarkedSubjectList.Max(subject => subject.Mark);
                var result = MarkedSubjectList.FirstOrDefault(subject => subject.Mark == maximalMark);
                return result;
            }

            return default;
        }

        public MarkedSubject GetMinimalMarkedSubjectOfStudent()
        {
            if (MarkedSubjectList.Count > 0)
            {
                var minimalMark = MarkedSubjectList.Min(subject => subject.Mark);
                var result = MarkedSubjectList.FirstOrDefault(subject => subject.Mark == minimalMark);
                return result;
            }

            return default;
        }
    }
}
