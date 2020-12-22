using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses
                = new Dictionary<string, List<string>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] course = input.Split(" : ");
                if (courses.ContainsKey(course[0])) courses[course[0]].Add(course[1]);
                else courses.Add(course[0], new List<string>() { course[1] });
            }
            Dictionary<string, List<string>> sorted = courses.
                OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);
            foreach (var course in sorted)
            {
                List<string> people = course.Value.OrderBy(x => x).ToList();
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (string student in people) Console.WriteLine($"-- {student}");
            }
        }
    }
}
