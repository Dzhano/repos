using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string feedback = Console.ReadLine();

            int nights = days - 1;
            double price = 0.0;
            switch (room) 
            {
                case "room for one person":
                    price = 18.00;
                    break;
                case "apartment":
                    price = 25.00;
                    if (nights < 10 && nights > 0)
                    {
                        price *= 0.7;
                    }
                    else if (nights >= 10 && nights <= 15)
                    {
                        price *= 0.65;
                    }
                    else
                    {
                        price *= 0.5;
                    }
                    break;
                case "president apartment":
                    price = 35.00;
                    if (nights < 10 && nights > 0)
                    {
                        price *= 0.9;
                    }
                    else if (nights >= 10 && nights <= 15)
                    {
                        price *= 0.85;
                    }
                    else
                    {
                        price *= 0.8;
                    }
                    break;
            }
            if (feedback == "positive")
            {
                price += price * 0.25;
            }
            else if (feedback == "negative")
            {
                price *= 0.9;
            }
            Console.WriteLine($"{price * nights:F2}");
        }
    }
}
