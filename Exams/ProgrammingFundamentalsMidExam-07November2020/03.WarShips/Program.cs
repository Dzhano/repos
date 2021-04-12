using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WarShips
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();
            List<int> warShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();
            int maximumHealth = int.Parse(Console.ReadLine());
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Retire")
            {
                string[] input = command.Split();
                switch (input[0])
                {
                    case "Fire":
                        if (int.Parse(input[1]) < warShip.Count && int.Parse(input[1]) >= 0)
                        {
                            warShip[int.Parse(input[1])] -= int.Parse(input[2]);
                            if (warShip[int.Parse(input[1])] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;
                    case "Defend":
                        for (int i = int.Parse(input[1]); i <= int.Parse(input[2]); i++) 
                            if (i >= 0 && i < pirateShip.Count)
                            {
                                pirateShip[i] -= int.Parse(input[3]);
                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        break;
                    case "Repair":
                        if (int.Parse(input[1]) < pirateShip.Count && int.Parse(input[1]) >= 0) 
                        {
                            pirateShip[int.Parse(input[1])] += int.Parse(input[2]);
                            if (pirateShip[int.Parse(input[1])] > maximumHealth) 
                                pirateShip[int.Parse(input[1])] = maximumHealth;
                        }
                        break;
                    case "Status":
                        int counter = 0;
                        foreach (int section in pirateShip) 
                            if (section < 0.20 * maximumHealth) counter++;
                        Console.WriteLine($"{counter} sections need repair.");
                        break;
                }
            }
            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");
        }
    }
}
