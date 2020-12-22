using System;

namespace CruiseShip
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeCruise = Console.ReadLine(); //"Mediterranean"; "Adriatic"; "Aegean"
            string typeCabin = Console.ReadLine(); //"standard cabin"; "cabin with balcony"; "apartment"
            int nights = int.Parse(Console.ReadLine());

            double price = 0;
            switch (typeCruise)
            {
                case "Mediterranean":
                    switch (typeCabin)
                    {
                        case "standard cabin":
                            price = 27.50;
                            break;
                        case "cabin with balcony":
                            price = 30.20;
                            break;
                        case "apartment":
                            price = 40.50;
                            break;
                    }
                    break;
                case "Adriatic":
                    switch (typeCabin)
                    {
                        case "standard cabin":
                            price = 22.99;
                            break;
                        case "cabin with balcony":
                            price = 25.00;
                            break;
                        case "apartment":
                            price = 34.99;
                            break;
                    }
                    break;
                case "Aegean":
                    switch (typeCabin)
                    {
                        case "standard cabin":
                            price = 23.00;
                            break;
                        case "cabin with balcony":
                            price = 26.60;
                            break;
                        case "apartment":
                            price = 39.80;
                            break;
                    }
                    break;
            }
            double totalPrice = price * 4 * nights;
            if (nights > 7)
            {
                totalPrice *= 0.75;
            }
            Console.WriteLine($"Annie's holiday in the {typeCruise} sea costs {totalPrice:F2} lv.");
        }
    }
}
