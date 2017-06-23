using System.Text.RegularExpressions;

namespace _03.NonDigitCount
{
    using System;
    public class NonDigitCount
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = "[^0123456789]";
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(inputLine);

            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}
