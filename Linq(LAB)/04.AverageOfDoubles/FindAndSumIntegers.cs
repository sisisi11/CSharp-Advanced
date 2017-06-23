namespace _06.FindAndSumIntegers
{
    using System;
    using System.Linq;

    class FindAndSumIntegers
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine()
                .Split()
                .Where((e, z) => int.TryParse(e, out z))
                .ToArray();

            if (numbers.Length > 0)
            {
                Console.WriteLine($"{numbers.Select(long.Parse).Sum()}");
                return;
            }

            Console.WriteLine("No match");
        }
    }
}
