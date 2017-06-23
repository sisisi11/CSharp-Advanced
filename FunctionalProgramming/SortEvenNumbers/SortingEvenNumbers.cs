namespace SortEvenNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class ExtenssionMethod
    {
        public static string Print(this List<int> numbers)
        {
            return $"{string.Join(", ", numbers)}";
        }
    }
    class SortingEvenNumbers
    {
        static void Main()
        {
            Console.WriteLine(Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).Where(n => n % 2 == 0).OrderBy(n => n).ToList().Print());
        }
    }
}
