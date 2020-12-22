using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int volume = width * lenght * height;
            string command = Console.ReadLine();
            while (command != "Done")
            {
                volume -= int.Parse(command);
                if (volume <= 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
                    break;
                }
                command = Console.ReadLine();
            }
            if (command == "Done")
            {
                Console.WriteLine($"{volume} Cubic meters left.");
            }
        }
    }
}
