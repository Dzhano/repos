using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] data = command.Split();
                Predicate<string> criteria = Predicate(data[1], data[2]);
                for (int i = 0; i < guests.Count; i++)
                {
                    if (criteria(guests[i]))
                    {
                        switch (data[0])
                        {
                            case "Remove":
                                i--;
                                guests.RemoveAt(i + 1);
                                break;
                            case "Double":
                                guests.Insert(i + 1, guests[i]);
                                i++;
                                break;
                        }
                    }
                }
            }
            if (guests.Any()) Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            else Console.WriteLine("Nobody is going to the party!");
        }

        static Predicate<string> Predicate(string command, string criteria)
        {
            switch (command)
            {
                case "StartsWith":
                    return x => x.StartsWith(criteria);
                case "EndsWith":
                    return x => x.EndsWith(criteria);
                case "Length":
                    return x => x.Length == int.Parse(criteria);
                default:
                    return null;
            }
        }
    }
}
