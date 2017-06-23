namespace _10.GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FN { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public int Group { get; set; }
        public List<int> Grades { get; set; }
        public string Name { get; set; }
    }

    class GoupByGroup
    {
        static void Main()
        {
            string line = string.Empty;
            var lines = new List<string>();

            while ((line = Console.ReadLine()) != "END")
            {
                lines.Add(line);
            }

            var students = lines
                .Select(pair =>
                {
                    var tokens = pair.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    return new Student
                    {
                        Name = tokens[0] + " " + tokens[1],
                        Group = int.Parse(tokens[2])
                    };
                })
                .ToList();

            var groups = students
                .GroupBy(s => s.Group)
                .Select(group =>
                    new {
                        Group = group.Key,
                        Students = group
                    })
                .OrderBy(group => group.Group)
                .ToList();

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Group} - {String.Join(", ", group.Students.Select(s => s.Name))}");
            }
        }
    }
}
