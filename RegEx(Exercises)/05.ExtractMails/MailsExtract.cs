using System.Text.RegularExpressions;

namespace _05.ExtractMails
{
    using System;
    public class MailsExtract
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            string pattern = @"(?:^|\s)[a-zA-Z0-9][_\-\.a-zA-Z0-9]*@[a-zA-Z\-]+(\.[a-z]+)+\w";
            var regex = new Regex(pattern);
            var matches = regex.Matches(inputLine);
            foreach (Match match in matches)
            {
                
                Console.WriteLine(match.ToString().Trim());
            }
        }
    }
}
