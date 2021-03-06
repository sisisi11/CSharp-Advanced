﻿namespace _06.FilterStudentsByPhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class FilteringByPhone
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
                        Phone = tokens[2]
                    };
                })
                .ToList();

            students = students.Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592")).ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }
    }
}
