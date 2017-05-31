using System;
using System.Linq;
using System.Numerics;

namespace MatricesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong input = ulong.Parse(Console.ReadLine());
            ulong[] c = new ulong[] { };             
            for (BigInteger i = 0; i < input; i++)           
            {                                     
                c = operation(c);                      
                foreach (BigInteger j in c)              
                    Console.Write(j + " ");       
                Console.WriteLine();                  
            }                                      
            Console.ReadLine();                   
        }

        private static ulong[] operation(ulong[] b)         
        {                                         
            ulong i = 1, n = (ulong)b.Length, m = n / 2;
            ulong[] c = new ulong[n + 1];
            c[0] = 1;
            for (; i <= m; i++)
                c[i] = b[i - 1] + b[i];
            for (i = 0; n > i; i++, n--)
                c[n] = c[i];
            return c;
        }
    }
}
