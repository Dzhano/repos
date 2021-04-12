using System;

namespace _01.NextLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int battles = 0;
            for (int i = 1; i <= n; i++)
            {
                double experience = double.Parse(Console.ReadLine());
                if (i % 15 == 0) experience *= 1.05;
                else if (i % 5 == 0) experience *= 0.90;
                else if (i % 3 == 0) experience *= 1.15;
                neededExperience -= experience;
                battles++;
                if (0 >= neededExperience) 
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {battles} battles.");
                    return;
                }
            }
            Console.WriteLine($"Player was not able to collect the needed experience, " +
                    $"{neededExperience:F2} more needed.");
        }
    }
}
