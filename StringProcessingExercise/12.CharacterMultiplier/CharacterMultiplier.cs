namespace _12.CharacterMultiplier
{
    using System;
    public class CharacterMultiplier
    {
        public static void Main()
        {
            string[] inputLine = Console.ReadLine().Split(' ');

            string word1 = inputLine[0];
            string word2 = inputLine[1];

            int minLength = Math.Min(word1.Length, word2.Length);
            int maxLength = Math.Max(word1.Length, word2.Length);
            int sum = 0;

            for (int i = 0; i < minLength; i++)
            {
                sum += word1[i] * word2[i];
            }

            if (word1.Length != word2.Length)
            {
                string longerInput = word1.Length > word2.Length ? longerInput = word1 : longerInput = word2;

                for (int i = minLength; i < maxLength; i++)
                {
                    sum += longerInput[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
