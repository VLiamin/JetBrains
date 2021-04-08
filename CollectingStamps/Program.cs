using System;
using System.Collections.Generic;
using StateOfStamps;

namespace CollectingStamps
{
    class Program
    {
        /// <summary>
        /// An example of how the library works
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Work work = new Work();
            Department department1 = new Department
            {
                Identificator = 1,
                IsBegin = true,
                IsEnd = false,
                IsConditionalRule = false,
                FirstStamp = 1,
                FirstStampCrossed = 3,
                Counter = 0,
                FirstNextDepartmentIdentificator = 2
            };
            Department department2 = new Department
            {
                Identificator = 2,
                IsBegin = false,
                IsEnd = false,
                IsConditionalRule = true,
                FirstStamp = 2,
                SecondStamp = 3,
                FirstStampCrossed = 3,
                SecondStampCrossed = 1,
                Counter = 0,
                FirstNextDepartmentIdentificator = 3,
                SecondNextDepartmentIdentificator = 3,
                Conditional = 1
            };
            Department department3 = new Department
            {
                Identificator = 5,
                IsBegin = false,
                IsEnd = true,
                IsConditionalRule = false,
                FirstStamp = 3,
                FirstStampCrossed = 2,
                Counter = 0,
                FirstNextDepartmentIdentificator = 3
            };


            Department[] departments = { department1, department2, department3 };
            List<List<int>> lists = work.GetStamps(departments, 3);
            
            foreach (List<int> list in lists)
            {
                int[] array = list.ToArray();
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i]);
                }
                Console.WriteLine();
            }

        }
    }
}
