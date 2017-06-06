using System.IO.Compression;
using System.Runtime.CompilerServices;

namespace _08.RadioactiveBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class RadioactiveBunnies
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            char[][] matrix = new char[rows][];
            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < rows; row++)
            {
                List<char> argsInfo = Console.ReadLine().ToList();
                matrix[row] = argsInfo.ToArray();
                for (int col = 0; col < cols; col++)
                    if (matrix[row][col] == 'P')
                    {
                        playerCol = col;
                        playerRow = row;
                    }
            }
            //List<char> commandInfo = Console.ReadLine().ToList();
            //bool isPLayerMoving = true;
            //for (int i = 0; i < commandInfo.Count; i++)
            //{

            //    switch (commandInfo[i])
            //    {
            //        case 'L':
            //            MovesPlayerRow(matrix, playerCol, playerRow, isPLayerMoving);
            //            while (isPLayerMoving)
            //            {
            //                BunniesMultiply(matrix);
            //            }
            //            break;
            //        case 'R':

            //            isPLayerMoving = true;
            //            break;
            //        case 'U':

            //            isPLayerMoving = true;
            //            break;
            //        case 'D':

            //            isPLayerMoving = true;
            //            break;
            //        default:
            //            break;
            //    }
            //} 
            BunniesMultiply(matrix);
            Console.WriteLine();
        }

        private static void BunniesMultiply(char[][] matrix)
        {
            char[][] matrixHelper = new char[matrix.Length][];
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrixHelper[rowIndex] = new char[matrix[rowIndex].Length];
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (rowIndex != 0 && colIndex != 0 && rowIndex != matrix.Length - 1 &&
                        colIndex != matrix[rowIndex].Length - 1)
                    {
                        if (matrix[rowIndex][colIndex] == 'B')
                        {
                            matrixHelper[rowIndex + 1][colIndex] = 'B';
                            matrixHelper[rowIndex - 1][colIndex] = 'B';
                            matrixHelper[rowIndex][colIndex + 1] = 'B';
                            matrixHelper[rowIndex][colIndex - 1] = 'B';
                            matrixHelper[rowIndex][colIndex] = 'B';
                        }
                    }
                }
            }
        }

        private static void MovesPlayerRow(char[][] matrix, int playerCol, int playerRow, bool isPLayerMoving)
        {
            throw new NotImplementedException();
        }
    }

}

