using System;

namespace Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int totalPoints = 0;
            int redPoints = 0;
            int orangePoints = 0;
            int yellowPoints = 0;
            int whitePoints = 0;
            int blackPoints = 0;
            int others = 0;
            for (int i = 1; i <= n; i++)
            {
                string color = Console.ReadLine();
                switch (color)
                {
                    case "red":
                        redPoints += 1;
                        totalPoints += 5;
                        break;
                    case "orange":
                        orangePoints += 1;
                        totalPoints += 10;
                        break;
                    case "yellow":
                        yellowPoints += 1;
                        totalPoints += 15;
                        break;
                    case "white":
                        whitePoints += 1;
                        totalPoints += 20;
                        break;
                    case "black":
                        blackPoints += 1;
                        totalPoints /= 2;
                        break;
                    default:
                        others += 1;
                        break;
                }
            }
            Console.WriteLine($"Total points: {totalPoints}");
            Console.WriteLine($"Points from red balls: {redPoints}");
            Console.WriteLine($"Points from orange balls: {orangePoints}");
            Console.WriteLine($"Points from yellow balls: {yellowPoints}");
            Console.WriteLine($"Points from white balls: {whitePoints}");
            Console.WriteLine($"Other colors picked: {others}");
            Console.WriteLine($"Divides from black balls: {blackPoints}");
        }
    }
}
