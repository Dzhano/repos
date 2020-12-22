using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players
                = new Dictionary<string, Dictionary<string, int>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Season end")
            {
                if (input.Contains("vs"))
                {
                    string[] fighters = input.Split(" vs ");
                    if (players.ContainsKey(fighters[0]) && players.ContainsKey(fighters[1]))
                    {
                        int firstFighter = 0;
                        int secondFighter = 0;
                        foreach (var pool in players[fighters[0]]) 
                            foreach (var place in players[fighters[1]])
                                if (pool.Key == place.Key)
                                {
                                    firstFighter += pool.Value;
                                    secondFighter += place.Value;
                                    break;
                                }
                        if (firstFighter > secondFighter) players.Remove(fighters[1]);
                        else if (firstFighter < secondFighter) players.Remove(fighters[0]);
                    }
                }
                else
                {
                    string[] data = input.Split(" -> ");
                    if (players.ContainsKey(data[0]))
                    {
                        if (players[data[0]].ContainsKey(data[1]))
                        {
                            if (players[data[0]][data[1]] < int.Parse(data[2]))
                                players[data[0]][data[1]] = int.Parse(data[2]);
                        }
                        else players[data[0]].Add(data[1], int.Parse(data[2]));
                    }
                    else
                    {
                        players.Add(data[0], new Dictionary<string, int>());
                        players[data[0]].Add(data[1], int.Parse(data[2]));
                    }
                }
            }
            Dictionary<string, int> participants = new Dictionary<string, int>();
            foreach (var player in players)
            {
                participants.Add(player.Key, 0);
                foreach (var position in player.Value) 
                    participants[player.Key] += position.Value;
            }
            Dictionary<string, int> sortedParticipants = 
                participants.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var human in sortedParticipants)
            {
                Console.WriteLine($"{human.Key}: {human.Value} skill");
                Dictionary<string, int> sorted = 
                    players[human.Key].OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                foreach (var item in sorted) Console.WriteLine($"- {item.Key} <::> {item.Value}");
            }
        }
    }
}
