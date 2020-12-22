using System;

namespace CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = Area(width, height);
            Console.WriteLine(area);
        }

        static double Area(double width, double height)
        {
            return width * height;
        }
    }
}
