using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(input);
            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRack = rackCapacity;
            int racks = 1;
            while (clothes.Count > 0)
            {
                int dress = clothes.Pop();
                if (currentRack >= dress) currentRack -= dress;
                else
                {
                    racks++;
                    currentRack = rackCapacity - dress;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
