using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(bulletsInput);
            int[] locksInput = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(locksInput);
            int intelligencevalue = int.Parse(Console.ReadLine());
            int counter = 0;
            while (true)
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else Console.WriteLine("Ping!");
                bullets.Pop();
                counter++;
                if (counter % gunBarrelSize == 0 && bullets.Any()) Console.WriteLine("Reloading!");
                if (!locks.Any())
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligencevalue - (bulletPrice * counter)}");
                    break;
                }
                else if (!bullets.Any())
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
            }
        }
    }
}
