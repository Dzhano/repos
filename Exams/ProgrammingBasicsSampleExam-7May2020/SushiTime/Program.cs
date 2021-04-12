using System;

namespace SushiTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushi = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            string order = Console.ReadLine();

            double price = 0;
            switch (sushi)
            {
                case "sashimi":
                    switch (restaurant)
                    {
                        case "Sushi Zone":
                            price = 4.99;
                            break;
                        case "Sushi Time":
                            price = 5.49;
                            break;
                        case "Sushi Bar":
                            price = 5.25;
                            break;
                        case "Asian Pub":
                            price = 4.50;
                            break;
                        default:
                            Console.WriteLine($"{restaurant} is invalid restaurant!");
                            return;
                    }
                    break;
                case "maki":
                    switch (restaurant)
                    {
                        case "Sushi Zone":
                            price = 5.29;
                            break;
                        case "Sushi Time":
                            price = 4.69;
                            break;
                        case "Sushi Bar":
                            price = 5.55;
                            break;
                        case "Asian Pub":
                            price = 4.80;
                            break;
                        default:
                            Console.WriteLine($"{restaurant} is invalid restaurant!");
                            return;
                    }
                    break;
                case "uramaki":
                    switch (restaurant)
                    {
                        case "Sushi Zone":
                            price = 5.99;
                            break;
                        case "Sushi Time":
                            price = 4.49;
                            break;
                        case "Sushi Bar":
                            price = 6.25;
                            break;
                        case "Asian Pub":
                            price = 5.50;
                            break;
                        default:
                            Console.WriteLine($"{restaurant} is invalid restaurant!");
                            return;
                    }
                    break;
                case "temaki":
                    switch (restaurant)
                    {
                        case "Sushi Zone":
                            price = 4.29;
                            break;
                        case "Sushi Time":
                            price = 5.19;
                            break;
                        case "Sushi Bar":
                            price = 4.75;
                            break;
                        case "Asian Pub":
                            price = 5.50;
                            break;
                        default:
                            Console.WriteLine($"{restaurant} is invalid restaurant!");
                            return;
                    }
                    break;
            }
            price *= number;
            switch (order)
            {
                case "Y":
                    price *= 1.2;
                    break;
                case "N":
                    price *= 1;
                    break;
            }
            double totalPrice = Math.Ceiling(price);
            Console.WriteLine($"Total price: {totalPrice} lv.");
        }
    }
}
