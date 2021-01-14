using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();
            string name = string.Empty;
            while ((name = Console.ReadLine()) != "End")
            {
                if (name == "Paid")
                {
                    while (customers.Count > 0)
                        Console.WriteLine(customers.Dequeue());
                }
                else customers.Enqueue(name);
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
