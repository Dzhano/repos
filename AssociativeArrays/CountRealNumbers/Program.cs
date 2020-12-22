using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split().Select(double.Parse).ToArray();
            SortedDictionary<double, int> dictionary = 
                new SortedDictionary<double, int>();
            foreach (double num in numbers) 
                if (dictionary.ContainsKey(num)) dictionary[num]++;
                else dictionary.Add(num, 1);
            foreach (var number in dictionary) 
                Console.WriteLine($"{number.Key} -> {number.Value}");
        }
    }
}
