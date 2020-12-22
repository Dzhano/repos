using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int animals = int.Parse(Console.ReadLine());
            double price = (dogs * 2.50) + (animals * 4);
            Console.WriteLine($"{price:F2} lv.");
        }
    }
}
