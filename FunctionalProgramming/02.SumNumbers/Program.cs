using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SumNumbers
{
    public static class ExtenssionMethod
    {
        public static string PrintCountAndResult(this List<int> result)
        {

            int sum = 0;
            foreach (var item in result)
            {
                sum += item;
            }
            return $"{result.Count} \n{result.Sum()}";
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList().PrintCountAndResult());
        }

    }
}
