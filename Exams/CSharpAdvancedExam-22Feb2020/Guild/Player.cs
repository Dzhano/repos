using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string @class)
        {
            Name = name;
            Class = @class;
            Rank = "Trial";
            Description = "n/a";
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public override string ToString() 
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Player {Name}: {Class}");
            builder.AppendLine($"Rank: {Rank}");
            builder.AppendLine($"Description: {Description}");
            return builder.ToString().TrimEnd();
        }
    }
}
