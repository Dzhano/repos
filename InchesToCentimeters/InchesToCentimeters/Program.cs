using System;

namespace InchesToCentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberInch = double.Parse(Console.ReadLine());
            double numberCentimeters = numberInch * 2.54;

            Console.WriteLine($"{numberCentimeters}");
        }
    }
}
