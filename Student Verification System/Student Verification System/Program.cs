using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Verification_System
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int n = int.Parse(Console.ReadLine());
            if (n > 50)
            {
                Console.WriteLine("Too many new students at once!");
                return;
            }
            string errorMessage = "Unacceptable input. Not all information is presented or it is misplaced. Please try again.";
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (!(input.Length == 4) || !(input[3].Length == 1))
                {
                    Console.WriteLine(errorMessage);
                    i--;
                    continue;
                }

                string name = input[0];
                string lastName = input[1];

                switch (input[2])
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                    case "11":
                    case "12":
                        break;
                    default:
                        Console.WriteLine(errorMessage);
                        i--;
                        continue;
                }
                int grade = int.Parse(input[2]);

                char gradeType = input[3][0];
                switch (gradeType)
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        break;
                    default:
                        Console.WriteLine(errorMessage);
                        i--;
                        continue;
                }

                Student newStudent = new Student(name, lastName, grade, gradeType);
                students.Add(newStudent);
            }

            students = students.OrderBy(x => x.Grade).ThenBy(x => x.Type).ThenBy(x => x.Name).ThenBy(x => x.LastName).ToList();

            if (n == 0) Console.WriteLine("No new students...");
            else if (n > 0)
            {
                Console.WriteLine("Students:");
                foreach (Student student in students)
                    Console.WriteLine(student.ToString());
            }
        }
    }
}
