using System.Text;

namespace _01.ReverseStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class ReverseString
    {
        public static void Main()
        {
            var inputString = Console.ReadLine().ToCharArray();
            var sb = new StringBuilder();
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                sb.Append(inputString[i]);
            }
            Console.WriteLine($"{sb}");
        }
    }
}
