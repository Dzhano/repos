using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(input);
            int biggestOrder = input.Max();
            Console.WriteLine(biggestOrder);
            while (quantity > 0)
            {
                if (orders.Count == 0) break;
                int order = orders.Peek();
                if (quantity >= order)
                {
                    orders.Dequeue();
                    quantity -= order;
                }
                else break;
            }
            if (orders.Count == 0) Console.WriteLine("Orders complete");
            else
            {
                Console.Write("Orders left: ");
                while (orders.Count > 0)
                    Console.Write(orders.Dequeue() + " ");
            }
        }
    }
}
