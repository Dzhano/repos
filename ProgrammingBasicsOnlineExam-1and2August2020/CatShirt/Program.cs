using System;

namespace CatShirt
{
    class Program
    {
        static void Main(string[] args)
        {
            double sleeve = double.Parse(Console.ReadLine());
            double frontPart = double.Parse(Console.ReadLine());
            string material = Console.ReadLine(); // "Linen", "Cotton", "Denim", "Twill" или "Flannel"
            string tie = Console.ReadLine(); // "Yes" или "No"

            double shirt = (sleeve + frontPart) * 2;
            shirt *= 1.10;
            shirt /= 100.0;
            switch (material)
            {
                case "Linen":
                    shirt *= 15;
                    break;
                case "Cotton":
                    shirt *= 12;
                    break;
                case "Denim":
                    shirt *= 20;
                    break;
                case "Twill":
                    shirt *= 16;
                    break;
                case "Flannel":
                    shirt *= 11;
                    break;
            }
            shirt += 10;
            switch (tie)
            {
                case "Yes":
                    shirt *= 1.20;
                    break;
                case "No":
                    shirt *= 1;
                    break;
            }
            Console.WriteLine($"The price of the shirt is: {shirt:F2}lv.");
        }
    }
}
