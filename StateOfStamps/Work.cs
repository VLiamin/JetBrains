using System;
using System.Collections.Generic;

namespace StateOfStamps
{
    public class Work
    {

        private int NumberOfDepartments;
        private int NumberOfStamps;
        private Department[] Departments;
        List<int> Stamps = new List<int>();
        

        public void GetStamps(Department[] Departments, int identificator)
        {
           
            int i = 1;
            var previousConditions = new Dictionary<int, List<List<int>>>();
            int temp = 1;
            bool flag = true;

            while (flag)
            {
                if (Departments[i - 1].isEnd)
                {
                    flag = false;
                }
                temp = i;
                Departments[i - 1].Counter = Departments[i - 1].Counter + 1;
                if (!Departments[i].TypeOfTheRule)
                {
                    Stamps.Remove(Departments[i - 1].FirstStampCrossed);
                    if (!Stamps.Contains(Departments[i - 1].FirstStamp))
                    {
                        Stamps.Add(Departments[i - 1].FirstStamp);
                    }
                    i = Departments[i - 1].FirstNextDepartmentIdentificator;
                } else
                {
                    if (Stamps.Contains(Departments[i - 1].Conditional))
                    {
                        Stamps.Remove(Departments[i - 1].FirstStampCrossed);
                        if (!Stamps.Contains(Departments[i - 1].FirstStamp))
                        {
                            Stamps.Add(Departments[i - 1].FirstStamp);
                        }
                        i = Departments[i - 1].FirstNextDepartmentIdentificator;
                    } else
                    {
                        Stamps.Remove(Departments[i - 1].SecondStampCrossed);
                        if (!Stamps.Contains(Departments[i - 1].SecondStamp))
                        {
                            Stamps.Add(Departments[i - 1].SecondStamp);
                        }
                        i = Departments[i - 1].SecondNextDepartmentIdentificator;
                    }
                }
                ////////////////////////////
                // Console.WriteLine(Departments[temp].Counter);
                if (Departments[temp].Counter > 1)
                {
                    if (previousConditions.ContainsKey(temp))
                    {
                        List<List<int>> list;
                        previousConditions.TryGetValue(temp, out list);

                        //          Console.WriteLine(list.Count + "fjfjfj");
                        foreach (List<int> x in list)
                        {

                            if (Equal(x, Stamps))
                            {
                                flag = false;
                            }

                        }

                        List<int> copyList = new List<int>();
                        foreach (int x in Stamps)
                        {
                            copyList.Add(x);
                        }
                        list.Add(copyList);
                    } else
                    {
                        List<List<int>> list = new List<List<int>>();
                        List<int> copyList = new List<int>();
                        foreach (int x in Stamps)
                        {
                            copyList.Add(x);
                        }
                        list.Add(copyList);
                        previousConditions.Add(temp, list);
                    }
                }
                if (identificator == temp)
                {
                    foreach (int z in Stamps)
                    {
                        Console.Write(z + " ");
                    }
                    Console.WriteLine();
                }

            }

            

        }

        private bool Equal(List<int> list1, List<int> list2)
        {
            foreach (int x in list1)
            {
                if (!list2.Contains(x))
                    return false;
            }

            foreach (int x in list2)
            {
                if (!list1.Contains(x))
                    return false;
            }
            return true;
        }

     /*   private void FillConfiguration()
        {
            Console.Write("Number of departments: ");
            NumberOfDepartments = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number of Stamps: ");
            NumberOfStamps = Convert.ToInt32(Console.ReadLine());
            Departments = new Department[NumberOfDepartments];

            bool isBeginExist = false;
            bool isEndExist = false;
            bool isConditional;
            bool isBegin = false;
            bool isEnd = false;
            int FirstNextDepartment = 0;
            int FirstStamp = 0;
            int FirstStampCrossed = 0;
            int SecondStamp = 0;
            int SecondStampCrossed = 0;
            int SecondNextDepartment = 0;
            int ConditionalStamp = 0;
            int identificator = 0;

            for (int i = 0; i < NumberOfDepartments; i++)
            {
                Console.Write("Indeficator of department: ");
                identificator = Convert.ToInt32(Console.ReadLine());

                if (!isBeginExist)
                {
                    Console.Write("Is this first department (true/false): ");
                    isBegin = Convert.ToBoolean(Console.ReadLine());
                    if (isBegin)
                    {
                        isBeginExist = true;
                    }
                }

                if (!isEndExist)
                    {
                        Console.Write("Is this last department (true/false): ");
                        isEnd = Convert.ToBoolean(Console.ReadLine());
                        if (isEnd)
                        {
                            isEndExist = true;
                        }
                    }

                Console.Write("Rule type (conditional - 1, unconditional - 2): ");
                int number = Convert.ToInt32(Console.ReadLine());
                if (number == 1)
                {
                    isConditional = true;
                } else
                {
                    isConditional = false;
                }

                if (!isConditional)
                {
                    Console.Write($"Delivered stamp identificator (1..{NumberOfStamps}): ");
                    FirstStamp = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Identifier of the seal to be crossed out (1..{NumberOfStamps}): ");
                    FirstStampCrossed = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Identifier of the next department (1..{NumberOfDepartments}): ");
                    FirstNextDepartment = Convert.ToInt32(Console.ReadLine());
                } else
                {
                    Console.Write($"Conditional stamp identificator (1..{NumberOfStamps}): ");
                    ConditionalStamp =  Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Delivered stamp identificator (1..{NumberOfStamps} if conditional true): ");
                    FirstStamp = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Identifier of the seal to be crossed out (1..{NumberOfStamps} if conditional true): $");
                    FirstStampCrossed = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Identifier of the next department (1..{NumberOfDepartments} if conditional true): $");
                    FirstNextDepartment = Convert.ToInt32(Console.ReadLine());

                    Console.Write($"Delivered stamp identificator (1..{NumberOfStamps} if conditional false): ");
                    SecondStamp = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Identifier of the seal to be crossed out (1..{NumberOfStamps} if conditional false): ");
                    SecondStampCrossed = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Identifier of the next department (1..{NumberOfDepartments} if conditional false): ");
                    SecondNextDepartment = Convert.ToInt32(Console.ReadLine());
                }

                Department department = new Department();
                department.TypeOfTheRule = isConditional;
                department.Identificator = identificator;
                department.isBegin = isBegin;
                department.isEnd = isEnd;
                department.FirstNextDepartmentIdentificator = FirstNextDepartment;
                department.FirstStamp = FirstStamp;
                department.FirstStampCrossed = FirstStampCrossed;

                if (isConditional)
                {
                    department.Conditional = ConditionalStamp;
                    department.SecondNextDepartmentIdentificator = SecondNextDepartment;
                    department.SecondStamp = SecondStamp;
                    department.SecondStampCrossed = SecondStampCrossed;
                }
                department.Counter = 0;
                Departments[department.Identificator - 1] = department;
                Console.WriteLine();
            }
        }*/
    }
}
