using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] input = command.Split(":");
                contests.Add(input[0], input[1]);
            }
            SortedDictionary<string, Dictionary<string, int>> users 
                = new SortedDictionary<string, Dictionary<string, int>>();
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] input = command.Split("=>");
                if (contests.ContainsKey(input[0]))
                    if (contests[input[0]] == input[1])
                    {
                        if (!users.ContainsKey(input[2]))
                            users.Add(input[2], new Dictionary<string, int>());
                        if (!users[input[2]].ContainsKey(input[0]))
                            users[input[2]].Add(input[0], 0);
                        int points = int.Parse(input[3]);
                        if (users[input[2]][input[0]] < points)
                            users[input[2]][input[0]] = points;
                    }
            }
            Dictionary<string, int> people = new Dictionary<string, int>();
            foreach (var user in users)
            {
                people.Add(user.Key, 0);
                foreach (var course in user.Value)
                    people[user.Key] += course.Value;
            }
            people = people.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Best candidate is {people.First().Key} with total {people.First().Value} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Key);
                Dictionary<string, int> contestsPoints = 
                    user.Value.OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
                foreach (var contest in contestsPoints)
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
            }
        }
    }
}
