using System;
using System.Collections.Generic;

namespace Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> students = new List<Students>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] student = command.Split();
                if (IsStudentExisting(students, student[0], student[1]))
                {
                    Students human = GetStudent(students, student[0], student[1]);
                    human.FirstName = student[0];
                    human.LastName = student[1];
                    human.Age = int.Parse(student[2]);
                    human.HomeTown = student[3];
                }
                else
                {
                    Students person = new Students();
                    person.FirstName = student[0];
                    person.LastName = student[1];
                    person.Age = int.Parse(student[2]);
                    person.HomeTown = student[3];
                    students.Add(person);
                }
            }
            string city = Console.ReadLine();
            foreach (Students one in students)
            {
                if (one.HomeTown == city)
                {
                    Console.WriteLine($"{one.FirstName} {one.LastName} is {one.Age} years old.");
                }
            }
        }

        static bool IsStudentExisting(List<Students> students, string firstName, string lastName)
        {
            foreach (Students student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName) return true;
            }
            return false;
        }

        static Students GetStudent(List<Students> students, string firstName, string lastName)
        {
            Students exist = null;
            foreach (Students student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName) exist = student;
            }
            return exist;
        }
    }

    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
