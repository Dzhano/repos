using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string imputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();

            if (imputUnit == "mm" && outputUnit == "cm")
            {
                number = number / 10;
            }
            else if (imputUnit == "mm" && outputUnit == "m")
            {
                number = number / 1000;
            }
            else if (imputUnit == "cm" && outputUnit == "mm")
            {
                number = number * 10;
            }
            else if (imputUnit == "cm" && outputUnit == "m")
            {
                number = number / 100;
            }
            else if (imputUnit == "m" && outputUnit == "mm")
            {
                number = number * 1000;
            }
            else if (imputUnit == "m" && outputUnit == "cm")
            {
                number = number * 100;
            }
            Console.WriteLine($"{number:F3}");
        }
    }
}
