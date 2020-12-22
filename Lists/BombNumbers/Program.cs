using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] n = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == n[0])
                {
                    for (int pp = 0; pp < n[1]; pp++)
                    {
                        if (i - 1 >= 0)
                        {
                            numbers.RemoveAt(i - 1);
                            i--;
                        }
                    }
                    for (int ap = 0; ap < n[1]; ap++)
                    {
                        if (i + 1 < numbers.Count) numbers.RemoveAt(i + 1);
                    }
                    numbers.RemoveAt(i);
                    i--;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
