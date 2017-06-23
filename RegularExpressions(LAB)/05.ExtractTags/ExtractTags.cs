namespace _05.ExtractTags
{
    using System;
    using System.Text.RegularExpressions;
    public class ExtractTags
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = "<.+?>";

            while (inputLine != "END")
            {
                Regex regex = new Regex(pattern);
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
