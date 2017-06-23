using System.Text.RegularExpressions;

namespace _06.ValidUsernames
{
    using System;
    public class ValidUsername
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = (@"^[\w-]{3,16}$");
            while (inputLine != "END")
            {
                Regex regex = new Regex(pattern);
                var matches = regex.Matches(inputLine);
                if (matches.Count > 0)
                {
                    Console.WriteLine("valid");
                }
                else
                    Console.WriteLine("invalid");

                inputLine = Console.ReadLine();
            }
        }
    }
}
