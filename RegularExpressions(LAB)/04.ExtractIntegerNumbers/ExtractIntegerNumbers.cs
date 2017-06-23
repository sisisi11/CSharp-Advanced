using System.Text.RegularExpressions;

namespace _04.ExtractIntegerNumbers
{
    using System;
    public class ExtractIntegerNumbers
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = "\\d+";
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(inputLine);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
