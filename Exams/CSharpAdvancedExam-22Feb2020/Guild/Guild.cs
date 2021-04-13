using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>(Capacity);
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        private List<Player> roster;
        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity) roster.Add(player);
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player == null) return false;
            return roster.Remove(player);
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player.Rank != "Member") player.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player.Rank != "Trial") player.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] kickedPlayers = roster.Where(p => p.Class == @class).ToArray();
            foreach (Player player in kickedPlayers) roster.Remove(player);
            return kickedPlayers;
        }

        public string Report()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Players in the guild: {Name}");
            foreach (Player player in roster) builder.AppendLine(player.ToString());
            return builder.ToString().TrimEnd();
        }
    }
}
