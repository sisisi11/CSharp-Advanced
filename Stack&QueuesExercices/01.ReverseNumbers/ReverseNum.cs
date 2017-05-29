namespace _01.ReverseNumbers
{
    using System;
    using System.Linq;
    public class ReverseNum
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            Console.WriteLine(String.Join(" ", input.Reverse()));
        }
    }
}
