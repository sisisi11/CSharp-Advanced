namespace _02.CubicsRube
{
    using System;
    using System.Numerics;
    using System.Linq;

    class CubicsRube
    {
        static void Main()
        {
            // Create a three-dimensional array.
            long cubeSize = long.Parse(Console.ReadLine());

            var inputLine = Console.ReadLine();

            BigInteger bombedCellsSum = 0;

            long[,,] threeDimensional = new long[cubeSize, cubeSize, cubeSize];
            BigInteger totalCubeSize = cubeSize * cubeSize * cubeSize;

            while (inputLine != "Analyze")
            {
                var longLine = inputLine.Split(' ').Select(BigInteger.Parse).ToArray();

                var thirdDim = longLine[0];
                var row = longLine[1];
                var col = longLine[2];
                var particles = longLine[3];

                for (long i = 0; i < threeDimensional.GetLength(2); i++)
                {
                    for (long y = 0; y < threeDimensional.GetLength(1); y++)
                    {
                        for (long x = 0; x < threeDimensional.GetLength(0); x++)
                        {
                            if (i == thirdDim && y == row && x == col && threeDimensional[x,y,i] == 0)
                            {
                                if (particles == 0)
                                {

                                    threeDimensional[x, y, i] = 1;
                                }
                                else
                                {
                                    bombedCellsSum += particles;
                                    totalCubeSize--;
                                    threeDimensional[x, y, i] = 1;
                                }
                            }
                        }
                    }
                }

                inputLine = Console.ReadLine();
            }
            Console.WriteLine(bombedCellsSum);
            Console.WriteLine(totalCubeSize);
        }
    }
}