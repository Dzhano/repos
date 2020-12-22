using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double holidayPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int teddies = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double price = puzzles * 2.60 + dolls * 3 + teddies * 4.10 + minions * 8.20 + trucks * 2;
            int toys = puzzles + dolls + teddies + minions + trucks;
            if (toys >= 50)
            {
                price -= price * 0.25;
            }
            price -= price * 0.10;
            if (price >= holidayPrice)
            {
                Console.WriteLine($"Yes! {(price - holidayPrice):F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(holidayPrice - price):F2} lv needed.");
            }
        }
    }
}
