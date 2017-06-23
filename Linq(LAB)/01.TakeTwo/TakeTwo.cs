namespace _01.TakeTwo
{
    using System;
    using System.Linq;

    class TakeTwo
    {
        static void Main()
        {
            var inputLine = Console.ReadLine().Split(' ').Select(w => w.ToUpper());
            Console.WriteLine(string.Join(" ", inputLine));
        }
    }
}
