using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int spice = 0;
            int days = 0;
            while (yield >= 100)
            {
                spice += yield;
                days += 1;
                yield -= 10;
                if (spice >= 26)
                {
                    spice -= 26;
                }
            }
            if (spice >= 26)
            {
                spice -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(spice);
        }
    }
}
