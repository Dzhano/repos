using System;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int bestScore = 0;
            string bestPlayer = "";
            while (true)
            {
                string name = Console.ReadLine();
                if (name == "END")
                {
                    break;
                }
                int goals = int.Parse(Console.ReadLine());
                if (goals > bestScore)
                {
                    bestPlayer = name;
                    bestScore = goals;
                }
                if (goals >= 10)
                {
                    break;
                }
            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (bestScore >= 3)
            {
                Console.WriteLine($"{bestPlayer} has scored {bestScore} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"{bestPlayer} has scored {bestScore} goals.");
            }
        }
    }
}
