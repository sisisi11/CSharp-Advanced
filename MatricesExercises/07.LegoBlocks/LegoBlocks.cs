namespace _07.LegoBlocks
{
    using System;
    using System.Linq;
    public class LegoBlocks
    {
        public static void Main()
        {
            int rowNumbers = int.Parse(Console.ReadLine());

            var firstMatrix = new int[rowNumbers][];
            var secondMatrix = new int[rowNumbers][];

            for (int i = 0; i < rowNumbers; i++)
            {
                firstMatrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).ToArray();
            }
            for (int i = 0; i < rowNumbers; i++)
            {
                secondMatrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                                    Select(int.Parse).ToArray();
            }
            var isFit = true;

            var firstRow = firstMatrix[0].Length + secondMatrix[0].Length;

            for (int i = 1; i < rowNumbers; i++)
            {
                var nextRow = firstMatrix[i].Length + secondMatrix[i].Length;
                if (firstRow != nextRow)
                {
                    isFit = false;
                    break;
                }
            }
            if (isFit)
            {
                for (int row = 0; row < firstMatrix.Length; row++)
                {
                    Console.Write($"[{string.Join(", ", firstMatrix[row])}");
                    Array.Reverse(secondMatrix[row]);
                    Console.WriteLine($", {string.Join(", ", secondMatrix[row])}]");

                }
            }
            else
            {
                var firstNumbersOfCell = firstMatrix.Select(f => f.GetLength(0)).Sum();
                var secondNumberOfCell = secondMatrix.Select(f => f.GetLength(0)).Sum();
                Console.WriteLine($"The total number of cells is: {firstNumbersOfCell + secondNumberOfCell}");

            }
        }
    }
}
