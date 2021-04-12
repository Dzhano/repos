using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int battles = 0;
            while (command != "End of battle")
            {
                int distance = int.Parse(command);
                if (initialEnergy - distance >= 0)
                {
                    battles++;
                    initialEnergy -= distance;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battles} won battles and {initialEnergy} energy");
                    return;
                }
                if (battles % 3 == 0) initialEnergy += battles;
                command = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {battles}. Energy left: {initialEnergy}");
        }
    }
}
