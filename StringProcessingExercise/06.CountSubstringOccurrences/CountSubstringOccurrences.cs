namespace _06.CountSubstringOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CountSubstringOccurrences
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().ToLower();
            var keyWord = Console.ReadLine().ToLower();
            int startIndex = 0;
            int count = 0;

            while (true)
            {
                int found = inputLine.IndexOf(keyWord, startIndex);   //If there are NO keyWord in String found will be -1

                if (found >= 0)
                {
                    count++;
                    startIndex = found + 1;
                }
                else
                {
                    break;
                }

            }

            Console.WriteLine(count);
        }
    }
}
    
