namespace _07.ExcellentStudent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class ExcellentStudent
    {
        static void Main()
        {
            string inputLine = string.Empty;
            var lines = new List<string>();

            while ((inputLine = Console.ReadLine()) != "END")
            {
                lines.Add(inputLine);
            }

            var students = lines
               .Select(pair =>
               {
                   var tokens = pair.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                   return new
                   {
                       FirstName = tokens[0],
                       LastName = tokens[1],
                       Marks = tokens.Skip(2).Select(int.Parse).ToList()
                   };
               })
               .ToList();

            students = students.Where(s => s.Marks.Any(m => m == 6)).ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }
    }
}
