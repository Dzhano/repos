using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            if (destination == "End")
            {
                Environment.Exit(0);
            }
            double neededBudget = double.Parse(Console.ReadLine());
            double budget = 0;
            while (destination != "End")
            {
                double savingMoney = double.Parse(Console.ReadLine());
                budget += savingMoney;
                if (budget >= neededBudget)
                {
                    Console.WriteLine($"Going to {destination}!");
                    destination = Console.ReadLine();
                    if (destination == "End")
                    {
                        break;
                    }
                    neededBudget = double.Parse(Console.ReadLine());
                    budget = 0;
                }
            }
        }
    }
}
