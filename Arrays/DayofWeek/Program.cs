using System;

namespace DayofWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            int day = int.Parse(Console.ReadLine());
            if (day < 1 || day > days.Length)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(days[day - 1]);
            }
        }
    }
}
