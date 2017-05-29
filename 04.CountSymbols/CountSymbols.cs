namespace _04.CountSymbols
{
    using System;
    using System.Collections.Generic;
    public class CountSymbols
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var dictionary = new SortedDictionary<char, int>();

            foreach (var character in input)
            {
                if (!dictionary.ContainsKey(character))
                {
                    dictionary.Add(character, 1);
                }
                else
                {
                    dictionary[character]++;
                }
            }
            foreach (var character in dictionary.Keys)
            {
                Console.WriteLine($"{character}: {dictionary[character]} time/s");
            }
        }
    }
}
