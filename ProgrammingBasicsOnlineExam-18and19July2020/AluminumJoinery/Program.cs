using System;

namespace AluminumJoinery
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();  // "90X130" или "100X150" или "130X180" или "200X300"
            string delivery = Console.ReadLine(); // "With delivery" или "Without delivery" 

            double price = 0;
            switch (type)
            {
                case "90X130":
                    price = 110 * number;
                    if (number > 60)
                    {
                        price *= 0.92;
                    }
                    else if (number > 30)
                    {
                        price *= 0.95;
                    }
                    break;
                case "100X150":
                    price = 140 * number;
                    if (number > 80)
                    {
                        price *= 0.90;
                    }
                    else if (number > 40)
                    {
                        price *= 0.94;
                    }
                    break;
                case "130X180":
                    price = 190 * number;
                    if (number > 50)
                    {
                        price *= 0.88;
                    }
                    else if (number > 20)
                    {
                        price *= 0.93;
                    }
                    break;
                case "200X300":
                    price = 250 * number;
                    if (number > 50)
                    {
                        price *= 0.86;
                    }
                    else if (number > 25)
                    {
                        price *= 0.91;
                    }
                    break;
            }
            switch (delivery)
            {
                case "With delivery":
                    price += 60;
                    break;
                case "Without delivery":
                    price += 0;
                    break;
            }
            if (number > 99)
            {
                price *= 0.96;
            }
            if (number < 10)
            {
                Console.WriteLine("Invalid order");
            }
            else
            {
                Console.WriteLine($"{price:F2} BGN");
            }
        }
    }
}
