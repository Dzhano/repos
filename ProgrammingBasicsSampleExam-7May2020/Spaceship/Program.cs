using System;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double wedthShip = double.Parse(Console.ReadLine());
            double lenghtShip = double.Parse(Console.ReadLine());
            double hightShip = double.Parse(Console.ReadLine());
            double averageHightA = double.Parse(Console.ReadLine());

            double ship = wedthShip * lenghtShip * hightShip;
            double room = 2 * 2 * (averageHightA + 0.40);
            double space = Math.Floor(ship / room);
            if (space >= 3 && space <= 10)
            {
                Console.WriteLine($"The spacecraft holds {space} astronauts.");
            }
            else if (space < 3 && space >= 1)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (space > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
