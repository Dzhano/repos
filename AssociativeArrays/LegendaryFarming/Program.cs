using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                for (int i = 0; i < input.Length; i += 2)
                {
                    if (materials.ContainsKey(input[i + 1].ToLower()))
                    {
                        materials[input[i + 1].ToLower()] += int.Parse(input[i]);
                        bool check = Checking(materials, input[i + 1].ToLower());
                        if (check) return;
                    }
                    else 
                    {
                        materials.Add(input[i + 1].ToLower(), int.Parse(input[i]));
                        bool check2 = Checking(materials, input[i + 1].ToLower());
                        if (check2) return;
                    }
                }
            }
        }

        static bool Checking(Dictionary<string, int> materials, string element)
        {
            if (materials[element] >= 250)
            {
                if (element == "shards")
                    Console.WriteLine("Shadowmourne obtained!");
                else if (element == "fragments")
                    Console.WriteLine("Valanyr obtained!");
                else if (element == "motes")
                    Console.WriteLine("Dragonwrath obtained!");
                else return false;
                materials[element] -= 250;
                if (materials.ContainsKey("shards") == false) materials.Add("shards", 0);
                if (materials.ContainsKey("fragments") == false) materials.Add("fragments", 0);
                if (materials.ContainsKey("motes") == false) materials.Add("motes", 0);
                Dictionary<string, int> keyMaterials = materials.Where(x => x.Key == "shards"
                || x.Key == "fragments" || x.Key == "motes").ToDictionary(x => x.Key, x => x.Value);
                Dictionary<string, int> sorted = keyMaterials.OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                materials.Remove("shards");
                materials.Remove("fragments");
                materials.Remove("motes");
                Dictionary<string, int> sorted2 
                    = materials.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                foreach (var item in sorted) Console.WriteLine($"{item.Key}: {item.Value}");
                foreach (var item in sorted2) Console.WriteLine($"{item.Key}: {item.Value}");
                return true;
            }
            else return false;
        }
    }
}
