using System;
using System.Collections.Generic;

namespace StateOfStamps
{

    /// <summary>
    /// Class that returns a list of strikethrough seals
    /// </summary>
    public class Work
    {

        private List<int> Stamps = new List<int>();

        /// <summary>
        /// Method that returns a list of strikethrough seals
        /// </summary>
        /// <param name="departments">
        /// Array of departments filled with information about them
        /// </param>
        /// <param name="identificator">
        /// Department number monitored by the method
        /// </param>
        /// <returns>
        /// A list of seals after passing through the department of the interested user
        /// </returns>
        public List<List<int>> GetStamps(Department[] departments, int identificator)
        {
            sort(departments);

            List<List<int>> resultsStamps = new List<List<int>>();
            int i = 1;
            var previousConditions = new Dictionary<int, List<List<int>>>();
            bool flag = true;

            while (flag)
            {
                if (departments[i - 1].IsEnd)
                {
                    flag = false;
                }

                int temp = i;
                departments[i - 1].Counter = departments[i - 1].Counter + 1;

                if (!departments[i - 1].IsConditionalRule)
                {
                    Stamps.Remove(departments[i - 1].FirstStampCrossed);
                    if (!Stamps.Contains(departments[i - 1].FirstStamp))
                    {
                        Stamps.Add(departments[i - 1].FirstStamp);
                    }
                    i = departments[i - 1].FirstNextDepartmentIdentificator;
                } else
                {
                    
                    if (Stamps.Contains(departments[i - 1].Conditional))
                    {

                        Stamps.Remove(departments[i - 1].FirstStampCrossed);
                        if (!Stamps.Contains(departments[i - 1].FirstStamp))
                        {
                            Stamps.Add(departments[i - 1].FirstStamp);
                        }
                        i = departments[i - 1].FirstNextDepartmentIdentificator;
                    } else
                    {
                        Stamps.Remove(departments[i - 1].SecondStampCrossed);
                        if (!Stamps.Contains(departments[i - 1].SecondStamp))
                        {
                            Stamps.Add(departments[i - 1].SecondStamp);
                        }
                        i = departments[i - 1].SecondNextDepartmentIdentificator;
                    }
                }

                if (departments[temp - 1].Counter > 1)
                {
                    if (previousConditions.ContainsKey(temp))
                    {
                        List<List<int>> list;
                        previousConditions.TryGetValue(temp, out list);

                        foreach (List<int> x in list)
                        {

                            if (Equal(x, Stamps))
                            {
                                flag = false;
                                resultsStamps.Add(new List<int> { -1 });
                                if (resultsStamps.Count == 1)
                                {
                                    resultsStamps.Add(new List<int> { -2 });
                                }
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
                    List<int> list = new List<int>();
                    foreach (int z in Stamps)
                    {
                        list.Add(z);
                    }
                    resultsStamps.Add(list);
                }

            }
            return resultsStamps;
            

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

     
        private void sort(Department[] departments)
        {
            for (int i = 0; i < departments.Length; i++)
            {
                if (departments[i].Identificator != i + 1)
                {
                    try
                    {
                        Department temp = departments[departments[i].Identificator - 1];
                    
                    departments[departments[i].Identificator - 1] = departments[i];
                    departments[i] = temp;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid data entered");
                        throw  new IndexOutOfRangeException();
                    }

                    i--;
                }
            }
        }

    }
}
