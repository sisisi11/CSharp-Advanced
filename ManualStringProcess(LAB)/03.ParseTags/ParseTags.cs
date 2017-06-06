namespace _03.ParseTags
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class ParseTags
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();

            var openTag = "<upcase>";
            var closeTag = "</upcase>";
            int startIndex = inputLine.IndexOf(openTag);

            while (startIndex != -1)
            {
                int endIndex = inputLine.IndexOf(closeTag);
                if (endIndex == -1)
                {
                    break;
                }
                var toBeReplaced = inputLine.Substring(startIndex, endIndex + closeTag.Length - startIndex);

                var replaced = toBeReplaced.Replace(openTag, string.Empty).Replace(closeTag, string.Empty).ToUpper();

                inputLine = inputLine.Replace(toBeReplaced, replaced);

                startIndex = inputLine.IndexOf(openTag);
            }
            Console.WriteLine(inputLine);
        }
    }
}
