namespace _01.Regeh
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Text;

    class Regeh
    {
        static void Main()
        {
            var patternToMatchNested = "(\\[(?:\\??[^\\[]*?\\]))";
            var patternToMatchFinal = "\\[(\\w)+?<(\\d+?REGEH\\d+?)>(\\w)+?\\]";
            var inputLine = Console.ReadLine();
            var regex = new Regex(patternToMatchNested);
            var matches = regex.Matches(inputLine);

            var sb = new StringBuilder();

            foreach (Match match in matches)
            {
                sb.Append(match);
            }
            var onlyNestedInput = sb.ToString();

            var numbersFromFinal = new List<int>();

            var result = new List<string>();
            var regex1 = new Regex(patternToMatchFinal);
            var matchess = regex1.Matches(onlyNestedInput);
            foreach (Match match in matchess)
            {
                result.Add(match.Groups[2].ToString());
            }

            foreach (var str in result)
            {
                if (str.Contains(" "))
                {
                    result.Remove(str);
                }
                var pattern = "\\d+";
                var regex2 = new Regex(pattern);
                var numbMatches = regex2.Matches(str);
                foreach (var num in numbMatches)
                {
                    numbersFromFinal.Add(int.Parse(num.ToString()));
                }
            }
            Print(numbersFromFinal, inputLine);
        }

        private static void Print(List<int> numbersFromFinal, string inputLine)
        {
            var indexes = new List<int>();
            var numToAdd = 0;
            for (int i = 0; i < numbersFromFinal.Count; i++)
            {
                numToAdd += numbersFromFinal[i];
                indexes.Add(numToAdd);
            }
            for (int i = 0; i < indexes.Count; i++)
            {
                while (indexes[i] > inputLine.Length - 1)
                {
                    indexes[i] = indexes[i] - (inputLine.Length - 1);
                }

                Console.Write(inputLine[indexes[i]]);
            }
        }
    }
}