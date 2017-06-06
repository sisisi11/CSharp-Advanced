namespace _04.PascalTriangle_MatrixVersion_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class PascalArrayVersion
    {
        public static void Main()
        {
            long height = long.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[height][];

            for (long row = 0; row < height; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                pascalTriangle[row][0] = 1;
                pascalTriangle[row][pascalTriangle[row].Length - 1] = 1;

                for (long col = 1; col < pascalTriangle[row].Length - 1; col++)
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];

                }
            }
            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
