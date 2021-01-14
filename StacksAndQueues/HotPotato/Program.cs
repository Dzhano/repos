using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Queue<string> kids = new Queue<string>(input);
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            while (kids.Count > 1)
            {
                string kid = kids.Dequeue();
                if (counter == n)
                {
                    Console.WriteLine($"Removed {kid}");
                    counter = 0;
                }
                else kids.Enqueue(kid);
                counter++;
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
