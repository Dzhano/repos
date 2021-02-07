using System;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bound = Console.ReadLine().Split()
                .Select(x => int.Parse(x)).ToArray();
            string command = Console.ReadLine();  // "even" or "odd"
            Predicate<int> correct = x =>
            {
                if (command == "even") return x % 2 == 0;
                else return x % 2 != 0;
            };
            for (int i = bound[0]; i <= bound[1]; i++)
                if (correct(i)) Console.Write(i + " ");
        }
    }
}
