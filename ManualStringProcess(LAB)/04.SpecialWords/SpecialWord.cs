namespace _04.SpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SpecialWord
    {
        public static void Main()
        {
            var dictionary = new Dictionary<string, int>();
            var keyWords = Console.ReadLine().Split();
            var inputLine = Console.ReadLine().Split(
                new string[] { "(", ")", "[", "]", "<", ">", ",", "-", "!", "?", " ", },
                StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < keyWords.Length; i++)
            {
                if (!dictionary.ContainsKey(keyWords[i]))
                {
                    dictionary.Add(keyWords[i], 0);
                }
                for (int j = 0; j < inputLine.Length; j++)
                {
                    if (inputLine[j] == keyWords[i])
                    {
                        dictionary[keyWords[i]] += 1;
                    }
                }
            }
            foreach (var word in dictionary)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}

