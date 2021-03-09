using Raiding.Heroes;
using System;
using System.Collections.Generic;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            for (int i = n; i > 0; i--)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();
                switch (heroType)
                {
                    case "Druid":
                        heroes.Add(new Druid(name));
                        break;
                    case "Paladin":
                        heroes.Add(new Paladin(name));
                        break;
                    case "Rogue":
                        heroes.Add(new Rogue(name));
                        break;
                    case "Warrior":
                        heroes.Add(new Warrior(name));
                        break;
                    default:
                        i++;
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }
            int villainPower = int.Parse(Console.ReadLine());

            int totalHeroPower = 0;
            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                totalHeroPower += hero.Power;
            }

            if (totalHeroPower < villainPower) Console.WriteLine("Defeat...");
            else Console.WriteLine("Victory!");
        }
    }
}
