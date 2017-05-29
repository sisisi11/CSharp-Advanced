namespace _07.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class BalancedParentheses
    {
        static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            var stack = new Stack<char>();

            bool isBalanced = true;

            var openingCase = new char[] { '[', '{', '(' };

            for (int i = 0; i < input.Length; i++)
            {
                var currentBracket = input[i];

                if (openingCase.Contains(currentBracket))
                {
                    stack.Push(currentBracket);
                }
                else
                {
                    if (stack.Count() == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    var lastOpened = stack.Pop();
                    switch (currentBracket)
                    {
                        case ']':
                            if (lastOpened != '[')
                            {
                                isBalanced = false;
                            }
                            break;
                        case '}':
                            if (lastOpened != '{')
                            {
                                isBalanced = false;
                            }
                            break;
                        case ')':
                            if (lastOpened != '(')
                            {
                                isBalanced = false;
                            }
                            break;
                    }
                    if (!isBalanced)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
