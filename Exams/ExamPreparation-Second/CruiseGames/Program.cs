using System;

namespace CruiseGames
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            int games = int.Parse(Console.ReadLine());

            double volleyballPoints = 0;
            double tennisPoints = 0;
            double badmintonPoints = 0;
            int volleyballGames = 0;
            int tennisGames = 0;
            int badmintonGames = 0;
            for (int i = 1; i <= games; i++)
            {
                string gameName = Console.ReadLine(); //"volleyball", "tennis", "badminton"
                double points = double.Parse(Console.ReadLine());
                switch (gameName)
                {
                    case "volleyball":
                        points *= 1.07;
                        volleyballPoints += points;
                        volleyballGames++;
                        break;
                    case "tennis":
                        points *= 1.05;
                        tennisPoints += points;
                        tennisGames++;
                        break;
                    case "badminton":
                        points *= 1.02;
                        badmintonPoints += points;
                        badmintonGames++;
                        break;
                }
            }
            double averageVolleyballPoints = volleyballPoints / volleyballGames;
            double averageTennisPoints = tennisPoints / tennisGames;
            double averageBadmintonPoint = badmintonPoints / badmintonGames;
            if (averageVolleyballPoints >= 75 && averageTennisPoints >= 75 && averageBadmintonPoint >= 75)
            {
                Console.WriteLine($"Congratulations, {playerName}! You won the cruise games with {Math.Floor(volleyballPoints + tennisPoints + badmintonPoints)} points.");
            }
            else
            {
                Console.WriteLine($"Sorry, {playerName}, you lost. Your points are only {Math.Floor(volleyballPoints + tennisPoints + badmintonPoints)}.");
            }
        }
    }
}
