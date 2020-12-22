using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input.Split("/");
                if (data[0] == "Truck")
                {
                    catalog.Trucks.Add(new Truck
                    {
                        Brand = data[1],
                        Model = data[2],
                        Weight = data[3]
                    });
                }
                else if (data[0] == "Car")
                {
                    catalog.Cars.Add(new Car
                    {
                        Brand = data[1],
                        Model = data[2],
                        HorsePower = data[3]
                    });
                }
            }
            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine($"Cars:");
                foreach (Car car in catalog.Cars.OrderBy(car => car.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine($"Trucks:");
                foreach (Truck truck in catalog.Trucks.OrderBy(truck => truck.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    class Catalog
    {
        public List<Truck> Trucks;
        public List<Car> Cars;
        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }
}
