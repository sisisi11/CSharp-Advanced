namespace SeriesOfLetters
{
    using System;

    public class SeriesOfLetters
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            var result = inputLine[0].ToString();

            for (int i = 0; i < inputLine.Length - 1; i++)
            {
                var currentElement = inputLine[i].ToString();
                var nextElement = inputLine[i+1].ToString();
                if (currentElement != nextElement)
                {
                    result += nextElement;
                }
            }
            Console.WriteLine(result);
        }
    }
}
