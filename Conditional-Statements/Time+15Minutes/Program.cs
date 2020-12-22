using System;

namespace Time_15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int timeMinutes = (hours * 60 + minutes) + 15;
            int newHours = timeMinutes / 60;
            int newMinutes = timeMinutes % 60;

            if (newHours < 24)
            {
                if (newMinutes < 10)
                {
                    Console.WriteLine($"{newHours}:0{newMinutes}");
                }
                else
                {
                    Console.WriteLine($"{newHours}:{newMinutes}");
                }
            }
            else
            {
                if (newMinutes < 10)
                {
                    Console.WriteLine($"0:0{newMinutes}");
                }
                else
                {
                    Console.WriteLine($"0:{newMinutes}");
                }
            }
        }
    }
}
