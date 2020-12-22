using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students
                = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (students.ContainsKey(student)) students[student].Add(grade);
                else students.Add(student, new List<double>() { grade });
            }
            Dictionary<string, double> goodStudents
                = new Dictionary<string, double>();
            foreach (var person in students) 
                if (person.Value.Sum() / person.Value.Count >= 4.50)
                    goodStudents.Add(person.Key, person.Value.Sum() / person.Value.Count);
            Dictionary<string, double> sortedGoodStudents = goodStudents
                .OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var student in sortedGoodStudents) Console.WriteLine($"{student.Key} -> {student.Value:F2}");
        }
    }
}
