using System;
using System.Collections.Generic;

namespace RawData
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
                car.Engine = new Engine();
                car.Engine.Speed = int.Parse(input[1]);
                car.Engine.Power = int.Parse(input[2]);
                car.Cargo = new Cargo();
                car.Cargo.Weight = int.Parse(input[3]);
                car.Cargo.Type = input[4];
                cars.Add(car);
            }
            string type = Console.ReadLine();
            foreach (Car vehicle in cars) 
                if (vehicle.Cargo.Type == type)
                {
                    if (type == "fragile")
                    {
                        if (vehicle.Cargo.Weight < 1000) Console.WriteLine(vehicle.Model);
                    }
                    else if (type == "flamable") 
                        if (vehicle.Engine.Power > 250) Console.WriteLine(vehicle.Model);
                }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }

    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }
    }   
    class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }
    }
}
