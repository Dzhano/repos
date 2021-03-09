using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base (fuelQuantity, litersPerKm, tankCapacity)
        {
        }

        public void TurnOffAirconditioner()
        {
            LitersPerKm -= 1.4;
        }
        public void TurnOnAirconditioner()
        {
            LitersPerKm += 1.4;
        }
    }
}
