using System;

namespace ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            int time = number * 3;

            Console.WriteLine($"The architect {name} will need {time} hours to complete {number} project/s.");
        }
    }
}
