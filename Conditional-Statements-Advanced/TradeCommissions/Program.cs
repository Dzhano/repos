using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sells = double.Parse(Console.ReadLine());
            double percent = 0.0;

            if (city == "Sofia")
            {
                if (sells >= 0 && sells <= 500)
                {
                    percent = 0.05;
                }
                else if (sells <= 1000)
                {
                    percent = 0.07;
                }
                else if (sells <= 10000)
                {
                    percent = 0.08;
                }
                else if (sells > 10000)
                {
                    percent = 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Varna")
            {
                if (sells >= 0 && sells <= 500)
                {
                    percent = 0.045;
                }
                else if (sells <= 1000)
                {
                    percent = 0.075;
                }
                else if (sells <= 10000)
                {
                    percent = 0.10;
                }
                else if (sells > 10000)
                {
                    percent = 0.13;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Plovdiv")
            {
                if (sells >= 0 && sells <= 500)
                {
                    percent = 0.055;
                }
                else if (sells <= 1000)
                {
                    percent = 0.08;
                }
                else if (sells <= 10000)
                {
                    percent = 0.12;
                }
                else if (sells > 10000)
                {
                    percent = 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            if (sells * percent > 0)
            {
                Console.WriteLine($"{sells * percent:F2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
