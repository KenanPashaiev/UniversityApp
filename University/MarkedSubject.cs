using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class MarkedSubject
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
        }
    
        public MarkedSubject(int mark, Subject subject) 
        {
            _subject = subject;
            Mark = mark;
        }
    }
}
