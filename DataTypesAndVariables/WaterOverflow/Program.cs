using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int tankCapacity = 255;
            for (int i = 1; i <= n; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                if (tankCapacity - liters < 0)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                tankCapacity -= liters;
            }
            Console.WriteLine(255 - tankCapacity);
        }
    }
}
