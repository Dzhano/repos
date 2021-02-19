using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split();
                people.Add(new Person(data[0], int.Parse(data[1]), data[2]));
            }
            int n = int.Parse(Console.ReadLine()) - 1;
            int matches = 0;
            foreach (Person person in people)
                if (people[n].CompareTo(person) == 0)
                    matches++;
            if (matches <= 1) Console.WriteLine("No matches");
            else Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
        }
    }
}
