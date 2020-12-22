using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            List<double> num2 = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            List<double> result = new List<double>();
            for (int i = 0; i < Math.Min(numbers.Count, num2.Count); i++)
            {
                result.Add(numbers[i]);
                result.Add(num2[i]);
            }
            if (numbers.Count < num2.Count) result = Result(result, numbers, num2);
            else result = Result(result, num2, numbers);
            Console.WriteLine(string.Join(" ", result));
        }

        static List<double> Result(List<double> result, List<double> numbers, List<double> num2)
        {
            for (int i = numbers.Count; i < num2.Count; i++) result.Add(num2[i]);
            return result;
        }
    }
}
