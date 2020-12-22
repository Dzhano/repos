using System;

namespace BakingCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int participants = int.Parse(Console.ReadLine());
            int totalBaking = 0;
            double totalSum = 0;
            for (int i = 1; i <= participants; i++)
            {
                string playerName = Console.ReadLine();
                string baking = Console.ReadLine(); //"cookies","cakes", "waffles"
                int cookiesNumber = 0;
                int cakesNumber = 0;
                int wafflesNumber = 0;
                while (baking != "Stop baking!")
                {
                    int number = int.Parse(Console.ReadLine());
                    switch (baking)
                    {
                        case "cookies":
                            cookiesNumber += number;
                            break;
                        case "cakes":
                            cakesNumber += number;
                            break;
                        case "waffles":
                            wafflesNumber += number;
                            break;
                    }
                    baking = Console.ReadLine(); //"cookies","cakes", "waffles"
                }
                Console.WriteLine($"{playerName} baked {cookiesNumber} cookies, {cakesNumber} cakes and {wafflesNumber} waffles.");
                totalBaking += cookiesNumber + cakesNumber + wafflesNumber;
                totalSum += cookiesNumber * 1.50 + cakesNumber * 7.80 + wafflesNumber * 2.30;
            }
            Console.WriteLine($"All bakery sold: {totalBaking}");
            Console.WriteLine($"Total sum for charity: {totalSum:F2} lv.");
        }
    }
}
