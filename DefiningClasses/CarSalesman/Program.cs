using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine newEngine = new Engine();
                newEngine.Model = engineData[0];
                newEngine.Power = int.Parse(engineData[1]);
                if (engineData.Length == 3)
                {
                    bool displacementORefficiency = true; // Displacement
                    foreach (char item in engineData[2])
                    {
                        if (char.IsLetter(item)) 
                            displacementORefficiency = false; // Efficiency
                    }
                    if (displacementORefficiency) newEngine.Displacement = engineData[2];
                    else newEngine.Efficiency = engineData[2];
                }
                else if (engineData.Length == 4)
                {
                    newEngine.Displacement = engineData[2];
                    newEngine.Efficiency = engineData[3];
                }
                engines.Add(engineData[0], newEngine);
            }
            List<Car> cars = new List<Car>();
            int m = int.Parse(Console.ReadLine());
            for (int j = 0; j < m; j++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car newCar = new Car();
                newCar.Model = carData[0];
                newCar.Engine = engines[carData[1]];
                if (carData.Length == 3)
                {
                    bool weightORcolor = true; // Weight
                    foreach (char item in carData[2])
                    {
                        if (char.IsLetter(item))
                            weightORcolor = false; // Color
                    }
                    if (weightORcolor) newCar.Weight = carData[2];
                    else newCar.Color = carData[2];
                }
                else if(carData.Length == 4)
                {
                    newCar.Weight = carData[2];
                    newCar.Color = carData[3];
                }
                cars.Add(newCar);
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
