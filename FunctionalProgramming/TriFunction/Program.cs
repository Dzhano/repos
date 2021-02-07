using System;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string, int, bool> function = (a, b) =>
            {
                int sum = 0;
                foreach (char item in a)
                    sum += item;
                if (sum < b) return false;
                else return true;
            };
            Func<string[], Func<string, int, bool>, string> mainFunction =
                (x, y) =>
                {
                    foreach (string item in x)
                        if (y(item, n)) return item;
                    return null;
                };
            Console.WriteLine(mainFunction(names, function));
        }
    }
}
