using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadsets = 0;
            int trashedMouses = 0;
            int trashedKeyboards = 0;
            int trashedDisplays = 0;
            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 12 == 0)
                {
                    trashedHeadsets += 1;
                    trashedMouses += 1;
                    trashedKeyboards += 1;
                    trashedDisplays += 1;
                }
                else if (i % 6 == 0)
                {
                    trashedHeadsets += 1;
                    trashedMouses += 1;
                    trashedKeyboards += 1;
                }
                else if (i % 3 == 0)
                {
                    trashedMouses += 1;
                }
                else if (i % 2 == 0)
                {
                    trashedHeadsets += 1;
                }
            }
            double totalExpenses = headsetPrice * trashedHeadsets + mousePrice * trashedMouses + keyboardPrice * trashedKeyboards + displayPrice * trashedDisplays;
            Console.WriteLine($"Rage expenses: {totalExpenses:F2} lv.");
        }
    }
}
