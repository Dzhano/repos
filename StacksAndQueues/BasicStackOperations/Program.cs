using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] conditions = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            int[] input = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < conditions[0]; i++)
                numbers.Push(input[i]);
            for (int i = 0; i < conditions[1]; i++)
                numbers.Pop();
            if (numbers.Count == 0) Console.WriteLine(0);
            else if (numbers.Contains(conditions[2])) Console.WriteLine("true");
            else Console.WriteLine(numbers.Min());
        }
    }
}
