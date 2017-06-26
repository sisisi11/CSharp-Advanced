namespace _03.JediCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class JediCode
    {
        public const string patternForName = "([A-Za-z]*)(?![a-zA-Z])";
        public const string patternForMessage = "([A-Za-z0-9]*)(?![a-zA-Z0-9])";

        static void Main()
        {
            int numberLines = int.Parse(Console.ReadLine());

            var totalInput = "";
            var allNamesFromInput = new List<string>();
            var messageAndIndex = new Dictionary<int, string>();

            while (numberLines > 0)
            {
                var inputLine = Console.ReadLine();
                totalInput += inputLine;

                numberLines--;
            }

            var codeForName = Console.ReadLine();
            var codeForMessage = Console.ReadLine();
            var indexes = new List<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            var finalPatternForName = Regex.Escape(codeForName) + patternForName;
            var finalPatternForMessage = Regex.Escape(code) + patternForMessage;

            var regexForName = new Regex(finalPatternForName);
            var regexForMessage = new Regex(finalPatternForMessage);

            var nameMatches = regexForName.Matches(totalInput);
            var messageMatches = regexForMessage.Matches(totalInput);

            foreach (Match nameMatch in nameMatches)
            {
                var name = nameMatch.Groups[1].ToString();
                if (name.Length == codeForName.Length)
                {
                    allNamesFromInput.Add(name);
                }
            }
            for (int i = 0; i < messageMatches.Count; i++)
            {
                var message = messageMatches[i].Groups[1].ToString();
                if (message.Length == codeForMessage.Length)
                {
                    messageAndIndex.Add(i + 1, message);
                }
            }
            for (int i = 0; i < indexes.Count; i++)
            {

                if (i > allNamesFromInput.Count - 1)
                {
                    break;
                }
                if (!messageAndIndex.ContainsKey(indexes[i]))
                {
                    indexes.Remove(indexes[i]);
                }
                else
                {
                    Console.WriteLine($"{allNamesFromInput[i]} - {messageAndIndex[indexes[i]]}");
                }
            }
        }
    }
}