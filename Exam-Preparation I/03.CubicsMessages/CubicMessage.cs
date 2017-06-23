namespace _03.CubicsMessages
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class CubicMessage
    {
        static void Main()
        {
            var pattern = "^([0-9]+)([A-Za-z]+)([^A-Za-z ]*?)$";

            var inputLine = Console.ReadLine();

            while (inputLine != "Over!")
            {
                int sizeMessage = int.Parse(Console.ReadLine());
                var regex = new Regex(pattern);
                var match = regex.Match(inputLine);
                var sb = new StringBuilder();

                var message = match.Groups[2].ToString();

                if (!match.Success)
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                if (match.Groups[2].ToString().Length != sizeMessage)
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                else
                {
                    string numbers = match.Groups[1].ToString();
                    string secondLinenumbers = match.Groups[3].ToString();


                    for (int i = 0; i < numbers.Length; i++)
                    {
                        int index = (int)Char.GetNumericValue(numbers[i]);
                        if (index >= sizeMessage || index < 0)
                        {
                            sb.Append(' ');
                        }
                        else
                        {
                            sb.Append(message[index]);
                        }
                    }

                    for (int i = 0; i < secondLinenumbers.Length; i++)
                    {
                        int n;
                        bool isNumber = int.TryParse(secondLinenumbers[i].ToString(), out n);
                        if (isNumber)
                        {
                            int index = (int)Char.GetNumericValue(secondLinenumbers[i]);
                            if (index >= sizeMessage || index < 0)
                            {
                                sb.Append(' ');
                            }
                            else
                            {
                                sb.Append(message[index]);
                            }
                        }
                    }

                }
                Console.WriteLine($"{message} == {sb.ToString()}");
                inputLine = Console.ReadLine();
            }
            Console.WriteLine();
        }
    }
}
