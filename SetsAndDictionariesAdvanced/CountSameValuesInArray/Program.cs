using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> values = new Dictionary<double, int>();
            double[] input = Console.ReadLine().Split()
                .Select(double.Parse).ToArray();
            foreach (double number in input)
            {
                if (!values.ContainsKey(number))
                    values.Add(number, 0);
                values[number]++;
            }
            foreach (var value in values)
                Console.WriteLine($"{value.Key} - {value.Value} times");
        }
    }
}
