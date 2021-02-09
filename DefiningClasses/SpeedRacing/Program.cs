using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Car newCar = new Car();
                string[] carInfo = Console.ReadLine().Split();
                newCar.Model = carInfo[0];
                newCar.FuelAmount = double.Parse(carInfo[1]);
                newCar.FuelConsumptionPerKilometer = double.Parse(carInfo[2]);
                cars.Add(carInfo[0], newCar);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split();
                cars[data[1]].Drive(double.Parse(data[2]));
            }
            foreach (var car in cars)
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:F2} {car.Value.TravelledDistance}");
        }
    }
}
