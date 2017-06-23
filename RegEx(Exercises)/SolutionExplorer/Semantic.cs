namespace SolutionExplorer
{
    using System;
    using System.Text.RegularExpressions;

    public class Semantic
    {
        static void Main()
        {
            var pattern = "<(div)([^>]+)(?:id|class)\\s*=\\s*\"(.*?)\"(.*?)>";
            var pattern1 = "<\\/div>\\s*<!--\\s*(.*?)\\s*-->";

            string inputLine = Console.ReadLine();
            while (inputLine != "END")
            {
                var openingMatch = Regex.Match(inputLine, pattern);
                var closingMatch = Regex.Match(inputLine, pattern1);

                if (openingMatch.Success)
                {
                    inputLine = Regex.Replace(inputLine, "<(div)([^>]+)(?:id|class)\\s*=\\s*\"(.*?)\"(.*?)>", "$3 $2 $4").Trim();
                    inputLine = "<" + Regex.Replace(inputLine, @"\s+", " ") + ">";
                }
                if (closingMatch.Success)
                {
                    inputLine = "</" + closingMatch.Groups[1] + ">";
                }
                Console.WriteLine(inputLine);

                inputLine = Console.ReadLine();
            }
        }
    }
}
