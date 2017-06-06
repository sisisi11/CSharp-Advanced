using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace _05.ConcatStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class ConcatStrings
    {
        static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            for (int index = 0; index < count; index++)
            {
                sb.Append(Console.ReadLine()).Append(" ");
            }
            Console.WriteLine(sb);
        }
    }
}
