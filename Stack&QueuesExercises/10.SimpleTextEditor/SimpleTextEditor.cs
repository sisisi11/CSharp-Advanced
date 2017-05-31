namespace _10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class SimpleTextEditor
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();

            stack.Push(string.Empty);
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                var typeOfCommand = input[0];

                switch (typeOfCommand)
                {
                    case "1":
                        {
                            var text = input[1];
                            var update = stack.Peek() + text;
                            stack.Push(update);
                            break;
                        }
                    case "2":
                        {
                            int count = int.Parse(input[1]);
                            var update = stack.Peek();
                            update = update.Remove(update.Length - count);
                            stack.Push(update);
                            break;
                        }
                    case "3":
                        int index = int.Parse(input[1]);
                        var lastUpdate = stack.Peek();
                        Console.WriteLine(lastUpdate[index - 1]);
                        break;

                    case "4":
                        {
                            stack.Pop();
                            break;
                        }
                }

            }
        }
    }
}
