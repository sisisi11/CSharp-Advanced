
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _09.QueryMess
{
    using System;
    using System.Text;

    public class QueryMess
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = @"([^&=?]*)=([^&=]*)";
            var spaces = @"((%20|\+)+)";

            while (inputLine != "END")
            {
                var pairs = new Regex(pattern);
                var matches = pairs.Matches(inputLine);
                var result = new Dictionary<string, List<string>>();

                for (int i = 0; i < matches.Count; i++)
                {
                    var field = matches[i].Groups[1].Value;
                    field = Regex.Replace(field, spaces, " ").Trim();

                    var value = matches[i].Groups[2].Value;
                    value = Regex.Replace(value, spaces, " ").Trim();

                    if (!result.ContainsKey(field))
                    {
                        var values = new List<string>();
                        values.Add(value);
                        result.Add(field, values);
                    }
                    else
                    {
                        result[field].Add(value);
                    }
                }
                foreach (var pair in result)
                {
                    Console.Write("{0}=[{1}]", pair.Key, string.Join(", ", pair.Value));
                }
                Console.WriteLine();
                inputLine = Console.ReadLine();
            }
        }
    }
}
