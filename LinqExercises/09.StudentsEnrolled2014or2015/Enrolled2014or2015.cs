namespace _09.StudentsEnrolled2014or2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Enrolled2014or2015
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (input != "END")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var enrollment = tokens[0];
                var marks = new List<int>();

                for (int i = 1; i < tokens.Length; i++)
                {
                    var mark = int.Parse(tokens[i]);
                    marks.Add(mark);
                }
                students.Add(new Student(enrollment, marks));

                input = Console.ReadLine();
            }

            students.Where(s => s.Enrollment.EndsWith("14") || s.Enrollment.EndsWith("15"))
                .ToList()
                .ForEach(st => Console.WriteLine(string.Join(" ", st.Marks)));
        }

        class Student
        {
            public Student(string enrollment, List<int> marks)
            {
                this.Enrollment = enrollment;
                this.Marks = marks;
            }

            public string Enrollment { get; set; }
            public ICollection<int> Marks { get; set; }
        }
    }
}

