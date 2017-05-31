namespace _02.BasicStackOperation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class BasicStackOperation
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            int n = int.Parse(input[0]);
            int s = int.Parse(input[1]);
            int x = int.Parse(input[2]);

            foreach (var num in numbers)
            {
                stack.Push(num);
            }

            while (s != 0)
            {
                stack.Pop();
                s--;
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int smallestNum = stack.Min();
                    Console.WriteLine(smallestNum);
                }
            }
        }
    }
}