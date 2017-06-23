namespace _01.MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchCount
    {
        public static void Main()
        {
            var pattern = Console.ReadLine();
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            var match = regex.Matches(input);

            Console.WriteLine(match.Count);
        }
    }
}
