using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            List<string> creators = new List<string>();
            List<string> teamNames = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("-");
                if (teamNames.Contains(input[1])) Console.WriteLine($"Team {input[1]} was already created!");
                if (creators.Contains(input[0])) Console.WriteLine($"{input[0]} cannot create another team!");
                if (!creators.Contains(input[0]) && !teamNames.Contains(input[1]))
                {
                    Team newTeam = new Team();
                    List<string> members = new List<string>();
                    newTeam.Creator = input[0];
                    members.Add(input[0]);
                    newTeam.Members = members;
                    newTeam.TeamName = input[1];
                    Console.WriteLine($"Team {input[1]} has been created by {input[0]}!");
                    teams.Add(newTeam);
                    creators.Add(input[0]);
                    teamNames.Add(input[1]);
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] data = command.Split("->");
                bool existingTeam = false;
                bool existingPerson = false;
                foreach (Team exist in teams)
                {
                    if (exist.TeamName == data[1]) existingTeam = true;
                    if (exist.Members.Contains(data[0])) existingPerson = true;
                }
                if (existingTeam)
                {
                    if (!existingPerson)
                    {
                        Team addInTeam = teams.Find(x => x.TeamName == data[1]);
                        addInTeam.Members.Add(data[0]);
                    }
                    else Console.WriteLine($"Member {data[0]} cannot join team {data[1]}!");
                }
                else Console.WriteLine($"Team {data[1]} does not exist!");
            }
            teams = teams.OrderBy(x => x.Members.Count).Reverse().ToList();
            List<string> disbanded = new List<string>();
            foreach (Team team in teams)
            {
                string creator = team.Creator;
                team.Members.Remove(creator);
                if (team.Members.Count == 0) disbanded.Add(team.TeamName);
                else
                {
                    Console.WriteLine(team.TeamName);
                    Console.WriteLine($"- {team.Creator}");
                    team.Members.Sort();
                    foreach (string member in team.Members) Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            disbanded.Sort();
            Console.WriteLine(string.Join(Environment.NewLine, disbanded));
        }
    }

    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
