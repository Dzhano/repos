using System;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeiyfkffliyForLiter = double.Parse(Console.ReadLine());
            double amountBeer = double.Parse(Console.ReadLine());
            double amountWine = double.Parse(Console.ReadLine());
            double amountRaki = double.Parse(Console.ReadLine());
            double amountWhiskey = double.Parse(Console.ReadLine());

            double rakiForLiter = whiskeiyfkffliyForLiter / 2;
            double wineForLiter = rakiForLiter - (0.4 * rakiForLiter);
            double beerForLiter = rakiForLiter - (0.8 * rakiForLiter);

            double priceRaki = amountRaki * rakiForLiter;
            double priceWine = amountWine * wineForLiter;
            double priceBeer = amountBeer * beerForLiter;
            double priceWhiskey = amountWhiskey * whiskeiyfkffliyForLiter;
            double completePrice = priceRaki + priceWine + priceBeer + priceWhiskey;

            Console.WriteLine($"{completePrice:F2}");
        }
    }
}
