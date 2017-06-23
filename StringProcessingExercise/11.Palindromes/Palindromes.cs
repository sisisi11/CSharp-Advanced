namespace _11.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Palindromes
    {
        static void Main()
        {
            var inputLine = Console.ReadLine().Split(new char[] { '\n', ',', ';', ':', '.', '!', '(', ')', '"', '-', '\\', '/', '[', ']', ' ', '?', '\r', '`', '_', '{', '}', '<', '>', '\'' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var list = new List<string>();

            foreach (var ch in inputLine)
            {
                var helperch = string.Join("", ch.Reverse());
                if (ch == helperch && !list.Contains(ch))
                {
                    list.Add(ch);
                }
            }
            list = list.OrderBy(l => l.Length).OrderBy(l => l).Distinct().ToList();

            Console.WriteLine("[{0}]", string.Join(", ", list));
        }
    }
}
