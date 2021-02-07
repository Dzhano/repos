using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x)).ToArray();
            Func<double, string> vat = num => $"{(num * 1.20):F2}";
            foreach (double number in numbers)
                Console.WriteLine(vat(number));
        }
    }
}
