namespace _02.StringLength
{
    using System;
    using System.Text;
    public class StringLength
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine().ToCharArray();
            var sb = new StringBuilder();
            if (inputLine.Length <= 19)
            {
                sb.Append(inputLine);
                for (int i = inputLine.Length; i < 20; i++)
                {
                    sb.Append('*');
                }
            }
            else if (inputLine.Length >= 20)
            {
                for (int i = 0; i < 20; i++)
                {
                    sb.Append(inputLine[i]);
                }
            }
            Console.WriteLine(string.Join("", sb));
        }
    }
}
