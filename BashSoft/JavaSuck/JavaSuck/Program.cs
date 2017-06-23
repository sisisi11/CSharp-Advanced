using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaSuck
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int num = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i+1; j++)
                {
                    if (num<=n)
                    {
                        Console.Write(num + " ");
                        num++;
                    }
                    else
                    {
                        Console.WriteLine();
                        return;
                    }
                }
                Console.WriteLine();
            }
        }

    }
}



