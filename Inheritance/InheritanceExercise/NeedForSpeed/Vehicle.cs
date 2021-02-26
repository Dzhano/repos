using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsepower, double fuel)
        {
            HorsePower = horsepower;
            Fuel = fuel;
        }

        private const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual void Drive(double kilometers)
        {
            Fuel -= FuelConsumption * kilometers;
        }
    }
}
