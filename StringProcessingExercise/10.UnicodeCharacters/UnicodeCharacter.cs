using System.Linq;
using System.Text;

namespace _10.UnicodeCharacters
{
    using System;
    public class UnicodeCharacter
    {
        static void Main()
        {
            //var input = Console.ReadLine().ToCharArray();
            //string result = string.Empty;
            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (input[i] == ' ')
            //    {
            //        continue;  
            //    }
            //    result += "\\u" + ((int)input[i]).ToString("x4").ToLower();
            //}

            //Console.WriteLine(result);

            var input = Console.ReadLine();

            var sb = new StringBuilder();

            foreach (var ch in input)
            {
                sb.Append("\\u");
                sb.Append(String.Format("{0:x4}", (int)ch));
            }
            Console.WriteLine(string.Join("", sb.ToString()));
        }
    }
}
