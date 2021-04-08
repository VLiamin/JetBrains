using System;
using System.Collections.Generic;
using System.Text;

namespace StateOfStamps
{
    public class Department
    {
        public int Identificator { get; set; }
        public bool isBegin { get; set; }
        public bool isEnd { get; set; }
        public bool TypeOfTheRule { get; set; }
        public int FirstStamp { get; set; }
        public int SecondStamp { get; set; }
        public int FirstStampCrossed { get; set; }
        public int SecondStampCrossed { get; set; }
        public int FirstNextDepartmentIdentificator { get; set; }
        public int SecondNextDepartmentIdentificator { get; set; }
        public int Conditional { get; set; }
        public int Counter { get; set; }

    }
}
