namespace _05.SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class SequenceWithQueue
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();

            List<long> results = new List<long>();
            queue.Enqueue(n);
            results.Add(n);

            while (results.Count < 50)
            {
                long currentElement = queue.Dequeue();

                long firstS = currentElement + 1;
                long secondS = (currentElement * 2) + 1;
                long thirdS = currentElement + 2;

                queue.Enqueue(firstS);
                queue.Enqueue(secondS);
                queue.Enqueue(thirdS);

                results.Add(firstS);
                results.Add(secondS);
                results.Add(thirdS);
            }
            for (int i = 0; i < 50; i++)
            {
                Console.Write($"{results[i]} ");
            }
        }
    }
}
