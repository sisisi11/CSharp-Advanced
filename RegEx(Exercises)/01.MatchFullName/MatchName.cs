namespace _01.MatchFullName
{
    using System;
    using System.Text.RegularExpressions;
    public class MatchName
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = "^[A-Z][a-z]{1,}\\s[A-Z][a-z]{1,}$";

            while (inputLine!="end")
            {
                var regex = new Regex(pattern);
                var matches = regex.Matches(inputLine);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}
