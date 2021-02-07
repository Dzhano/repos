using System;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = w => Console.WriteLine(w);
            string[] input = Console.ReadLine().Split();
            foreach (string word in input)
                action(word);
        }
    }
}
