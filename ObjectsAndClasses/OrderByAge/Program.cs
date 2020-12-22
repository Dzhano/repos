using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] human = command.Split();
                Person person = new Person();
                person.FirstName = human[0];
                person.ID = human[1];
                person.Age = int.Parse(human[2]);
                people.Add(person);
            }
            people = people.OrderBy(a => a.Age).ToList();
            foreach (Person one in people) Console.WriteLine($"{one.FirstName} with ID: {one.ID} is {one.Age} years old.");
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
