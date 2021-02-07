using System;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Predicate<string> cool = ime => ime.Length <= n;
            string[] names = Console.ReadLine().Split();
            foreach (string name in names) if (cool(name)) Console.WriteLine(name);
        }
    }
}
