using System;

namespace TailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double tablecloths = tables * (length + 2 * 0.30) * (width + 2 * 0.30);
            double carriage = tables * (length / 2) * (length / 2);

            double usd = tablecloths * 7 + carriage * 9;
            double bgn = usd * 1.85;

            Console.WriteLine($"{usd:F2} USD");
            Console.WriteLine($"{bgn:F2} BGN");
        }
    }
}
