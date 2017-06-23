using System.Security.Policy;
using System.Text.RegularExpressions;

namespace _08.ExtractQuotations
{
    using System;
    public class ExtractQuotations
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = "(\")(.*?)(\")|(\')(.*?)(\')";
            var regex = new Regex(pattern);

            var matches = regex.Matches(inputLine);
            string str = string.Empty;
            foreach (var match in matches)
            {
                str = match.ToString();
                str = str.Remove(0, 1).Remove(str.Length - 2, 1);

                Console.WriteLine(str);
            }
        }
    }
}
