using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> people = new List<Citizen>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);
                Citizen person = new Citizen(name, country, age);
                people.Add(person);
            }

            foreach (Citizen citizen in people)
            {
                IPerson person = citizen;
                Console.WriteLine(person.GetName());
                IResident resident = citizen;
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
