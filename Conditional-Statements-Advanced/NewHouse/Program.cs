using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int flowersQuantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0.0;
            switch (flowersType)
            {
                case "Roses":
                    price = flowersQuantity * 5;
                    if (flowersQuantity > 80)
                    {
                        price *= 0.90;
                    }
                    break;
                case "Dahlias":
                    price = flowersQuantity * 3.80;
                    if (flowersQuantity > 90)
                    {
                        price *= 0.85;
                    }
                    break;
                case "Tulips":
                    price = flowersQuantity * 2.80;
                    if (flowersQuantity > 80)
                    {
                        price *= 0.85;
                    }
                    break;
                case "Narcissus":
                    price = flowersQuantity * 3;
                    if (flowersQuantity < 120)
                    {
                        price *= 1.15;
                    }
                    break;
                case "Gladiolus":
                    price = flowersQuantity * 2.50;
                    if (flowersQuantity < 80)
                    {
                        price *= 1.20;
                    }
                    break;
            }
            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersQuantity} {flowersType} and {budget - price:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {price - budget:F2} leva more.");
            }
        }
    }
}
