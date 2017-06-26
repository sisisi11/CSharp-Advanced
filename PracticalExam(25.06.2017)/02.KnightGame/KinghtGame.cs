namespace _02.KnightGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class KinghtGame
    {
        static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());

            char[,] matrixChess = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrixChess[row, col] = currentRow[col];
                }
            }
            Console.WriteLine();
            long result = 0;

            for (int rowIndex = 0; rowIndex < matrixChess.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrixChess.GetLength(1); colIndex++)
                {
                    if (matrixChess[rowIndex, colIndex] == 'K')
                    {
                        if (rowIndex - 2 >= 0 && rowIndex - 2 < matrixChess.GetLength(0) && colIndex - 1 >= 0 &&
                        colIndex - 1 < matrixChess.GetLength(0) && matrixChess[rowIndex - 2, colIndex - 1] == 'K')
                        {
                            matrixChess[rowIndex - 2, colIndex - 1] = '-';
                            result++;
                        }
                        if (rowIndex - 1 >= 0 && rowIndex - 1 < matrixChess.GetLength(0) && colIndex - 2 >= 0 &&
                        colIndex - 2 < matrixChess.GetLength(0) && matrixChess[rowIndex - 1, colIndex - 2] == 'K')
                        {
                            matrixChess[rowIndex - 1, colIndex - 2] = '-';
                            result++;
                        }
                        if (rowIndex + 1 >= 0 && rowIndex + 1 < matrixChess.GetLength(0) && colIndex - 2 >= 0 &&
                        colIndex - 2 < matrixChess.GetLength(0) && matrixChess[rowIndex + 1, colIndex - 2] == 'K')
                        {
                            matrixChess[rowIndex + 1, colIndex - 2] = '-';
                            result++;
                        }
                        if (rowIndex - 2 >= 0 && rowIndex - 2 < matrixChess.GetLength(0) && colIndex + 1 >= 0 &&
                        colIndex + 1 < matrixChess.GetLength(0) && matrixChess[rowIndex - 2, colIndex + 1] == 'K')
                        {
                            matrixChess[rowIndex - 2, colIndex + 1] = '-';
                            result++;
                        }
                        if (rowIndex + 2 >= 0 && rowIndex + 2 < matrixChess.GetLength(0) && colIndex - 1 >= 0 &&
                        colIndex - 1 < matrixChess.GetLength(0) && matrixChess[rowIndex + 2, colIndex - 1] == 'K')
                        {
                            matrixChess[rowIndex + 2, colIndex - 1] = '-';
                            result++;
                        }
                        if (rowIndex + 2 >= 0 && rowIndex + 2 < matrixChess.GetLength(0) && colIndex + 1 >= 0 &&
                        colIndex + 1 < matrixChess.GetLength(0) && matrixChess[rowIndex + 2, colIndex + 1] == 'K')
                        {
                            matrixChess[rowIndex + 2, colIndex + 1] = '-';
                            result++;
                        }
                        if (rowIndex - 1 >= 0 && rowIndex - 1 < matrixChess.GetLength(0) && colIndex + 2 >= 0 &&
                        colIndex + 2 < matrixChess.GetLength(0) && matrixChess[rowIndex - 1, colIndex + 2] == 'K')
                        {
                            matrixChess[rowIndex - 1, colIndex + 2] = '-';
                            result++;
                        }
                        if (rowIndex + 1 >= 0 && rowIndex + 1 < matrixChess.GetLength(0) && colIndex + 2 >= 0 &&
                        colIndex + 2 < matrixChess.GetLength(0) && matrixChess[rowIndex + 1, colIndex + 2] == 'K')
                        {
                            matrixChess[rowIndex + 1, colIndex + 2] = '-';
                            result++;
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}