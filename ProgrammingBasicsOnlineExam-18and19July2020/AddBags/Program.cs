using System;

namespace AddBags
{
    class Program
    {
        static void Main(string[] args)
        {
            double luggage20Price = double.Parse(Console.ReadLine());
            double luggageKilos = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int luggages = int.Parse(Console.ReadLine());

            double price = 0;
            if (luggageKilos < 10)
            {
                price = 0.20 * luggage20Price;
            }
            else if (luggageKilos >= 10 && luggageKilos <= 20)
            {
                price = 0.50 * luggage20Price;
            }
            else
            {
                price = luggage20Price;
            }
            if (days > 30)
            {
                price *= 1.10;
            }
            else if (days >= 7 && days <= 30)
            {
                price *= 1.15;
            }
            else
            {
                price *= 1.40;
            }
            price *= luggages;
            Console.WriteLine($"The total price of bags is: {price:F2} lv.");
        }
    }
}
