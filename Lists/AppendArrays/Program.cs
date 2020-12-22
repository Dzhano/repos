using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arrays = Console.ReadLine()
                .Split("|")
                .ToList();
            arrays.Reverse();
            List<string> result = new List<string>();
            foreach (string array in arrays)
            {
                string[] numbers = array
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
                foreach (string item in numbers) result.Add(item);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
