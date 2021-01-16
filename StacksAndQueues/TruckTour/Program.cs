using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<PetrolPump> pumps = new Queue<PetrolPump>();
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
                PetrolPump newPump = new PetrolPump()
                {
                    Amount = input[0],
                    DistanceFromNext = input[1]
                };
                pumps.Enqueue(newPump);
            }
            int numberOfPump = 0;
            while (numberOfPump < pumps.Count)
            {
                int petrol = 0;
                foreach (PetrolPump pump in pumps)
                {
                    petrol += pump.Amount - pump.DistanceFromNext;
                    if (petrol < 0)
                    {
                        numberOfPump++;
                        break;
                    }
                }
                if (petrol < 0)
                {
                    PetrolPump correction = pumps.Dequeue();
                    pumps.Enqueue(correction);
                    petrol = 0;
                }
                else break;
            }
            Console.WriteLine(numberOfPump);
        }
    }

    class PetrolPump
    {
        public int Amount { get; set; }
        public int DistanceFromNext { get; set; }
    }
}
