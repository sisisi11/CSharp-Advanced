namespace _06.ExtractSentences
{
    using System.Text.RegularExpressions;
    using System;
    public class ExtractSenteceses
    {
        static void Main()
        {
            var keyWord = Console.ReadLine();
            var inputLine = Console.ReadLine();
            string pattern = $@"[^.?!]*(?<=[.?\s!]){keyWord}(?=[\s.?!])[^.?!]*[.?!]";
            var regex = new Regex(pattern);
            var matches = regex.Matches(inputLine);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString().Trim());
            }
        }
    }
}
