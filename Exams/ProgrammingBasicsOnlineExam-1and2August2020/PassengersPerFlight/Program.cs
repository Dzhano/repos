using System;
using System.ComponentModel.DataAnnotations;

namespace PassengersPerFlight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double mostPassengers = -9999999;
            string bestAirline = "";
            for (int i = 1; i <= n; i++)
            {
                double totalPassengers = 0;
                int counter = 0;
                string airline = Console.ReadLine();
                string command = Console.ReadLine();
                while (command != "Finish")
                {
                    int passengers = int.Parse(command);
                    counter += 1;
                    totalPassengers += passengers;
                    command = Console.ReadLine();
                }
                double averagePassengers = Math.Floor(totalPassengers / counter);
                Console.WriteLine($"{airline}: {averagePassengers} passengers.");
                if (averagePassengers > mostPassengers)
                {
                    bestAirline = airline;
                    mostPassengers = averagePassengers;
                }
            }
            Console.WriteLine($"{bestAirline} has most passengers per flight: {mostPassengers}");
        }
    }
}
