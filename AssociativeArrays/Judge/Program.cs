using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests
                = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> participants = new Dictionary<string, int>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] data = input.Split(" -> ");
                if (contests.ContainsKey(data[1]))
                {
                    if (contests[data[1]].ContainsKey(data[0]))
                    {
                        if (contests[data[1]][data[0]] < int.Parse(data[2]))
                        {
                            participants[data[0]] -= contests[data[1]][data[0]];
                            contests[data[1]][data[0]] = int.Parse(data[2]);
                            participants[data[0]] += int.Parse(data[2]);
                        }
                    }
                    else
                    {
                        contests[data[1]].Add(data[0], int.Parse(data[2]));
                        if (participants.ContainsKey(data[0]))
                            participants[data[0]] += int.Parse(data[2]);
                        else participants.Add(data[0], int.Parse(data[2]));
                    }
                }
                else
                {
                    contests.Add(data[1], new Dictionary<string, int>());
                    contests[data[1]].Add(data[0], int.Parse(data[2]));
                    if (participants.ContainsKey(data[0])) 
                        participants[data[0]] += int.Parse(data[2]);
                    else participants.Add(data[0], int.Parse(data[2]));
                }
            }
            int counter = 1;
            foreach (var contest in contests)
            {
                Dictionary<string, int> people = contest.Value.OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                counter = 1;
                foreach (var human in people)
                {
                    Console.WriteLine($"{counter}. {human.Key} <::> {human.Value}");
                    counter++;
                }
            }
            Console.WriteLine("Individual standings:");
            Dictionary<string, int> sortedParticipants = participants
                .OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            counter = 1;
            foreach (var user in sortedParticipants)
            {
                Console.WriteLine($"{counter}. {user.Key} -> {user.Value}");
                counter++;
            }
        }
    }
}
