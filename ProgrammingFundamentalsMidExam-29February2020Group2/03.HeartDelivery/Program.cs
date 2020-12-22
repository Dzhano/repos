using System;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToArray();
            string command = string.Empty;
            int position = 0;
            while ((command = Console.ReadLine()) != "Love!")
            {
                string[] data = command.Split();
                position += int.Parse(data[1]);
                if (position >= houses.Length) position = 0;
                if (houses[position] != 0) 
                {
                    houses[position] -= 2;
                    if (houses[position] == 0) 
                        Console.WriteLine($"Place {position} has Valentine's day.");
                } 
                else Console.WriteLine($"Place {position} already had Valentine's day.");
            }
            Console.WriteLine($"Cupid's last position was {position}.");
            int failedHouses = 0;
            foreach (int house in houses) if (house != 0) failedHouses++;
            if (failedHouses == 0) Console.WriteLine("Mission was successful.");
            else Console.WriteLine($"Cupid has failed {failedHouses} places.");
        }
    }
}
