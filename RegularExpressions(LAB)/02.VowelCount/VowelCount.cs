namespace _02.VowelCount
{
    using System.Text.RegularExpressions;
    using System;
    public class VowelCount
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = "[AEIOUYaeiouy]";

            Regex regex = new Regex(pattern);
            var match = regex.Matches(inputLine);
            Console.WriteLine($"Vowels: {match.Count}");
        }
    }
}
