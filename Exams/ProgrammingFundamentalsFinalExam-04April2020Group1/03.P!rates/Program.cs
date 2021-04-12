using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Place> cities = new Dictionary<string, Place>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] command = input.Split("||");
                if (cities.ContainsKey(command[0]))
                {
                    cities[command[0]].Population += int.Parse(command[1]);
                    cities[command[0]].Gold += int.Parse(command[2]);
                }
                else cities.Add(command[0], new Place() 
                { 
                    Population = int.Parse(command[1]),
                    Gold = int.Parse(command[2])
                });
            }
            string input2 = string.Empty;
            while ((input2 = Console.ReadLine()) != "End")
            {
                string[] data = input2.Split("=>");
                switch (data[0])
                {
                    case "Plunder":
                        cities[data[1]].Population -= int.Parse(data[2]);
                        cities[data[1]].Gold -= int.Parse(data[3]);
                        Console.WriteLine($"{data[1]} plundered! {data[3]} gold stolen, {data[2]} citizens killed.");
                        if (cities[data[1]].Population <= 0 || cities[data[1]].Gold <= 0)
                        {
                            Console.WriteLine($"{data[1]} has been wiped off the map!");
                            cities.Remove(data[1]);
                        }
                        break;
                    case "Prosper":
                        int gold = int.Parse(data[2]);
                        if (gold < 0) Console.WriteLine("Gold added cannot be a negative number!");
                        else
                        {
                            cities[data[1]].Gold += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. " +
                                $"{data[1]} now has {cities[data[1]].Gold} gold.");
                        }
                        break;
                }
            }
            if (cities.Count == 0) Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            else
            {
                cities = cities.OrderByDescending(x => x.Value.Gold)
                    .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var town in cities) Console.WriteLine($"{town.Key} -> " +
                    $"Population: {town.Value.Population} citizens, Gold: {town.Value.Gold} kg");
            }
        }
    }

    class Place
    {
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
