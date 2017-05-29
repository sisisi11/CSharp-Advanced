namespace _04.BasicQueueOperation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class BasicQueueOperation
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            int n = int.Parse(input[0]);
            int s = int.Parse(input[1]);
            int x = int.Parse(input[2]);

            foreach (var num in numbers)
            {
                queue.Enqueue(num);
            }

            while (s != 0)
            {
                queue.Dequeue();
                s--;
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int smallestNum = queue.Min();
                    Console.WriteLine(smallestNum);
                }
            }
        }
    }
}
