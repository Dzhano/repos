using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int homeSteps = 0;
            int totalSteps = 0;
            while (totalSteps < 10000)
            {
                string command = Console.ReadLine();
                if (command != "Going home")
                {
                    int steps = int.Parse(command);
                    totalSteps += steps;
                }
                else
                {
                    homeSteps = int.Parse(Console.ReadLine());
                    break;
                }
            }
            if (totalSteps + homeSteps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{10000 - (totalSteps + homeSteps)} more steps to reach goal.");
            }
        }
    }
}
