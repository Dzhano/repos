using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine(); //summer & winter

            string destination = "";
            string holiday = "";
            if (budget >= 1 && budget <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        budget *= 0.30;
                        holiday = "Camp";
                        break;
                    case "winter":
                        budget *= 0.70;
                        holiday = "Hotel";
                        break;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        budget *= 0.40;
                        holiday = "Camp";
                        break;
                    case "winter":
                        budget *= 0.80;
                        holiday = "Hotel";
                        break;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                budget *= 0.90;
                holiday = "Hotel";
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{holiday} - {budget:F2}");
        }
    }
}
