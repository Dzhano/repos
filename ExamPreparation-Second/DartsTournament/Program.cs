using System;
using System.Diagnostics.Tracing;

namespace DartsTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int begginingPoints = int.Parse(Console.ReadLine());
            int counter = 0;
            while (begginingPoints > 0)
            {
                string sector = Console.ReadLine(); //"number section", "double ring", "triple ring", "bullseye"
                counter++;
                if (sector == "bullseye")
                {
                    Console.WriteLine($"Congratulations! You won the game with a bullseye in {counter} moves!");
                    Environment.Exit(0);
                }
                int points = int.Parse(Console.ReadLine());
                switch (sector)
                {
                    case "number section":
                        points *= 1;
                        begginingPoints -= points;
                        break;
                    case "double ring":
                        points *= 2;
                        begginingPoints -= points;
                        break;
                    case "triple ring":
                        points *= 3;
                        begginingPoints -= points;
                        break;
                }
            }
            if (begginingPoints == 0)
            {
                Console.WriteLine($"Congratulations! You won the game in {counter} moves!");
            }
            else if (begginingPoints < 0)
            {
                int difference = Math.Abs(begginingPoints);
                Console.WriteLine($"Sorry, you lost. Score difference: {difference}.");
            }
        }
    }
}
