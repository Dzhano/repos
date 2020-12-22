using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int yearsLily = int.Parse(Console.ReadLine());
            double priceWM = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());
            
            double toysMoney = 0;
            double birthdayMoney = 0;
            double totalBirthdayMoney = 0;
            double totalMoney = 0;
            for (int i = 1; i <= yearsLily; i++)
            {
                if (i % 2 != 0)
                {
                    toysMoney = toysMoney + toysPrice;
                }
                else if (i % 2 == 0)
                {
                    birthdayMoney = birthdayMoney + 10;
                    totalBirthdayMoney = totalBirthdayMoney + birthdayMoney - 1;
                }
            }
            totalMoney = toysMoney + totalBirthdayMoney;
            if (totalMoney >= priceWM)
            {
                Console.WriteLine($"Yes! {totalMoney - priceWM:F2}");
            }
            else
            {
                Console.WriteLine($"No! {priceWM - totalMoney:F2}");
            }
        }
    }
}
