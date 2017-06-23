namespace _06.TargetPractice
{
    using System;
    using System.Linq;
    public class TargetPractice
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            char[,] matrix = new char[rows, cols];
            var snake = Console.ReadLine().ToCharArray();

            FillTheMatrix(rows, cols, matrix, snake);
            var shotArgs = Console.ReadLine().Split(' ').ToArray();
            int impactRow = int.Parse(shotArgs[0]);
            int impactCol = int.Parse(shotArgs[1]);
            int radius = int.Parse(shotArgs[2]);

            FireAShot(impactRow, impactCol, radius, matrix);
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Gravity(matrix, col);
            }
            Print(matrix);
        }

        private static void Gravity(char[,] matrix, int col)
        {
            while (true)
            {
                bool hasFallen = false;
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    char topChar = matrix[row - 1, col];
                    char cuurentChar = matrix[row, col];
                    if (cuurentChar == ' ' && topChar != ' ')
                    {
                        matrix[row, col] = topChar;
                        matrix[row - 1, col] = ' ';
                        hasFallen = true;
                    }
                }
                if (!hasFallen)
                {
                    break;
                }
            }
        }

        private static void Print(char[,] matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    Console.Write(matrix[rowIndex, colIndex]);
                }
                Console.WriteLine();
            }
        }

        private static void FireAShot(int impactRow, int impactCol, int radius, char[,] matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    if ((colIndex - impactCol) * (colIndex - impactCol) + (rowIndex - impactRow) * (rowIndex - impactRow) <= radius * radius)
                    {
                        matrix[rowIndex, colIndex] = ' ';
                    }
                }
            }
        }

        private static void FillTheMatrix(int rows, int cols, char[,] matrix, char[] snake)
        {
            bool isMovingLeft = true;
            int counter = 0;
            for (int rowIndex = rows - 1; rowIndex >= 0; rowIndex--)
            {

                if (isMovingLeft)
                {
                    for (int colIndex = cols - 1; colIndex >= 0; colIndex--)
                    {

                        matrix[rowIndex, colIndex] = snake[counter % snake.Length];
                        counter++;
                    }
                }
                else
                {
                    for (int colIndex = 0; colIndex < cols; colIndex++)
                    {
                        matrix[rowIndex, colIndex] = snake[counter % snake.Length];
                        counter++;
                    }
                }
                isMovingLeft = !isMovingLeft;
            }
        }
    }
}

