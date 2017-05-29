using System.Linq.Expressions;

namespace _03.PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeriodicTable
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var set = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < input.Length; j++)
                {
                    set.Add(input[j]);
                }
            }
            foreach (var element in set)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}
