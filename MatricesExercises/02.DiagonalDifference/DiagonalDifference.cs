namespace _02.DiagonalDifference
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());


            int[][] matrix = new int[matrixSize][];

            for (int rowIndex = 0; rowIndex <matrixSize; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine().
                    Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();
            }
            var sumPrimaryDiagonal = 0;
            for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
            {
                sumPrimaryDiagonal += matrix[rowIndex][rowIndex];
            }

            var sumSecondaryDiagonal = 0;
            for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
            {
                sumSecondaryDiagonal += matrix[rowIndex][matrixSize-rowIndex-1];
            }
            Console.WriteLine(Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal));
        }
    }
}
