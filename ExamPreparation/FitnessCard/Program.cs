using System;

namespace FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            char sex = char.Parse(Console.ReadLine()); // 'm' или 'f'
            int yearsOld = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine(); // "Gym", "Boxing", "Yoga", "Zumba", "Dances", "Pilates"

            double price = 0;
            switch (sex)
            {
                case 'm':
                    switch (sport)
                    {
                        case "Gym":
                            price = 42;
                            break;
                        case "Boxing":
                            price = 41;
                            break;
                        case "Yoga":
                            price = 45;
                            break;
                        case "Zumba":
                            price = 34;
                            break;
                        case "Dances":
                            price = 51;
                            break;
                        case "Pilates":
                            price = 39;
                            break;
                    }
                    break;
                case 'f':
                    switch (sport)
                    {
                        case "Gym":
                            price = 35;
                            break;
                        case "Boxing":
                            price = 37;
                            break;
                        case "Yoga":
                            price = 42;
                            break;
                        case "Zumba":
                            price = 31;
                            break;
                        case "Dances":
                            price = 53;
                            break;
                        case "Pilates":
                            price = 37;
                            break;
                    }
                    break;
            }
            if (yearsOld <= 19)
            {
                price *= 0.8;
            }

            if (amount >= price)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${price - amount:F2} more.");
            }
        }
    }
}
