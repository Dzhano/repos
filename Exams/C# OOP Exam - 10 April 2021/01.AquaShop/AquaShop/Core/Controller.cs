using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case "SaltwaterAquarium":
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            switch (decorationType)
            {
                case "Ornament":
                    decorations.Add(new Ornament());
                    break;
                case "Plant":
                    decorations.Add(new Plant());
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            bool fresh = false;

            IFish fish = null;
            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    fresh = true;
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            switch (aquarium.GetType().Name.ToString())
            {
                case "FreshwaterAquarium":
                    if (fresh)
                    {
                        aquarium.AddFish(fish);
                        return string.Format(OutputMessages.EntityAddedToAquarium, "FreshwaterFish", aquariumName);
                    }
                    break;
                case "SaltwaterAquarium":
                    if (!fresh)
                    {
                        aquarium.AddFish(fish);
                        return string.Format(OutputMessages.EntityAddedToAquarium, "SaltwaterFish", aquariumName);
                    }
                    break;
            }
            return OutputMessages.UnsuitableWater;
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal value = aquarium.Decorations.Sum(d => d.Price);
            value += aquarium.Fish.Sum(f => f.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            int count = 0;

            foreach (IFish fish in aquarium.Fish)
            {
                fish.Eat();
                count++;
            }

            return string.Format(OutputMessages.FishFed, count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            if (decoration == null) 
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));

            decorations.Remove(decoration);
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            aquarium.AddDecoration(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            foreach (IAquarium aquarium in aquariums) report.AppendLine(aquarium.GetInfo());
            return report.ToString().TrimEnd();
        }
    }
}
