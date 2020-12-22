using System;

namespace TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            double reward = 0;
            double dayReward = 0;
            double totalReward = 0;
            int winCounter = 0;
            int loseCounter = 0;
            int winDayCounter = 0;
            int loseDayCounter = 0;
            for (int i = 1; i <= days; i++)
            {
                string sport = Console.ReadLine();
                while (sport != "Finish")
                {
                    string result = Console.ReadLine(); // "win" или "lose"
                    switch (result)
                    {
                        case "win":
                            reward = 20;
                            winCounter++;
                            break;
                        case "lose":
                            reward = 0;
                            loseCounter++;
                            break;
                    }
                    dayReward += reward;
                    sport = Console.ReadLine();
                }
                if (winCounter > loseCounter)
                {
                    dayReward *= 1.1;
                    winDayCounter++;
                }
                else if (winCounter < loseCounter)
                {
                    loseDayCounter++;
                }
                totalReward += dayReward;
                winCounter = 0;
                loseCounter = 0;
                dayReward = 0;
            }
            if (winDayCounter > loseDayCounter)
            {
                totalReward *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalReward:F2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalReward:F2}");
            }
        }
    }
}
