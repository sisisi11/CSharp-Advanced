namespace _04.PascalTriangle
{
    using System;
    using System.Numerics;
    public  class PascalTriangle
    {
        static void Main()
        {
            BigInteger nLimit;

            nLimit = BigInteger.Parse(Console.ReadLine());

            for (BigInteger i = 0; i < nLimit; i++)
            {
                BigInteger c = 1;
                Console.WriteLine(" ");

                for (BigInteger j = 0; j <= i; j++)
                {
                    Console.Write(c);
                    Console.Write(" ");

                    c = c * (i - j) / (j + 1);
                }
                Console.Write(" ");
            }
            Console.Write(" ");
            Console.Read();
        }
    }
}