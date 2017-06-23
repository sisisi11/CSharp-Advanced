namespace _09.TextFilter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class TextFilter
    {
        static void Main()
        {
            var keyWords = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);

            var input = Console.ReadLine();

            for (int i = 0; i < keyWords.Length; i++)
            {
                var str = string.Empty;
                for (int j = 0; j < keyWords[i].Length; j++)
                {
                    str += "*";
                }
                if (input.Contains(keyWords[i]))
                {
                    input = input.Replace(keyWords[i], str);
                }
            }
            Console.WriteLine(input);
        }
    }
}
