using System;

namespace ExcursionSale
{
    class Program
    {
        static void Main(string[] args)
        {
            int seaTrips = int.Parse(Console.ReadLine());
            int mountainTrips = int.Parse(Console.ReadLine());

            int profit = 0;
            string tripType = Console.ReadLine(); // "sea" или "mountain"
            while (tripType != "Stop")
            {
                switch (tripType)
                {
                    case "sea":
                        if (seaTrips != 0)
                        {
                            profit += 680;
                            seaTrips -= 1;
                        }
                        break;
                    case "mountain":
                        if (mountainTrips != 0)
                        {
                            profit += 499;
                            mountainTrips -= 1;
                        }
                        break;
                }
                if (seaTrips == 0 && mountainTrips == 0)
                {
                    Console.WriteLine("Good job! Everything is sold.");
                    break;
                }
                tripType = Console.ReadLine(); // "sea" или "mountain"
            }
            Console.WriteLine($"Profit: {profit} leva.");
        }
    }
}
