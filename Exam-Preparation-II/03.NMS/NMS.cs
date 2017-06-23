namespace _03.NMS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class NMS
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            var pattern = "[A|a]*[B|b]*[C|c]*[D|d]*[E|e]*[F|f]*[G|g]*[H|h]*[I|i]*[J|j]*[K|k]*[L|l]*[M|m]*[N|n]*[O|o]*[P|p]*[Q|q]*[R|r]*[S|s]*[T|t]*[U|u]*[V|v]*[W|w]*[X|x]*[Y|y]*[Z|z]*";

            var sb = new StringBuilder();
            while (inputLine != "---NMS SEND---")
            {
                sb.Append(inputLine);
                
                inputLine = Console.ReadLine();
            }
            var separator = Console.ReadLine();

            var strInput = sb.ToString();
            var lastLetter = strInput.Last();

            var regex = new Regex(pattern);
            var matches = regex.Matches(strInput);

            var result = new StringBuilder();

            foreach (var match in matches)
            {
                result.Append(match);
                result.Append(separator);
            }

            var strResult = result.ToString();
            strResult = strResult.Remove(strResult.LastIndexOf(lastLetter) + 1);

            Console.WriteLine(strResult);
        }
    }
}
