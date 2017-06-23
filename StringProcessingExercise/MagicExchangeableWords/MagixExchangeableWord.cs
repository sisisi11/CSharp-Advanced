namespace MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;
    public class MagixExchangeableWord
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split(' ');
            HashSet<char> firstWord = new HashSet<char>(inputLine[0]);
            HashSet<char> secondWord = new HashSet<char>(inputLine[1]);
            Console.WriteLine((firstWord.Count == secondWord.Count) ? "true" : "false");
        }
    }
}