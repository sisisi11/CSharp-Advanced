namespace _01.StudentResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StudentResult
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Format("{0, -10}|{1, 7}|{2, 7}|{3, 7}|{4, 7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));
            for (int i = 0; i < number; i++)
            {
                var inputLine = Console.ReadLine().Split(new string[] { ", " , " - "}, StringSplitOptions.RemoveEmptyEntries);
                string name = inputLine[0];
                float cSharpMark = float.Parse(inputLine[1]);
                float cOppMark = float.Parse(inputLine[2]);
                float advOppMark = float.Parse(inputLine[3]);
                float avarage = (cSharpMark + cOppMark + advOppMark) / 3.00f;
               
                Console.WriteLine(string.Format("{0, -10}|{1, 7:F2}|{2, 7:F2}|{3, 7:F2}|{4, 7:F4}|", name, cSharpMark, cOppMark, advOppMark, avarage));
            }
        }
    }
}
