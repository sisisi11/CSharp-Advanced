namespace _01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class UniqueUsers
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                set.Add(input);
            }
            foreach (var element in set)
            {
                Console.WriteLine(element);
            }
        }
    }
}
