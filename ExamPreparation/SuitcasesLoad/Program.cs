using System;

namespace SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double capability = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int counter = 0;
            while (command != "End")
            {
                double suitcaseVolume = double.Parse(command);
                counter++;
                if (counter % 3 == 0)
                {
                    suitcaseVolume *= 1.10;
                }
                if (suitcaseVolume >= capability)
                {
                    Console.WriteLine("No more space!");
                    counter--;
                    break;
                }
                capability -= suitcaseVolume;
                command = Console.ReadLine();
            }
            if (command == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }
            Console.WriteLine($"Statistic: {counter} suitcases loaded.");
        }
    }
}
