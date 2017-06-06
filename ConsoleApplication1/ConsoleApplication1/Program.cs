using System;

class BalancedBrackets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var lastBracket = string.Empty;
        var stringHelper = string.Empty;
        bool isTrue = false;

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            if (input == "(")
            {
                stringHelper += input;
                if (lastBracket == "(")
                {
                    isTrue = false;
                    break;
                }
                lastBracket = "(";
            }
            if (stringHelper.Length >= 2)
            {
                isTrue = false;
                break;
            }

            if (input.Equals(")"))
            {
                if (stringHelper != "(")
                {
                    isTrue = false;
                    break;
                }
                else
                {
                    isTrue = true;
                    stringHelper = string.Empty;
                }
                lastBracket = ")";
            }
        }
        if (lastBracket == "(")
        {
            isTrue = false;
        }
        if (isTrue)
        {
            Console.WriteLine("BALANCED");
        }
        else
        {
            Console.WriteLine("UNBALANCED");
        }

    }
}