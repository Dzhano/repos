using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalog = new List<Vehicle>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();
                Vehicle vehicle = new Vehicle();
                vehicle.Type = data[0];
                vehicle.Model = data[1];
                vehicle.Color = data[2];
                vehicle.HorsePower = int.Parse(data[3]);
                catalog.Add(vehicle);
            }
            string brand = string.Empty;
            while ((brand = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle model = catalog.Find(x => x.Model == brand);
                if (model.Type == "car") Console.WriteLine("Type: Car");
                else if (model.Type == "truck") Console.WriteLine("Type: Truck");
                Console.WriteLine($"Model: {model.Model}");
                Console.WriteLine($"Color: {model.Color}");
                Console.WriteLine($"Horsepower: {model.HorsePower}");
            }
            List<Vehicle> cars = catalog.Where(x => x.Type == "car").ToList();
            List<Vehicle> trucks = catalog.Where(x => x.Type == "truck").ToList();
            double carsAverageHorsepower = cars.Sum(x => x.HorsePower);
            double trucksAverageHorsepower = trucks.Sum(x => x.HorsePower);
            if (cars.Count > 1) carsAverageHorsepower /= cars.Count;
            if (trucks.Count > 1) trucksAverageHorsepower /= trucks.Count;
            Console.WriteLine($"Cars have average horsepower of: {carsAverageHorsepower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHorsepower:F2}.");
        }
    }

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
}
