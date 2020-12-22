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
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] data = input.Split(":");
                contests.Add(data[0], data[1]);
            }
            Dictionary<string, Dictionary<string, int>> users
                = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> participants = new Dictionary<string, int>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] info = command.Split("=>");
                if (contests.ContainsKey(info[0]))
                {
                    if (contests[info[0]] == info[1])
                    {
                        if (users.ContainsKey(info[0]))
                        {
                            if (users[info[0]].ContainsKey(info[2]))
                            {
                                if (users[info[0]][info[2]] < int.Parse(info[3]))
                                {
                                    participants[info[2]] -= users[info[0]][info[2]];
                                    users[info[0]][info[2]] = int.Parse(info[3]);
                                    participants[info[2]] += int.Parse(info[3]);
                                }
                            }
                            else
                            {
                                users[info[0]].Add(info[2], int.Parse(info[3]));
                                if (participants.ContainsKey(info[2]))
                                    participants[info[2]] += int.Parse(info[3]);
                                else participants.Add(info[2], int.Parse(info[3]));
                            }
                        }
                        else
                        {
                            users.Add(info[0], new Dictionary<string, int>());
                            users[info[0]].Add(info[2], int.Parse(info[3]));
                            if (participants.ContainsKey(info[2]))
                                participants[info[2]] += int.Parse(info[3]);
                            else participants.Add(info[2], int.Parse(info[3]));
                        }
                    }
                }
            }
            Dictionary<string, int> reversed = participants.OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in reversed)
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value} points.");
                break;
            }
            Dictionary<string, int> sor =  participants.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Dictionary<string, Dictionary<string, int>> participantsContests
                = new Dictionary<string, Dictionary<string, int>>();
            Console.WriteLine("Ranking: ");
            foreach (var human in sor)
            {
                participantsContests.Add(human.Key, new Dictionary<string, int>());
                foreach (var contest in users) 
                    if (contest.Value.ContainsKey(human.Key))
                        participantsContests[human.Key].Add(contest.Key, contest.Value[human.Key]);
                Dictionary<string, int> sorted = 
                    participantsContests[human.Key]
                    .OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine(human.Key);
                foreach (var course in sorted) Console.WriteLine($"#  {course.Key} -> {course.Value}");
            }
        }
    }
}
