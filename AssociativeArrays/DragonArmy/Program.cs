using System;
using System.Collections.Generic;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, Dragon>> dragons
                = new Dictionary<string, SortedDictionary<string, Dragon>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (dragons.ContainsKey(input[0]))
                {
                    if (dragons[input[0]].ContainsKey(input[1])) 
                        dragons[input[0]][input[1]] = Status(dragons[input[0]][input[1]], input);
                    else
                    {
                        dragons[input[0]].Add(input[1], new Dragon());
                        dragons[input[0]][input[1]] = Status(dragons[input[0]][input[1]], input);
                    }
                }
                else
                {
                    dragons.Add(input[0], new SortedDictionary<string, Dragon>());
                    dragons[input[0]].Add(input[1], new Dragon());
                    dragons[input[0]][input[1]] = Status(dragons[input[0]][input[1]], input);
                }
            }
            foreach (var type in dragons)
            {
                double averageDamage = 0;
                int counter = 0;
                double averageHealth = 0;
                double averageArmor = 0;
                foreach (var item in type.Value)
                {
                    averageDamage += item.Value.Damage;
                    counter++;
                    averageHealth += item.Value.Health;
                    averageArmor += item.Value.Armor;
                }
                Console.WriteLine($"{type.Key}::({(averageDamage / counter):F2}/" +
                    $"{(averageHealth / counter):F2}/{(averageArmor / counter):F2})");
                foreach (var dragon in type.Value) 
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.Damage}, " +
                         $"health: {dragon.Value.Health}, armor: {dragon.Value.Armor}");
            }
        }

        static Dragon Status(Dragon dragon, string[] input)
        {
            if (input[2] == "null") dragon.Damage = 45;
            else dragon.Damage = int.Parse(input[2]);

            if (input[3] == "null") dragon.Health = 250;
            else dragon.Health = int.Parse(input[3]);

            if (input[4] == "null") dragon.Armor = 10;
            else dragon.Armor = int.Parse(input[4]);
            return dragon;
        }
    }

    class Dragon
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }
}
