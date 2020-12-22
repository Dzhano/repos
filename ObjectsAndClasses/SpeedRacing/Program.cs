using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>(); 
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Car car = new Car();
                car.Model = input[0];
                car.FuelAmount = double.Parse(input[1]);
                car.FuelConsumptionPerKilometer = double.Parse(input[2]);
                cars.Add(car);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split();
                Car vehicle = cars.Find(x => x.Model == data[1]);
                if (vehicle.FuelConsumptionPerKilometer * double.Parse(data[2]) 
                    <= vehicle.FuelAmount)
                {
                    vehicle.FuelAmount -= vehicle.FuelConsumptionPerKilometer * double.Parse(data[2]);
                    vehicle.TraveledDistance += double.Parse(data[2]);
                }
                else Console.WriteLine("Insufficient fuel for the drive");
            }
            foreach (Car item in cars) 
                Console.WriteLine($"{item.Model} {item.FuelAmount:F2} {item.TraveledDistance}");
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }
    }
}
