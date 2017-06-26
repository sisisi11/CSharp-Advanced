using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Repository
{
    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                PrintStudents(wantedData.OrderBy(x => x.Value.Sum()).ToDictionary(x => x.Key, y => y.Value));

            }
            else if (comparison == "descending")
            {
                PrintStudents(wantedData.OrderByDescending(x => x.Value.Sum()).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }



        private static int CompareInOrder(KeyValuePair<string, List<int>> firstValue,
            KeyValuePair<string, List<int>> secondValue)
        {
            var totalOfFirstMarks = 0;
            foreach (var i in firstValue.Value)
            {
                totalOfFirstMarks += i;
            }

            var totalOfSecondMarks = 0;
            foreach (var i in secondValue.Value)
            {
                totalOfSecondMarks += i;
            }

            return totalOfSecondMarks.CompareTo(totalOfFirstMarks);
        }

        private static int CompareDescendingOrder(KeyValuePair<string, List<int>> firstValue,
            KeyValuePair<string, List<int>> secondValue)
        {
            var totalOfFirstMarks = 0;

            foreach (var i in firstValue.Value)
            {
                totalOfFirstMarks += i;
            }

            var totalOfSecondMarks = 0;

            foreach (var i in secondValue.Value)
            {
                totalOfSecondMarks += i;
            }

            return totalOfFirstMarks.CompareTo(totalOfSecondMarks);
        }


        private static Dictionary<string, List<int>> GetSortedStudents(Dictionary<string, List<int>> studentsWanted,
            int takeCount, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> Comparison)
        {


            var studentsSorted = new Dictionary<string, List<int>>();

            var nextInOrder = new KeyValuePair<string, List<int>>();

            var isSorted = false;
            var counter = 0;
            while (counter < takeCount)
            {
                isSorted = true;
                foreach (var studentWanted in studentsWanted)
                {
                    if (!String.IsNullOrEmpty(nextInOrder.Key))
                    {
                        var comparisonResult = Comparison(studentWanted, nextInOrder);
                        if (comparisonResult >= 0 && !studentsSorted.ContainsKey(studentWanted.Key))
                        {
                            nextInOrder = studentWanted;
                            isSorted = false;
                        }
                    }
                    else
                    {
                        if (!studentsSorted.ContainsKey(studentWanted.Key))
                        {
                            nextInOrder = studentWanted;
                            isSorted = false;
                        }
                    }
                }
                if (!isSorted)
                {
                    studentsSorted.Add(nextInOrder.Key, nextInOrder.Value);
                    nextInOrder = new KeyValuePair<string, List<int>>();
                }
                counter++;
            }

            return studentsSorted;
        }

        private static void PrintStudents(Dictionary<string, List<int>> studentsSorted)
        {
            foreach (var pair in studentsSorted)
            {
                OutputWriter.PrintStudent(pair);
            }
        }
    }
}
