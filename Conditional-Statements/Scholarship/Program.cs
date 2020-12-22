using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageSuccees = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());

            double priceSS = Math.Floor(minimalSalary * 0.35);
            double priceSER = Math.Floor(averageSuccees * 25);

            if (income >= minimalSalary)
            {
                if (averageSuccees < 5.50)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {priceSER} BGN");
                }
            }
            else
            {
                if (averageSuccees < 5.50 && averageSuccees >= 4.50)
                {
                    Console.WriteLine($"You get a Social scholarship {priceSS} BGN");
                }
                else if (averageSuccees >= 5.50)
                {
                    if (priceSS > priceSER)
                    {
                        Console.WriteLine($"You get a Social scholarship {priceSS} BGN");
                    }
                    else
                    {
                        Console.WriteLine($"You get a scholarship for excellent results {priceSER} BGN");
                    }
                }
                else
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
            }
        }
    }
}
