namespace _04.AddVat
{
    using System;
    using System.Linq;
    public class AddVat
    {
        static void Main()
        {
            Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).
                Select(double.Parse).
                Select(n => n * 1.2).
                ToList().
                ForEach(n => Console.WriteLine("{0:f2}", n));
        }
    }
}