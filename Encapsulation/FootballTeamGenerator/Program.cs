using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] data = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    string teamName = data[1];
                    switch (data[0])
                    {
                        case "Team":
                            Team team = new Team(teamName);
                            teams.Add(teamName, team);
                            break;
                        case "Add":
                            if (!teams.ContainsKey(teamName))
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                                continue;
                            }
                            string name = data[2];
                            int endurance = int.Parse(data[3]);
                            int sprint = int.Parse(data[4]);
                            int dribble = int.Parse(data[5]);
                            int passing = int.Parse(data[6]);
                            int shooting = int.Parse(data[7]);

                            Player player = new Player(name, endurance, sprint, dribble, passing, shooting);
                            teams[teamName].AddPlayer(player);
                            break;
                        case "Remove":
                            string playerName = data[2];
                            teams[teamName].RemovePlayer(playerName);
                            break;
                        case "Rating":
                            if (!teams.ContainsKey(teamName))
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                                continue;
                            }
                            Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
