using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int confectioners = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int corrugations = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double allCakes = cakes * 45;
            double allCorrugations = corrugations * 5.80;
            double allPancakes = pancakes * 3.20;
            double dayPrice = (allCakes + allCorrugations + allPancakes) * confectioners;
            double completePrice = dayPrice * days;
            double finalPrice = completePrice - 0.125 * completePrice;

            Console.WriteLine($"{finalPrice:F2}");
        }
    }
}
