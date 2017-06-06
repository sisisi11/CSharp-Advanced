namespace _04.MaximalSum
{
    using System;
    using System.Linq;
    public class MaximalSum
    {
        public static void Main()
        {
            long[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            long rows = input[0];
            long cols = input[1];
            long[,] matrix = new long[rows, cols];

            for (long row = 0; row < rows; row++)
            {
                long[] currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                for (long col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            long sumOf3x3 = long.MinValue;
            long maxSum = 0;
            long maxRow = 0;
            long maxCol = 0;

            for (long row = 0; row < rows - 2; row++)
            {
                for (long col = 0; col < cols - 2; col++)
                {
                    sumOf3x3 = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                               +matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                               +matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sumOf3x3 > maxSum)
                    {
                        maxRow = row;
                        maxCol = col;
                        maxSum = sumOf3x3;
                    }
                }
            }
            Console.WriteLine("Sum = {0}", maxSum);
            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]} {matrix[maxRow, maxCol + 2]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]} {matrix[maxRow + 1, maxCol + 2]}");
            Console.WriteLine($"{matrix[maxRow + 2, maxCol]} {matrix[maxRow + 2, maxCol + 1]} {matrix[maxRow + 2, maxCol + 2]}");
        }
    }
}
