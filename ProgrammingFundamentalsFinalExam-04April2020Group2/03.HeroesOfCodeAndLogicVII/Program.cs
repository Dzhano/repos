using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                if (int.Parse(data[1]) > 100) data[1] = "100";
                if (int.Parse(data[2]) > 200) data[2] = "200";
                heroes.Add(data[0], new Hero() 
                {
                    HP = int.Parse(data[1]),
                    MP = int.Parse(data[2])
                });
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" - ");
                switch (input[0])
                {
                    case "CastSpell":
                        if (heroes[input[1]].MP >= int.Parse(input[2]))
                        {
                            heroes[input[1]].MP -= int.Parse(input[2]);
                            Console.WriteLine($"{input[1]} has successfully cast {input[3]} and now has {heroes[input[1]].MP} MP!");
                        }
                        else Console.WriteLine($"{input[1]} does not have enough MP to cast {input[3]}!");
                        break;
                    case "TakeDamage":
                        heroes[input[1]].HP -= int.Parse(input[2]);
                        if (heroes[input[1]].HP > 0)
                            Console.WriteLine($"{input[1]} was hit for {input[2]} HP " +
                                $"by {input[3]} and now has {heroes[input[1]].HP} HP left!");
                        else 
                        {
                            Console.WriteLine($"{input[1]} has been killed by {input[3]}!");
                            heroes.Remove(input[1]);
                        } 
                        break;
                    case "Recharge":
                        int added = 200;
                        if (heroes[input[1]].MP + int.Parse(input[2]) > 200) 
                        {
                            added -= heroes[input[1]].MP;
                            heroes[input[1]].MP = 200;
                        }
                        else
                        {
                            heroes[input[1]].MP += int.Parse(input[2]);
                            added = int.Parse(input[2]);
                        }
                        Console.WriteLine($"{input[1]} recharged for {added} MP!");
                        break;
                    case "Heal":
                        int better = 100;
                        if (heroes[input[1]].HP + int.Parse(input[2]) > 100) 
                        {
                            better -= heroes[input[1]].HP;
                            heroes[input[1]].HP = 100;
                        }
                        else
                        {
                            heroes[input[1]].HP += int.Parse(input[2]);
                            better = int.Parse(input[2]);
                        }
                        Console.WriteLine($"{input[1]} healed for {better} HP!");
                        break;
                }
            }
            Dictionary<string, Hero> sorted = heroes
                .OrderByDescending(x => x.Value.HP)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var hero in sorted)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }
    }

    class Hero
    {
        public int HP { get; set; }
        public int MP { get; set; }
    }
}
