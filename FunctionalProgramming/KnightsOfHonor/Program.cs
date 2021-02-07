using System;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = w => Console.WriteLine("Sir " + w);
            string[] input = Console.ReadLine().Split();
            foreach (string word in input)
                action(word);
        }
    }
}
