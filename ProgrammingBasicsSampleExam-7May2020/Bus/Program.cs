using System;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int begginingPassengers = int.Parse(Console.ReadLine());
            int stops = int.Parse(Console.ReadLine());
            for (int i = 1; i <= stops; i++)
            {
                begginingPassengers -= int.Parse(Console.ReadLine());
                begginingPassengers += int.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    begginingPassengers += 2;
                }
                else if (i % 2 == 0)
                {
                    begginingPassengers -= 2;
                }
            }
            Console.WriteLine($"The final number of passengers is : {begginingPassengers}");
        }
    }
}
