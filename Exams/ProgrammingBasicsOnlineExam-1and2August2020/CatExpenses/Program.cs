using System;

namespace CatExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            double bed = double.Parse(Console.ReadLine());
            double wc = double.Parse(Console.ReadLine());

            double food = 1.25 * wc;
            double toys = 0.50 * food;
            double vet = 1.10 * toys;
            double month = wc + food + toys + vet;
            double unpredictable = month * 0.05;
            double year = bed + 12 * (month + unpredictable);
            Console.WriteLine($"{year:F2} lv.");
        }
    }
}
