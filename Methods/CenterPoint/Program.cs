using System;

namespace CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double d1 = Diameter(x1, y1);
            double d2 = Diameter(x2, y2);
            if (d2 < d1) Console.WriteLine($"({x2}, {y2})");
            else Console.WriteLine($"({x1}, {y1})");
        }

        static double Diameter(double x, double y)
        {
            double result = Math.Sqrt(x * x + y * y);
            return result;
        }
    }
}
