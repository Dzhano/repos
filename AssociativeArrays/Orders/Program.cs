using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> orders
                = new Dictionary<string, List<double>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] order = input.Split();
                if (orders.ContainsKey(order[0]))
                {
                    if (orders[order[0]][0] != double.Parse(order[1])) 
                        orders[order[0]][0] = double.Parse(order[1]);
                    orders[order[0]][1] += double.Parse(order[2]);
                }
                else orders.Add(order[0], 
                    new List<double>() { double.Parse(order[1]), double.Parse(order[2]) });
            }
            foreach (var item in orders) 
                Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):F2}");
        }
    }
}
