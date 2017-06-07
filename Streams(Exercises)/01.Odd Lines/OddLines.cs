namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"../../textFile.txt"))
            {
                string line = reader.ReadLine();
                int counter = 1;
                while (line != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
