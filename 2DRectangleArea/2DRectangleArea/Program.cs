using System;

namespace _2DRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double x12 = double.Parse(Console.ReadLine());
            double y12 = double.Parse(Console.ReadLine());
            double x21 = double.Parse(Console.ReadLine());
            double y21 = double.Parse(Console.ReadLine());

            double length = Math.Abs(x12 - x21);
            double width = Math.Abs(y12 - y21);

            double area = length * width;
            double perimeter = 2 * (length + width);

            Console.WriteLine($"{area:F2}");
            Console.WriteLine($"{perimeter:F2}");
        }
    }
}
