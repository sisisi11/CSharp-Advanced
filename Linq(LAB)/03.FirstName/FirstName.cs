namespace _03.FirstName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FirstName
    {
        static void Main()
        {
            var inpuNames = Console.ReadLine().Split(' ');
            var letters = Console.ReadLine().Split(' ').OrderBy(l => l).ToArray();
            string filteredName = string.Empty;
            bool isFound = false;

            foreach (var letter in letters)
            {
                filteredName = inpuNames.Where(n => n.StartsWith(letter, true, null)).FirstOrDefault();

                if (filteredName != null)
                {
                    isFound = true;
                    Console.WriteLine(filteredName);
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("No match");
            }

        }
    }
}
