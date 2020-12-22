using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            int volumeFishTank = length * width * height;
            double liter = volumeFishTank * 0.001;
            double allPercentage = percentage * 0.01;
            double actualLiter = liter * (1 - allPercentage);

            Console.WriteLine($"{actualLiter:F3}");
        }
    }
}
