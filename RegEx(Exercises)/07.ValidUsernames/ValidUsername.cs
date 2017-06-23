namespace _07.ValidUsernames
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    public class ValidUsername
    {
        static void Main()

        {
            var inputLine = Console.ReadLine().Split(new string[] { " ", "\\", "/", "(", ")" },
                StringSplitOptions.RemoveEmptyEntries).ToList();

            string pattern = @"\b[a-zA-Z][0-9A-Za-z_]{2,24}\b";
            
            var result = new StringBuilder();

            for (int i = 0; i < inputLine.Count; i++)
            {
                var regex = new Regex(pattern);
                var match = regex.Match(inputLine[i].ToString());

                if (match.Success)
                {
                    result.Append(inputLine[i]);
                    result.Append(" ");
                }
            }
            PrintResult(result);
        }
        private static void PrintResult(StringBuilder result)
        {
            var str = result.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var resultList = new List<string>();
            int maxSum = 0;
            for (int i = str.Length - 2; i >= 0; i--)
            {
                int sum = str[i + 1].Length + str[i].Length;
                if (sum >= maxSum)
                {
                    maxSum = sum;
                    resultList.Clear();
                    resultList.Add(str[i]);
                    resultList.Add(str[i + 1]);
                }
            }
            Console.WriteLine(string.Join("", resultList[0]));
            Console.WriteLine(string.Join("", resultList[1]));
        }
    }
}
