using System;

namespace SummerShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            double beachTowerPrice = double.Parse(Console.ReadLine());
            double dicount = double.Parse(Console.ReadLine());

            double umbrellaPrice = (beachTowerPrice * 2) / 3;
            double flipflopsPrice = (umbrellaPrice * 75) / 100;
            double beachBagPrice = (flipflopsPrice + beachTowerPrice) / 3;
            double totalPrice = beachTowerPrice + umbrellaPrice + flipflopsPrice + beachBagPrice;
            double totalPriceWithDiscount = totalPrice - (totalPrice * dicount) / 100;
            if (budget >= totalPriceWithDiscount)
            {
                Console.WriteLine($"Annie's sum is {totalPriceWithDiscount:F2} lv. She has {budget - totalPriceWithDiscount:F2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Annie's sum is {totalPriceWithDiscount:F2} lv. She needs {totalPriceWithDiscount - budget:F2} lv. more.");
            }
        }
    }
}
