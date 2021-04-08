using System;
using System.Collections.Generic;
using System.Text;

namespace StateOfStamps
{
    public class Department
    {
        /// <summary>
        /// Unique department number
        /// </summary>
        public int Identificator { get; set; }
        /// <summary>
        /// Is the department first
        /// </summary>
        public bool IsBegin { get; set; }
        /// <summary>
        /// Is the department last
        /// </summary>
        public bool IsEnd { get; set; }
        /// <summary>
        /// The kind of rule at the department. Conditional or unconditional.
        /// </summary>
        public bool IsConditionalRule { get; set; }
        /// <summary>
        /// The seal that the department puts in an unconditional rule or when a condition is met
        /// </summary>
        public int FirstStamp { get; set; }
        /// <summary>
        /// The seal that the department puts if the condition is not met
        /// </summary>
        public int SecondStamp { get; set; }
        /// <summary>
        /// A seal that the department crosses out in 
        /// an unconditional rule or when a condition is met
        /// </summary>
        public int FirstStampCrossed { get; set; }
        /// <summary>
        /// A seal that the department crosses out when a condition is not met
        /// </summary>
        public int SecondStampCrossed { get; set; }
        /// <summary>
        /// The number of the department to which this department sends in 
        /// an unconditional rule or when the condition is met
        /// </summary>
        public int FirstNextDepartmentIdentificator { get; set; }
        /// <summary>
        /// The number of the department where the data is sent if the condition is not met
        /// </summary>
        public int SecondNextDepartmentIdentificator { get; set; }
        /// <summary>
        /// Department stamp number, which is a condition
        /// </summary>
        public int Conditional { get; set; }
        /// <summary>
        /// The number of visits to the department
        /// </summary>
        public int Counter { get; set; }

    }
}
