using System;
using System.Collections.Generic;

namespace FilterbyAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person() { Name = data[0], Age = int.Parse(data[1]) });
            }
            string condition = Console.ReadLine();   // "younger" or "older"
            int ageFilter = int.Parse(Console.ReadLine());
            Func<Person, bool> filter = Filter(condition, ageFilter);
            string format = Console.ReadLine();      // "name", "age" or "name age"
            Func<Person, string> formatter = Formatter(format);
            foreach (Person person in people)
                if (filter(person))
                    Console.WriteLine(formatter(person));
        }

        static Func<Person, bool> Filter (string condition, int ageFilter)
        {
            if (condition == "younger") return x => x.Age < ageFilter;
            else if (condition == "older") return x => x.Age >= ageFilter;
            else return null;
        }

        static Func<Person, string> Formatter (string format)
        {
            switch (format)
            {
                case "name":
                    return person => $"{person.Name}";
                case "age":
                    return person => $"{person.Age}";
                case "name age":
                    return person => $"{person.Name} - {person.Age}";
                default:
                    return null;
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
