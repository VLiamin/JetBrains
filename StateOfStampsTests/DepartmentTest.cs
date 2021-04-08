using NUnit.Framework;
using StateOfStamps;
using System.Collections.Generic;
using System.Threading;

namespace StateOfStampsTests
{
    public class Tests
    {
        Work work = new Work();

        /// <summary>
        /// Test with a serial arrangement of departments
        /// </summary>
        [Test]
        public void GetStampsTest1()
        {
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
                IsConditionalRule = false,
                FirstStamp = 2,
                FirstStampCrossed = 3,
                Counter = 0,
                FirstNextDepartmentIdentificator = 3
            };
            Department department3 = new Department
            {
                Identificator = 3,
                IsBegin = false,
                IsEnd = true,
                IsConditionalRule = false,
                FirstStamp = 3,
                FirstStampCrossed = 2,
                Counter = 0,
                FirstNextDepartmentIdentificator = 3
            };

            Department[] departments = { department1, department2, department3 };

            List<List<int>> listOfStamps = new List<List<int>>();
            List<int> stamps = new List<int>();
            stamps.Add(1);
            stamps.Add(3);
            listOfStamps.Add(stamps);
            Assert.AreEqual(work.GetStamps(departments, 3), listOfStamps);

        }

        /// <summary>
        /// Test with a cycle and not entering the department in question
        /// </summary>
        [Test]
        public void GetStampsTest2()
        {
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
                IsConditionalRule = false,
                FirstStamp = 2,
                FirstStampCrossed = 3,
                Counter = 0,
                FirstNextDepartmentIdentificator = 1
            };
            Department department3 = new Department
            {
                Identificator = 3,
                IsBegin = false,
                IsEnd = true,
                IsConditionalRule = false,
                FirstStamp = 3,
                FirstStampCrossed = 2,
                Counter = 0,
                FirstNextDepartmentIdentificator = 3
            };

            Department[] departments = { department1, department2, department3 };

            List<List<int>> listOfStamps = new List<List<int>>();
            List<int> stamps1 = new List<int> { -1};
            List<int> stamps2 = new List<int> { -2};
            
            listOfStamps.Add(stamps1);
            listOfStamps.Add(stamps2);
            Assert.AreEqual(work.GetStamps(departments, 3), listOfStamps);

        }

        /// <summary>
        /// Test with a cycle and entry into the considered department
        /// </summary>
        [Test]
        public void GetStampsTest3()
        {
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
                IsConditionalRule = false,
                FirstStamp = 2,
                FirstStampCrossed = 3,
                Counter = 0,
                FirstNextDepartmentIdentificator = 1
            };
            Department department3 = new Department
            {
                Identificator = 3,
                IsBegin = false,
                IsEnd = true,
                IsConditionalRule = false,
                FirstStamp = 3,
                FirstStampCrossed = 2,
                Counter = 0,
                FirstNextDepartmentIdentificator = 3
            };

            Department[] departments = { department1, department2, department3 };

            List<List<int>> listOfStamps = new List<List<int>>();
            List<int> stamps1 = new List<int>() { 1, 2};
            List<int> stamps2 = new List<int>() { 1, 2 };
            List<int> stamps3 = new List<int>() { -1 };
            listOfStamps.Add(stamps1);
            listOfStamps.Add(stamps2);
            listOfStamps.Add(stamps3);
            Assert.AreEqual(work.GetStamps(departments, 2), listOfStamps);

        }

        /// <summary>
        /// Test with incorrect order of departments in an array
        /// </summary>
        [Test]
        public void GetStampsTest4()
        {
            Department department1 = new Department
            {
                Identificator = 2,
                IsBegin = false,
                IsEnd = false,
                IsConditionalRule = false,
                FirstStamp = 1,
                FirstStampCrossed = 3,
                Counter = 0,
                FirstNextDepartmentIdentificator = 3
            };
            Department department2 = new Department
            {
                Identificator = 3,
                IsBegin = false,
                IsEnd = true,
                IsConditionalRule = false,
                FirstStamp = 2,
                FirstStampCrossed = 3,
                Counter = 0,
                FirstNextDepartmentIdentificator = 3
            };
            Department department3 = new Department
            {
                Identificator = 1,
                IsBegin = true,
                IsEnd = false,
                IsConditionalRule = false,
                FirstStamp = 3,
                FirstStampCrossed = 2,
                Counter = 0,
                FirstNextDepartmentIdentificator = 2
            };

            Department[] departments = { department1, department2, department3 };

            List<List<int>> listOfStamps = new List<List<int>>();
            List<int> stamps = new List<int>();
            stamps.Add(1);
            stamps.Add(2);
            listOfStamps.Add(stamps);
            Assert.AreEqual(work.GetStamps(departments, 3), listOfStamps);

        }

        /// <summary>
        /// Conditional rule test
        /// </summary>
        [Test]
        public void GetStampsTest5()
        {
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
                Conditional = 3
            };
            Department department3 = new Department
            {
                Identificator = 3,
                IsBegin = false,
                IsEnd = true,
                IsConditionalRule = false,
                FirstStamp = 3,
                FirstStampCrossed = 2,
                Counter = 0,
                FirstNextDepartmentIdentificator = 3
            };

            Department[] departments = { department1, department2, department3 };

            List<List<int>> listOfStamps = new List<List<int>>();
            List<int> stamps = new List<int>();
            stamps.Add(3);
            listOfStamps.Add(stamps);
            Assert.AreEqual(work.GetStamps(departments, 3), listOfStamps);

        }

        /// <summary>
        /// Test showing the correctness of work with multithreading
        /// </summary>
        [Test]
        public void GetStampsTest6()
        {
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
                IsConditionalRule = false,
                FirstStamp = 2,
                FirstStampCrossed = 3,
                Counter = 0,
                FirstNextDepartmentIdentificator = 3
            };
            Department department3 = new Department
            {
                Identificator = 3,
                IsBegin = false,
                IsEnd = true,
                IsConditionalRule = false,
                FirstStamp = 3,
                FirstStampCrossed = 2,
                Counter = 0,
                FirstNextDepartmentIdentificator = 3
            };

            Department[] departments = { department1, department2, department3 };

            List<List<int>> listOfStamps = new List<List<int>>();
            List<int> stamps = new List<int>();
            stamps.Add(1);
            stamps.Add(3);
            listOfStamps.Add(stamps);

            var threads = new List<Thread>();

            for (var i = 0; i < 100; i++)
            {
                threads.Add(new Thread(() =>
                {
                    Assert.AreEqual(work.GetStamps(departments, 3), listOfStamps);
                }));
            }
            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

        }
    }
}