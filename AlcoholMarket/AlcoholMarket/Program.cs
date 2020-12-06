using System;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyForLiter = double.Parse(Console.ReadLine());
            double amountBeer = double.Parse(Console.ReadLine());
            double amountWine = double.Parse(Console.ReadLine());
            double amountRaki = double.Parse(Console.ReadLine());
            double amountWhiskey = double.Parse(Console.ReadLine());

            double rakiForLiter = whiskeyForLiter / 2;
            double wineForLiter = rakiForLiter - (0.4 * rakiForLiter);
            double beerForLiter = rakiForLiter - (0.8 * rakiForLiter);

            double priceRaki = amountRaki * rakiForLiter;
            double priceWine = amountWine * wineForLiter;
            double priceBeer = amountBeer * beerForLiter;
            double priceWhiskey = amountWhiskey * whiskeyForLiter;
            double completePrice = priceRaki + priceWine + priceBeer + priceWhiskey;

            Console.WriteLine($"{completePrice:F2}");
        }
    }
}
