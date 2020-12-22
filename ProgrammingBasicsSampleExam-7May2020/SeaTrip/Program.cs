using System;

namespace SeaTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double foodPrice = double.Parse(Console.ReadLine());
            double souvenirPrice = double.Parse(Console.ReadLine());
            double hotelPrice = double.Parse(Console.ReadLine());

            double totalNeededBenzin = 29.4;
            double benzinPrice = totalNeededBenzin * 1.85;
            double totalFoodAndSouvenirPrice = 3 * foodPrice + 3 * souvenirPrice;
            double firstDayHotelPrice = hotelPrice * 0.9;
            double secondDayHotelPrice = hotelPrice * 0.85;
            double thirdDayHotelPrice = hotelPrice * 0.8;
            double totalPrice = benzinPrice + totalFoodAndSouvenirPrice + firstDayHotelPrice + secondDayHotelPrice + thirdDayHotelPrice;
            Console.WriteLine($"Money needed: {totalPrice:F2}");
        }
    }
}
