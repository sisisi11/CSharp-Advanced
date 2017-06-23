namespace _02.Nature_sProphet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class NatureProphet
    {
        static void Main()
        {
            var sizeMatrix = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var gardenRow = int.Parse(sizeMatrix[0]);
            var gardenCol = int.Parse(sizeMatrix[1]);

            var gardenMatrix = new int[gardenRow, gardenCol];

            var gardenResult = new int[gardenRow, gardenCol];

            for (int row = 0; row < gardenRow; row++)
            {

                for (int col = 0; col < gardenCol; col++)
                {
                    gardenMatrix[row, col] = 0;
                    gardenResult[row, col] = 0;
                }
            }
            var command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                var commandTokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var plantFlowerRow = int.Parse(commandTokens[0]);
                var plantFlowerCol = int.Parse(commandTokens[1]);

                if (gardenMatrix[plantFlowerRow, plantFlowerCol] == 0)
                {

                    gardenMatrix[plantFlowerRow, plantFlowerCol] = -1;
                }

                command = Console.ReadLine();
            }

            for (int rowIndex = 0; rowIndex < gardenRow; rowIndex++)
            {
                for (int colIndex = 0; colIndex < gardenCol; colIndex++)
                {
                    if (gardenMatrix[rowIndex, colIndex] == -1)
                    {

                        for (int row = 0; row < gardenRow; row++)
                        {
                            gardenResult[row, colIndex]++;
                        }
                        for (int col = 0; col < gardenCol; col++)
                        {
                            if (col != colIndex)
                            {
                                gardenResult[rowIndex, col]++;
                            }
                        }
                    }
                }
            }

            PrintGarden(gardenResult);
        }

        private static void PrintGarden(int[,] gardenResult)
        {
            var sb = new StringBuilder();

            for (int row = 0; row < gardenResult.GetLength(0); row++)
            {
                for (int col = 0; col < gardenResult.GetLength(1); col++)
                {
                    sb.Append(gardenResult[row, col]);
                    sb.Append(" ");
                }
                sb.Append("\n");
            }

            Console.WriteLine(sb);
        }
    }
}