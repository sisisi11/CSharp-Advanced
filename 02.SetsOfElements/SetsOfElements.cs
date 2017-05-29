namespace _02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class SetsOfElements
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().
                Select(int.Parse).
                ToArray();

            int n = input[0];
            int m = input[1];
            int k = n + m;

            var nSet = new SortedSet<int>();
            var mSet = new SortedSet<int>();

            for (int i = 0; i < k; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                if (i < n)
                {
                    nSet.Add(numbers);
                }
                else
                {
                    mSet.Add(numbers);
                }
            }

            foreach (var num in nSet)
            {
                if (mSet.Contains(num))
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
