using System;
using System.Collections.Generic;
using System.Linq;

namespace Students_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> students = new List<Students>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine().Split();
                Students person = new Students();
                person.FirstName = student[0];
                person.LastName = student[1];
                person.Grade = double.Parse(student[2]);
                students.Add(person);
            }
            students = students.OrderBy(a => a.Grade).Reverse().ToList();
            foreach (Students one in students) Console.WriteLine($"{one.FirstName} {one.LastName}: {one.Grade:F2}");
        }
    }
    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
}
