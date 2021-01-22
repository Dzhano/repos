using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split(", ");
                if (data[0] == "IN")
                    parking.Add(data[1]);
                else if (data[0] == "OUT")
                    parking.Remove(data[1]);
            }
            if (parking.Count > 0) 
                Console.WriteLine(string.Join(Environment.NewLine, parking));
            else Console.WriteLine("Parking Lot is Empty");
        }
    }
}
