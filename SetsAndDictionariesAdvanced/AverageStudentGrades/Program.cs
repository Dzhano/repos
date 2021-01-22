using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (!grades.ContainsKey(input[0]))
                    grades.Add(input[0], new List<decimal>());
                grades[input[0]].Add(decimal.Parse(input[1]));
            }
            foreach (var student in grades)
            {
                Console.Write($"{student.Key} -> ");
                foreach (decimal grade in student.Value)
                    Console.Write($"{grade:F2} ");
                Console.WriteLine($"(avg: {student.Value.Average():F2})");
            }
        }
    }
}
