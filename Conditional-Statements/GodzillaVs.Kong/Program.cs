using System;

namespace GodzillaVs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double priceForClothesForstatist = double.Parse(Console.ReadLine());

            double priceDecor = budget * 0.10;
            double clothesPrice = statists * priceForClothesForstatist;
            if (statists > 150)
            {
                clothesPrice -= clothesPrice * 0.10;
            }
            double totalPrice = priceDecor + clothesPrice;
            if (totalPrice > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(totalPrice - budget):F2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(budget - totalPrice):F2} leva left.");
            }
        }
    }
}
