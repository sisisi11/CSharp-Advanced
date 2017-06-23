namespace _07.ValidTime
{
    using System;
    using System.Text.RegularExpressions;
    public class ValidTime
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = @"^((1[0-2]|0[1-9]):([0-5]?[0-9]):([0-5]?[0-9])\s([AP][M]))$";

            var regex = new Regex(pattern);
            while (inputLine != "END")
            {
                var match = regex.Match(inputLine);
                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}
