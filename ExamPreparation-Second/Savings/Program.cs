using System;

namespace Savings
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double neededPrice = double.Parse(Console.ReadLine());

            double personal = (30 * income) / 100;
            double savings = income - (neededPrice + personal);
            double totalSavings = months * savings;
            double savingsProcent = savings * 100 / income;
            Console.WriteLine($"She can save {savingsProcent:F2}%");
            Console.WriteLine($"{totalSavings:F2}");
        }
    }
}
