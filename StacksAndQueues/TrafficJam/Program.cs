using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int pass = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;
            string car = string.Empty;
            while ((car = Console.ReadLine()) != "end")
            {
                if (car == "green")
                {
                    for (int i = 0; i < pass; i++) 
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCars++;
                        }
                }
                else cars.Enqueue(car);
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
