namespace _02.LadyBugs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class LadyBug
    {
        static void Main()
        {
            var sizeOfList = int.Parse(Console.ReadLine());
            int[] bugField = new int[sizeOfList];

            var bugsPositionInField = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var commandLine = Console.ReadLine();

            while (commandLine != "end")
            {
                var commandArgs = commandLine.Split(' ').ToArray();
                var bugIndex = int.Parse(commandArgs[0]);
                var directinToMove = commandArgs[1];
                var flyLength = int.Parse(commandArgs[2]);

                for (int index = 0; index < bugsPositionInField.Length; index++)
                {
                    bugField[bugsPositionInField[index]] = -1;
                }

                switch (directinToMove)
                {
                    case "left":
                        for (int i = bugIndex; i < bugField.Length; i++)
                        {
                            if (bugField[bugIndex] == -1)
                            {
                                while (bugField[i - flyLength] == -1)
                                {
                                    bugField[bugIndex] = 0;
                                    i--;
                                }
                                bugField[i] = -1;
                            }
                        }
                        break;

                    case "right":

                        break;
                }

                commandLine = Console.ReadLine();
            }
            Console.WriteLine();
        }
    }
}
