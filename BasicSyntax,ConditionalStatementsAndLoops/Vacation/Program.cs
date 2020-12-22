using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string type = Console.ReadLine(); // "Students", "Business" or "Regular"
            string day = Console.ReadLine(); // "Friday", "Saturday" or "Sunday"

            double price = 0;
            double totalPrice = 0;
            if (type == "Students")
            {
                if (day == "Friday")
                {
                    price = 8.45;
                }
                else if (day == "Saturday")
                {
                    price = 9.80;
                }
                else if (day == "Sunday")
                {
                    price = 10.46;
                }
                totalPrice = people * price;
                if (people >= 30)
                {
                    totalPrice *= 0.85;
                }
            }
            else if (type == "Business")
            {
                if (day == "Friday")
                {
                    price = 10.90;
                }
                else if (day == "Saturday")
                {
                    price = 15.60;
                }
                else if (day == "Sunday")
                {
                    price = 16;
                }
                if (people >= 100)
                {
                    people -= 10;
                    totalPrice = people * price;
                }
                else
                {
                    totalPrice = people * price;
                }
            }
            else if (type == "Regular")
            {
                if (day == "Friday")
                {
                    price = 15;
                }
                else if (day == "Saturday")
                {
                    price = 20;
                }
                else if (day == "Sunday")
                {
                    price = 22.50;
                }
                totalPrice = people * price;
                if (people >= 10 && people <= 20)
                {
                    totalPrice *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
