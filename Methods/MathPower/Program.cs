using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            double result = Pow(number, power);
            Console.WriteLine(result);
        }

        static double Pow(double number, int power)
        {
            double result = Math.Pow(number, power);
            return result;
        }
    }
}
