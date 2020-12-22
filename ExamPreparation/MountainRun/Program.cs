using System;

namespace MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timeMeter = double.Parse(Console.ReadLine());

            double time = meters * timeMeter;
            double extraTime = Math.Floor(meters / 50);
            extraTime *= 30;
            double totalTime = time + extraTime;
            if (totalTime < record)
            {
                Console.WriteLine($"Yes! The new record is {totalTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {totalTime - record:F2} seconds slower.");
            }
        }
    }
}
