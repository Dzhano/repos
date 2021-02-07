using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            /* 1.Car
            Car car = new Car();
            car.Make = "Ford";
            car.Model = "S-Max";
            car.Year = 2019;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
            */

            // 2.CarExtension
            Car car = new Car();
            car.Make = "Ford";
            car.Model = "S-Max";
            car.Year = 2019;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;
            car.Drive(2000);

            Console.WriteLine(car.WhoAmI());

            /* 3.CarConstructors
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
            */

            /* 4.CarEngineAndTires
            Tire[] tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)
            };
            Engine engine = new Engine(560, 6300);
            Car car = new Car("Ford", "S-Max", 2019, 250, 9, engine, tires);
            */

            /* 5.SpecialCars
            List<Tire[]> carsTires = new List<Tire[]>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                double[] infoTires = command.Split()
                    .Select(double.Parse).ToArray();
                Tire[] carTires = new Tire[4];
                int counter = 0;
                for (int i = 0; i < infoTires.Length; i += 2) 
                    carTires[counter++] = new Tire((int)infoTires[i], infoTires[i + 1]);
                carsTires.Add(carTires);
            }

            List<Engine> carsEngines = new List<Engine>();
            while ((command = Console.ReadLine()) != "Engines done")
            {
                double[] infoEngine = command.Split()
                    .Select(double.Parse).ToArray();
                Engine carEngine = new Engine((int)infoEngine[0], infoEngine[1]);
                carsEngines.Add(carEngine);
            }

            List<Car> cars = new List<Car>();
            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = command.Split();
                string carMake = carInfo[0];
                string carModel = carInfo[1];
                int carYear = int.Parse(carInfo[2]);
                double carFuelQuantity = double.Parse(carInfo[3]);
                double carFuelConsumption = double.Parse(carInfo[4]);
                Engine carEngine = carsEngines[int.Parse(carInfo[5])];
                Tire[] carTires = carsTires[int.Parse(carInfo[6])];
                Car newCar = new Car(carMake, carModel, carYear, 
                    carFuelQuantity, carFuelConsumption, carEngine, carTires);
                cars.Add(newCar);
            }
            foreach (Car car in cars)
            {
                if (car.Year >= 2017)
                    if (car.Engine.HorsePower > 330)
                    {
                        //double sumTirePressure = 0;      //Съкратен вариант на това.
                        //foreach (Tire tire in car.Tires)
                        //    sumTirePressure += tire.Pressure;
                        if (car.Tires.Sum(t => t.Pressure) >= 9 && car.Tires.Sum(t => t.Pressure) <= 10)
                        {
                            car.Drive(0.20);
                            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\n" +
                                $"Year: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                        }
                    }
            }
            */
        }
    }
}
