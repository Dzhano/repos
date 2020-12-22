using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();     //Spring Summer Autumn Winter
            int numberFishermen = int.Parse(Console.ReadLine());
            double price = 0.0;
            switch (season)
            {
                case "Spring":
                    price = 3000;
                    if (numberFishermen >= 1 && numberFishermen <= 6)
                    {
                        price *= 0.90;
                    }
                    else if (numberFishermen >= 7 && numberFishermen <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (numberFishermen >= 12)
                    {
                        price *= 0.75;
                    }
                    break;
                case "Summer":
                case "Autumn":
                    price = 4200;
                    if (numberFishermen >= 1 && numberFishermen <= 6)
                    {
                        price *= 0.90;
                    }
                    else if (numberFishermen >= 7 && numberFishermen <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (numberFishermen >= 12)
                    {
                        price *= 0.75;
                    }
                    break;
                case "Winter":
                    price = 2600;
                    if (numberFishermen >= 1 && numberFishermen <= 6)
                    {
                        price *= 0.90;
                    }
                    else if (numberFishermen >= 7 && numberFishermen <= 11)
                    {
                        price *= 0.85;
                    }
                    else if (numberFishermen >= 12)
                    {
                        price *= 0.75;
                    }
                    break;
            }
            if (numberFishermen % 2 != 0 || season == "Autumn")
            {
                price *= 1;
            }
            else
            {
                price *= 0.95;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {budget - price:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {price - budget:F2} leva.");
            }
        }
    }
}
