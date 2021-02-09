using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] newCarInfo = Console.ReadLine().Split();
                Car newCar = new Car()
                {
                    Model = newCarInfo[0],
                    Engine = new Engine()
                    {
                        Speed = int.Parse(newCarInfo[1]),
                        Power = int.Parse(newCarInfo[2])
                    },
                    Cargo = new Cargo()
                    {
                        Weight = int.Parse(newCarInfo[3]),
                        Type = newCarInfo[4]
                    },
                    Tires = new Tire[4]
                    {
                        new Tire(double.Parse(newCarInfo[5]), int.Parse(newCarInfo[6])),
                        new Tire(double.Parse(newCarInfo[7]), int.Parse(newCarInfo[8])),
                        new Tire(double.Parse(newCarInfo[9]), int.Parse(newCarInfo[10])),
                        new Tire(double.Parse(newCarInfo[11]), int.Parse(newCarInfo[12])),
                    }
                };
                cars.Add(newCar);
            }
            string command = Console.ReadLine(); // "fragile" or "flamable"
            List<Car> typeCars = cars.Where(c => c.Cargo.Type == command).ToList();
            foreach (Car car in typeCars)
            {
                if (command == "fragile")
                {
                    if (car.Tires.Any(t => t.Pressure < 1))
                        Console.WriteLine(car.Model);
                }
                else if (command == "flamable")
                {
                    if (car.Engine.Power > 250)
                        Console.WriteLine(car.Model);
                }
            }
        }
    }
}
