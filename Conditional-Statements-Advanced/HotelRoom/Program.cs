﻿using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine(); //May, June, July, August, September или October
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0.0;
            double apartmentPrice = 0.0;
            if (month == "May" || month == "October")
            {
                studioPrice = 50;
                apartmentPrice = 65;
                if (nights > 7 && nights <= 14)
                {
                    studioPrice *= 0.95;
                }
                else if (nights > 14)
                {
                    studioPrice *= 0.70;
                    apartmentPrice *= 0.90;
                }
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 75.20;
                apartmentPrice = 68.70;
                if (nights > 14)
                {
                    studioPrice *= 0.80;
                    apartmentPrice *= 0.90;
                }
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = 76;
                apartmentPrice = 77;
                if (nights > 14)
                {
                    apartmentPrice *= 0.90;
                }
            }
            Console.WriteLine($"Apartment: {apartmentPrice * nights:F2} lv.");
            Console.WriteLine($"Studio: {studioPrice * nights:F2} lv.");
        }
    }
}
