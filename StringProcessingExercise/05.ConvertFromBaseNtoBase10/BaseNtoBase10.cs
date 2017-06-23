namespace _05.ConvertFromBaseNtoBase10
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Numerics;
    public class BaseNtoBase10
    {
        static void Main()
        {
            BigInteger[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse).ToArray();

            BigInteger n = input[0];
            BigInteger baseNtoConvert = input[1];

            string str = baseNtoConvert.ToString();
            BigInteger result = 0;

            for (int i = str.Length - 1, j = 0; i >= 0; i--, j++)
            {
                int num = int.Parse(str[i].ToString());
                BigInteger pow = 1;

                for (int k = 1; k <= j; k++)
                {
                    pow *= n;
                }

                result += num * pow;
            }
            Console.WriteLine(result);
        }
    }
}
