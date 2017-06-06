using System.Threading;

namespace _05.RubiksMatrix
{
    using System;
    using System.Linq;
    public class RubiksMatrix
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];

            int counter = 1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = counter++;
                }
            }
            int numberOfcommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfcommands; i++)
            {
                var commandInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int rcindex = int.Parse(commandInfo[0]);
                string commandType = commandInfo[1];
                int moves = int.Parse(commandInfo[2]);

                switch (commandType)
                {
                    case "up":
                        MoveCols(matrix, rcindex, moves);
                        break;
                    case "down":
                        MoveCols(matrix, rcindex, rows - moves % rows);
                        break;
                    case "left":
                        MoverRows(matrix, rcindex, moves);
                        break;
                    case "right":
                        MoverRows(matrix, rcindex, cols - moves % cols);
                        break;
                }
            }
            PrintResult(matrix);
        }
        private static void PrintResult(int[,] matrix)
        {
            var element = 1;
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    if (matrix[rowIndex, colIndex] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int rIndex = 0; rIndex < matrix.GetLength(0); rIndex++)
                        {
                            for (int cIndex = 0; cIndex < matrix.GetLength(1); cIndex++)
                            {
                                if (matrix[rIndex, cIndex] == element)
                                {
                                    var currentElement = matrix[rowIndex, colIndex];
                                    matrix[rowIndex, colIndex] = element;
                                    matrix[rIndex,cIndex] = currentElement;
                                    Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({rIndex}, {cIndex})");
                                }
                            }
                        }
                    }
                    element++;
                }
            }
        }
        private static void MoverRows(int[,] matrix, int rcindex, int moves)
        {
            int[] temp = new int[matrix.GetLength(1)];
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                temp[col] = matrix[rcindex, (col + moves) % matrix.GetLength(1)];
            }
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[rcindex, col] = temp[col];
            }
            Console.WriteLine();
        }
        private static void MoveCols(int[,] matrix, int rcindex, int moves)
        {
            var temp = new int[matrix.GetLength(0)];
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                temp[rowIndex] = matrix[(rowIndex + moves) % matrix.GetLength(0), rcindex];
            }
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                matrix[rowIndex, rcindex] = temp[rowIndex];
            }
            Console.WriteLine();
        }
    }
}

