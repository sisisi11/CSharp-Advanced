namespace _14.LetterChangeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class LetterChangeNumber
    {
        static void Main()
        {
            var dict = new Dictionary<string, double>()
            {
                {"Aa" , 1},
                {"Bb" , 2},
                {"Cc" , 3},
                {"Dd" , 4},
                {"Ee" , 5},
                {"Ff" , 6},
                {"Gg" , 7},
                {"Hh" , 8},
                {"Ii" , 9},
                {"Jj" , 10},
                {"Kk" , 11},
                {"Ll" , 12},
                {"Mm" , 13},
                {"Nn" , 14},
                {"Oo" , 15},
                {"Pp" , 16},
                {"Qq" , 17},
                {"Rr" , 18},
                {"Ss" , 19},
                {"Tt" , 20},
                {"Uu" , 21},
                {"Vv" , 22},
                {"Ww" , 23},
                {"Xx" , 24},
                {"Yy" , 25},
                {"Zz" , 26}
            };
            var inputLine = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var lsit = new List<double>();
            double result = 0d;

            foreach (var word in inputLine)
            {
                var str = word.ToString();
                var firstLetter = str[0].ToString();
                double number = double.Parse(str.Substring(1, str.Length - 2));
                string lastLetter = str[str.Length - 1].ToString();

                if (firstLetter == firstLetter.ToUpper())
                {
                    firstLetter += firstLetter.ToLower();
                    if (dict.ContainsKey(firstLetter))
                    {
                        result = number / dict[firstLetter];
                    }
                    if (lastLetter == lastLetter.ToUpper())
                    {
                        lastLetter += lastLetter.ToLower();
                        if (dict.ContainsKey(lastLetter))
                        {
                            result -= dict[lastLetter];
                        }
                    }
                    else if (lastLetter == lastLetter.ToLower())
                    {
                        lastLetter = lastLetter.ToUpper() + lastLetter;
                        if (dict.ContainsKey(lastLetter))
                        {
                            result += dict[lastLetter];
                        }
                    }
                    lsit.Add(result);
                }
                if (firstLetter == firstLetter.ToLower())
                {
                    firstLetter = firstLetter.ToUpper() + firstLetter;
                    if (dict.ContainsKey(firstLetter))
                    {
                        result = number * dict[firstLetter];
                    }
                    if (lastLetter == lastLetter.ToUpper())
                    {
                        lastLetter += lastLetter.ToLower();
                        if (dict.ContainsKey(lastLetter))
                        {
                            result -= dict[lastLetter];
                        }
                    }
                    else if (lastLetter == lastLetter.ToLower())
                    {
                        lastLetter = lastLetter.ToUpper() + lastLetter;
                        if (dict.ContainsKey(lastLetter))
                        {
                            result += dict[lastLetter];
                        }
                    }
                    lsit.Add(result);
                }
            }
            Console.WriteLine($"{lsit.Sum():f2}");
        }
    }
}
