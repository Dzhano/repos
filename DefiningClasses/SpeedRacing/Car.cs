using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car()
        {
            TravelledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double distance)
        {
            double usedFuel = FuelConsumptionPerKilometer * distance;
            if (FuelAmount - usedFuel >= 0)
            {
                FuelAmount -= usedFuel;
                TravelledDistance += distance;
            }
            else Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
