
namespace _04.ReplaceATag
{
    using System;
    using System.Text.RegularExpressions;
    public class ReplaceATag
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                var pattern = "<a.*?href=(.*)>(.*?)<\\/a>";
                var replace = "[URL href=$1]$2[/URL]";
                string replaced = Regex.Replace(inputLine, pattern, replace);

                Console.WriteLine(replaced);

                inputLine = Console.ReadLine();
            }
        }
    }
}
