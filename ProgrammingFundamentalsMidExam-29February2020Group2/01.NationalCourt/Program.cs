using System;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int answeredPeople = int.Parse(Console.ReadLine());
            answeredPeople += int.Parse(Console.ReadLine());
            answeredPeople += int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            int count = 0;
            int hours = 0;
            while (people > 0)
            {
                if (count % 3 == 0 && count != 0) hours++;
                people -= answeredPeople;
                count++;
                hours++;
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
