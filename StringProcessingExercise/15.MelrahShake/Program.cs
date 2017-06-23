
namespace _15.MelrahShake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    public class Program
    {
        static void Main()
        {
            //var inputLine = Console.ReadLine();
            //var pattern = Console.ReadLine();

            //Regex regex = new Regex(pattern);
            //MatchCollection matches = regex.Matches(inputLine);

            //foreach (var match in matches)
            //{
            //    Console.WriteLine("Shake it");
            //    pattern.Remove(pattern.Length / 2, 1);
            //}


            var inputLine = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (pattern.Length > 0) 
            {
                int firstIndex = inputLine.IndexOf(pattern);
                int lastIndex = inputLine.LastIndexOf(pattern);

                if (firstIndex == -1 || firstIndex == lastIndex)
                {
                    break;
                }
                inputLine = inputLine.Remove(lastIndex, pattern.Length);  // При изтриване на последно съвпадение, 
                                                                         //  индексите в началото не се променят
                inputLine = inputLine.Remove(firstIndex, pattern.Length);
                Console.WriteLine("Shaked it.");

               pattern = pattern.Remove(pattern.Length / 2, 1);
            }
            Console.WriteLine("No shake." + Environment.NewLine + inputLine);
        }
    }
}
