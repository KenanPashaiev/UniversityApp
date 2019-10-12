using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UniversityApp.Common.Abstractions;

namespace UniversityApp.Common
{
    [Serializable()]
    public class MarkedSubject
    {
        private int _mark;
        private Subject _subject;

        public int Mark
        {
            get { return _mark; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _mark = value;
                }
            }
        }

        public Subject Subject
        {
            get
            {
                return _subject;
            }
            set { _subject = value; }
        }

        public MarkedSubject()
        {
            _subject = null;
            Mark = 0;
        }

        public MarkedSubject(int mark, Subject subject) 
        {
            _subject = subject;
            Mark = mark;
        }
    }
}
