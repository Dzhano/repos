﻿using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string bestKeg = string.Empty;
            double bestVolume = 0;
            for (int i = 1; i <= n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volume = Math.PI * radius * radius * height;
                if (volume > bestVolume)
                {
                    bestKeg = model;
                    bestVolume = volume;
                }
            }
            Console.WriteLine(bestKeg);
        }
    }
}
