using System.Text.RegularExpressions;

namespace _10.UseYourChainsBuddy
{
    using System;
    using System.Linq;
    using System.Text;

    class UseYuorChainsBuddy
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            var regex = new Regex("<p>(.*?)<\\/p>");
            var matches = regex.Matches(inputLine);

            foreach (Match match in matches)
            {
                var whitespace = "[^a-z0-9]+";
                var reminder = match.Groups[1].Value;
                var replaced = Regex.Replace(reminder, whitespace, " ");

                var sb = new StringBuilder();
                foreach (var ch in replaced)
                {
                    if (ch >= 'a' && ch <= 'm')
                    {
                        sb.Append((char) (ch + 13));
                    }
                    else if (ch >= 'n' && ch <= 'z')
                    {
                        sb.Append((char)(ch - 13));
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }
                foreach (var str in sb.ToString().ToList())
                {
                    Console.Write(string.Join(" ", str));
                }
            }

        }
    }
}
