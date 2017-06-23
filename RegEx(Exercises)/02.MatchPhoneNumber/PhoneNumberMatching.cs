namespace _02.MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;
    public class PhoneNumberMatching
    {
        static void Main()
        {

            var inputLine = Console.ReadLine();
            var pattern = "^\\+359(\\s|-)2\\1\\d{3}\\1\\d{4}$";

            while (inputLine != "end")
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
