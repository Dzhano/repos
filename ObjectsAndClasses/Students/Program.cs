using System;
using System.Collections.Generic;

namespace Students
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
                Students person = new Students();
                person.FirstName = student[0];
                person.LastName = student[1];
                person.Age = int.Parse(student[2]);
                person.HomeTown = student[3];
                students.Add(person);
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
    }

    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
