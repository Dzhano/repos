using System;
using System.Xml;

namespace LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());
            double l1 = Length(x1, y1, x2, y2);
            double l2 = Length(x3, y3, x4, y4);
            if (l2 <= l1)
            {
                double d1 = Diameter(x1, y1);
                double d2 = Diameter(x2, y2);
                if (d1 <= d2) Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                else Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
            else 
            {
                double d3 = Diameter(x3, y3);
                double d4 = Diameter(x4, y4);
                if (d3 <= d4) Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                else Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
            }
        }

        static double Length(double x1, double y1, double x2, double y2)
        {
            double x = Math.Abs(x1 - x2);
            double y = Math.Abs(y1 - y2);
            double result = Math.Sqrt(x * x + y * y);
            return result;
        }

        static double Diameter(double x, double y)
        {
            double result = Math.Sqrt(x * x + y * y);
            return result;
        }
    }
}
