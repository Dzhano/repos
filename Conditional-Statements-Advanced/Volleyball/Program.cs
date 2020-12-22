using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine(); //leap (високосна година) или normal(невисокосна)
            int p = int.Parse(Console.ReadLine()); //брой празници в годината (които не са събота и неделя).
            int h = int.Parse(Console.ReadLine()); //брой уикенди, в които Влади си пътува до родния град.

            double weekendsSofia = (48 - h) * 0.75;
            double gamesSofia = p * (2 * 1.0 / 3);
            double totalGames = weekendsSofia + h + gamesSofia;
            if (year == "leap")
            {
                totalGames *= 1.15;
            }
            Console.WriteLine(Math.Floor(totalGames));
        }
    }
}
