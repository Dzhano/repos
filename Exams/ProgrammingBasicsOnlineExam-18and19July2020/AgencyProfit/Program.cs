using System;

namespace AgencyProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int adultTickets = int.Parse(Console.ReadLine());
            int kidTickets = int.Parse(Console.ReadLine());
            double adultTicketsPrice = double.Parse(Console.ReadLine());
            double servicePrice = double.Parse(Console.ReadLine());

            double kidTicketsPrice = 0.30 * adultTicketsPrice;
            adultTicketsPrice += servicePrice;
            kidTicketsPrice += servicePrice;
            double totalPrice = (adultTickets * adultTicketsPrice) + (kidTickets * kidTicketsPrice);
            totalPrice *= 0.2;
            Console.WriteLine($"The profit of your agency from {name} tickets is {totalPrice:F2} lv.");
        }
    }
}
