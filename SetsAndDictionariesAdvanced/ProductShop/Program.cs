using System;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops 
                = new SortedDictionary<string, Dictionary<string, double>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] input = command.Split(", ");
                if (!shops.ContainsKey(input[0]))
                    shops.Add(input[0], new Dictionary<string, double>());
                if (!shops[input[0]].ContainsKey(input[1]))
                    shops[input[0]].Add(input[1], double.Parse(input[2]));
            }
            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
