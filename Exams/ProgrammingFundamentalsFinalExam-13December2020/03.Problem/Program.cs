using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Follower> followers 
                = new Dictionary<string, Follower>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Log out")
            {
                string[] input = command.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                switch (input[0])
                {
                    case "New follower":
                        if (!followers.ContainsKey(input[1])) 
                            followers.Add(input[1], new Follower());
                        break;
                    case "Like":
                        if (!followers.ContainsKey(input[1]))
                            followers.Add(input[1], new Follower()
                            {
                                Likes = int.Parse(input[2])
                            });
                        else followers[input[1]].Likes += int.Parse(input[2]);
                        break;
                    case "Comment":
                        if (!followers.ContainsKey(input[1]))
                            followers.Add(input[1], new Follower()
                            {
                                Comments = 1
                            });
                        else followers[input[1]].Comments += 1;
                        break;
                    case "Blocked":
                        if (followers.ContainsKey(input[1])) followers.Remove(input[1]);
                        else Console.WriteLine($"{input[1]} doesn't exist.");
                        break;
                }
            }
            followers = followers
                .OrderByDescending(x => x.Value.Likes + x.Value.Comments)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"{followers.Count} followers");
            foreach (var follower in followers) 
                Console.WriteLine($"{follower.Key}: " +
                    $"{follower.Value.Likes + follower.Value.Comments}");
        }
    }

    class Follower
    {
        public int Likes { get; set; }
        public int Comments { get; set; }
    }
}
