using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                    fuelQuantity = 0;
                else fuelQuantity = value;
            }
        }

        private double litersPerKm;
        public double LitersPerKm
        {
            get => litersPerKm;
            set => litersPerKm = value;
        }

        public Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.LitersPerKm = litersPerKm;
            this.FuelQuantity = fuelQuantity;
        }

        public double TankCapacity { get; set; }

        public void Driving(double distance) 
        {
            double result = FuelQuantity - (distance * LitersPerKm);
            if (result >= 0)
            {
                FuelQuantity -= distance * LitersPerKm;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        public virtual void Refueling(double fuelLiters)
        {
            if (fuelLiters <= 0)
                Console.WriteLine("Fuel must be a positive number");
            else
            {
                if (fuelLiters + FuelQuantity > TankCapacity)
                    Console.WriteLine($"Cannot fit {fuelLiters} fuel in the tank");
                else FuelQuantity += fuelLiters;
            }
        }
    }
}
