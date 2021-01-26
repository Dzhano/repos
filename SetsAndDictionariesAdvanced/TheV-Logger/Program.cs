using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vLogger = new Dictionary<string, Vlogger>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                if (command.Contains("joined"))
                {
                    string[] data = command.Split();
                    if (!vLogger.ContainsKey(data[0]))
                        vLogger.Add(data[0], new Vlogger()
                        {
                            Followers = new SortedSet<string>(),
                            Following = new SortedSet<string>()
                        });
                }
                else if (command.Contains("followed"))
                {
                    string[] data = command.Split(" followed ");
                    if (vLogger.ContainsKey(data[0]) &&
                        vLogger.ContainsKey(data[1]) && data[0] != data[1])
                    {
                        vLogger[data[0]].Following.Add(data[1]);
                        vLogger[data[1]].Followers.Add(data[0]);
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vLogger.Count} vloggers in its logs.");
            vLogger = vLogger.OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count)
                .ToDictionary(x => x.Key, x => x.Value);
            int number = 1;
            foreach (var vlogger in vLogger)
            {
                Console.WriteLine($"{number}. {vlogger.Key} : " +
                    $"{vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
                if (number == 1)
                {
                    foreach (string follower in vlogger.Value.Followers)
                        Console.WriteLine($"*  {follower}");
                }
                number++;
            }
        }
    }

    class Vlogger
    {
        public SortedSet<string> Followers { get; set; }
        public SortedSet<string> Following { get; set; }
    }
}
