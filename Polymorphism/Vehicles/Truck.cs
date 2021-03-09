using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {    
        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity) 
            : base(fuelQuantity, litersPerKm + 1.6, tankCapacity)
        {
            
        }

        public override void Refueling(double fuelLiters)
        {
            if (fuelLiters <= 0)
                Console.WriteLine("Fuel must be a positive number");
            else
            {
                if (fuelLiters + FuelQuantity > TankCapacity)
                    Console.WriteLine($"Cannot fit {fuelLiters} fuel in the tank");
                else FuelQuantity += fuelLiters * 0.95;
            }
        }
    }
}
