using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fishes;

        public Aquarium(string name, int capacity)
        {
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();

            Name = name;
            Capacity = capacity;
        }
        
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fishes;

        public void AddDecoration(IDecoration decoration) => decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (fishes.Count >= Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in fishes) 
                fish.Eat();
        }

        public string GetInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{Name} ({this.GetType().Name}):");

            if (fishes.Count == 0) builder.AppendLine("Fish: none");
            else builder.AppendLine($"Fish: {string.Join(", ", fishes.Select(f => f.Name))}");

            builder.AppendLine($"Decorations: {decorations.Count}");
            builder.AppendLine($"Comfort: {Comfort}");

            return builder.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish) => fishes.Remove(fish);
    }
}
