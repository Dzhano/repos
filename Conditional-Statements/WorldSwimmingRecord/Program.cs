using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());

            double timeIvan = meters * time;
            double resistance = Math.Floor(meters / 15);
            double extraTime = resistance * 12.5;
            double totalTime = timeIvan + extraTime;

            if (record > totalTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(totalTime - record):F2} seconds slower.");
            }
        }
    }
}
