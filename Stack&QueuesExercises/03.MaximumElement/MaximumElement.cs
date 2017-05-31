namespace _03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class MaximumElement
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxNumbers = new Stack<int>();
            int maxNumber = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (input.Length > 1)
                {
                    int x = input[1];

                    stack.Push(x);
                    if (x >= maxNumber)
                    {
                        maxNumber = x;
                        maxNumbers.Push(maxNumber);
                    }
                }
                else
                {
                    if (input[0] == 2)
                    {
                        int elementAtTop = stack.Pop();
                        int currentMax = maxNumbers.Peek();
                        if (elementAtTop == currentMax)
                        {
                            maxNumbers.Pop();
                            if (maxNumbers.Count > 0)
                            {
                                maxNumber = maxNumbers.Peek();
                            }
                        }
                    }
                    else if (input[0] == 3)
                    {
                        Console.WriteLine(maxNumbers.Peek());
                    }
                }
            }
        }
    }
}