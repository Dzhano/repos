using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;
        

        public Team (string name)
        {
            Name = name;
            players = new Dictionary<string, Player>();
        }


        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // равносилно е на: value == null || value == " " || value == ""
                    Console.WriteLine("A name should not be empty.");
                else name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (players.Count == 0) return 0;
                else return (int) Math.Round(players.Values.Average(pl => pl.SkillLevel));
            }
        }


        public void AddPlayer(Player player) => players.Add(player.Name, player);

        public void RemovePlayer(string playerName)
        {
            if (!players.ContainsKey(playerName))
                throw new InvalidOperationException($"Player {playerName} is not in {Name} team.");

            players.Remove(playerName);
        }
    }
}
