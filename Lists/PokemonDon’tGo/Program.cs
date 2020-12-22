using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int sum = 0;
            int num = 0;
            while (numbers.Count > 0)
            {
                int integer = int.Parse(Console.ReadLine());
                if (integer < 0)
                {
                    num = numbers[0];
                    sum += num;
                    numbers[0] = numbers[numbers.Count - 1];
                }
                else if (integer >= numbers.Count)
                {
                    num = numbers[numbers.Count - 1];
                    sum += num;
                    numbers[numbers.Count - 1] = numbers[0];
                }
                else
                {
                    num = numbers[integer];
                    numbers.RemoveAt(integer);
                    sum += num;
                }
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] > num) numbers[i] -= num;
                    else numbers[i] += num;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
