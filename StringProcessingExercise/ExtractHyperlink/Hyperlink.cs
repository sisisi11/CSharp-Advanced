namespace _16.ExtractHyperlink
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Hyperlink
    {
        public static void Main()
        {
            var allText = new StringBuilder();
            var inputLine = Console.ReadLine();

            var tags = new List<string>();
            while (inputLine != null && !inputLine.Equals("END"))
            {
                allText.Append(inputLine);
                inputLine = Console.ReadLine();
            }

            var wholeDocument = allText.Replace("\t", " ").ToString();
            while (wholeDocument.IndexOf("<a", StringComparison.Ordinal) >= 0)
            {
                var start = wholeDocument.IndexOf("<a", StringComparison.Ordinal);
                wholeDocument = wholeDocument.Substring(start, wholeDocument.Length - start);

                var end = wholeDocument.IndexOf(">", StringComparison.Ordinal);
                tags.Add(wholeDocument.Substring(0, end));
                wholeDocument = wholeDocument.Remove(0, end);
            }

            foreach (string t in tags)
            {
                var currentTag = t;
                while (currentTag.IndexOf("href ", StringComparison.Ordinal) >= 0)
                {
                    currentTag = currentTag.Remove(currentTag.IndexOf("href ", StringComparison.Ordinal) + 4, 1);
                }

                while (currentTag.IndexOf("href= ", StringComparison.Ordinal) >= 0)
                {
                    currentTag = currentTag.Remove(currentTag.IndexOf("href= ", StringComparison.Ordinal) + 5, 1);
                }

                var start = currentTag.IndexOf("href=", StringComparison.Ordinal);
                if (start < 0)
                {
                    continue;
                }
                currentTag = currentTag.Substring(start + 5, currentTag.Length - 5 - start);
                //Console.WriteLine(currentTag);
                switch (currentTag.ElementAt(0))
                {
                    case '\'':
                        currentTag = currentTag.Remove(0, 1);
                        Console.WriteLine(currentTag.Substring(0, currentTag.IndexOf("'", StringComparison.Ordinal)));
                        break;
                    case '"':
                        currentTag = currentTag.Remove(0, 1);
                        Console.WriteLine(currentTag.Substring(0, currentTag.IndexOf("\"", StringComparison.Ordinal)));
                        break;
                    default:
                        var words = currentTag.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                        Console.WriteLine(words[0]);
                        break;
                }
            }
        }
    }
}