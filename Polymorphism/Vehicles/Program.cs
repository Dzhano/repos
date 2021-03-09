using System;
using System.Linq;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] carInput = Console.ReadLine().Split()
                .Skip(1).Select(double.Parse).ToArray();
            Car car = new Car(carInput[0], carInput[1], carInput[2]);

            double[] truckInput = Console.ReadLine().Split()
                .Skip(1).Select(double.Parse).ToArray();
            Truck truck = new Truck(truckInput[0], truckInput[1], truckInput[2]);

            double[] busInput = Console.ReadLine().Split()
                .Skip(1).Select(double.Parse).ToArray();
            Bus bus = new Bus(busInput[0], busInput[1], busInput[2]);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                double param = double.Parse(input[2]);
                switch (input[0])
                {
                    case "Drive":
                        switch (input[1])
                        {
                            case "Car":
                                car.Driving(param);
                                break;
                            case "Truck":
                                truck.Driving(param);
                                break;
                            case "Bus":
                                bus.TurnOnAirconditioner();
                                bus.Driving(param);
                                bus.TurnOffAirconditioner();
                                break;
                        }
                        break;

                    case "DriveEmpty":
                        if (input[1] == "Bus") bus.Driving(param);
                        break;

                    case "Refuel":
                        switch (input[1])
                        {
                            case "Car":
                                car.Refueling(param);
                                break;
                            case "Truck":
                                truck.Refueling(param);
                                break;
                            case "Bus":
                                bus.Refueling(param);
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
