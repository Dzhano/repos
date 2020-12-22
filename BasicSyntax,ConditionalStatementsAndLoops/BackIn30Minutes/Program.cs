using System;

namespace BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int newTime = 60 * hour + minutes + 30;
            int newHour = newTime / 60;
            int newMinutes = newTime % 60;
            if (newHour >= 24)
            {
                newHour -= 24;
            }
            Console.WriteLine($"{newHour}:{newMinutes:D2}");
        }
    }
}
