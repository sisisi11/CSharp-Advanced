namespace _04.ConvertFromBase10toBaseN
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Numerics;
    public class Base10ToBaseN
    {
        static void Main()
        {
            BigInteger[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse).ToArray();

            BigInteger baseN = input[0];
            BigInteger tenNumber = input[1];

            StringBuilder result = new StringBuilder();
            while (tenNumber > 0)
            {
                BigInteger rem = tenNumber % baseN;
                result.Append(rem);
                tenNumber /= baseN;
            }

            string str = result.ToString();

            StringBuilder helper = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                helper.Append(str[i]);
            }
            Console.WriteLine(helper);
        }
    }
}
