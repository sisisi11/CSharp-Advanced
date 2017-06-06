namespace _09.Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Crossfire
    {
        static void Main()
        {
            var dimensions = Console.ReadLine().
                Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            var matrix = FillMatrix(rows, cols);
            var command = Console.ReadLine();
            while (command != "Nuke it from orbit")
            {
                var commandTokens = command.Split(' ').Select(int.Parse).ToArray();
                var rowImpact = commandTokens[0];
                var colImpact = commandTokens[1];
                var radius = commandTokens[2];
                for (int rowIndex = rowImpact - radius; rowIndex <= rowImpact + radius; rowIndex++)
                {
                    if (IsInMatrix(matrix, rowIndex, colImpact))
                    {
                        matrix[rowIndex][colImpact] = -1;
                    }
                }
                for (int colIndex = colImpact - radius; colIndex <= colImpact + radius; colIndex++)
                {
                    if (IsInMatrix(matrix, rowImpact, colIndex))
                    {
                        matrix[rowImpact][colIndex] = -1;
                    }
                }
                FilterMatrix(matrix);
                command = Console.ReadLine();
            }
            PrintMatrix(matrix);
            Console.WriteLine();
        }

        private static void FilterMatrix(List<List<int>> matrix)
        {
            for (int rowIndex = matrix.Count - 1; rowIndex >= 0; rowIndex--)
            {
                for (int colIndex = matrix[rowIndex].Count - 1; colIndex >= 0; colIndex--)
                {
                    if (matrix[rowIndex][colIndex] == -1)
                    {
                        matrix[rowIndex].RemoveAt(colIndex);
                    }
                }
                if (matrix[rowIndex].Count == 0)
                {
                    matrix.RemoveAt(rowIndex);
                }
            }
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
            {
                Console.WriteLine($"{string.Join(" ", matrix[rowIndex])}");
            }
        }

        private static bool IsInMatrix(List<List<int>> matrix, int currentRow, int currentCol)
        {
            if (currentRow >= 0 && currentRow < matrix.Count &&
                currentCol >= 0 && currentCol < matrix[currentRow].Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static List<List<int>> FillMatrix(int rows, int cols)
        {
            var matrix = new List<List<int>>();
            int counter = 1;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix.Add(new List<int>());
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex].Add(counter);
                    counter++;
                }
            }
            return matrix;
        }
    }
}
