namespace _02.Submatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Submatrix
    {
        static void Main()
        {
            var matrixSize = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();


            int[][] matrix = new int[int.Parse(matrixSize[0])][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var maxSquareRow = 0;
            var maxSquareCol = 0;
            var maxSum = 0;

            for (int rowIndex = 0; rowIndex < matrix.Length - 1;
                rowIndex++)
            {
                for (int colIndex = 0;
                    colIndex < matrix[rowIndex].Length - 1; colIndex++)
                {
                    var currenteSum = matrix[rowIndex][colIndex] +
                                       matrix[rowIndex + 1][colIndex] +
                                       matrix[rowIndex][colIndex + 1] +
                                       matrix[rowIndex + 1][colIndex + 1];

                    if (maxSum < currenteSum)
                    {
                        maxSum = currenteSum;
                        maxSquareRow = rowIndex;
                        maxSquareCol = colIndex;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxSquareRow][maxSquareCol]} {matrix[maxSquareRow][maxSquareCol + 1]}\n{matrix[maxSquareRow + 1][maxSquareCol]} {matrix[maxSquareRow + 1][maxSquareCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
