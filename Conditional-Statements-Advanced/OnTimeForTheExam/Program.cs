using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arrivingHour = int.Parse(Console.ReadLine());
            int arrivingMinute = int.Parse(Console.ReadLine());

            int totalExamMinutes = examHour * 60 + examMinute;
            int totalArrivingMinutes = arrivingHour * 60 + arrivingMinute;
            if (totalExamMinutes == totalArrivingMinutes)
            {
                Console.WriteLine("On time");
            }
            else if (totalExamMinutes > totalArrivingMinutes)
            {
                if (totalExamMinutes - totalArrivingMinutes <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{totalExamMinutes - totalArrivingMinutes} minutes before the start");
                }
                else if (totalExamMinutes - totalArrivingMinutes > 30 && totalExamMinutes - totalArrivingMinutes <= 59)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{totalExamMinutes - totalArrivingMinutes} minutes before the start");
                }
                else if ((totalExamMinutes - totalArrivingMinutes >= 60 && totalExamMinutes - totalArrivingMinutes <= 69) || (totalExamMinutes - totalArrivingMinutes >= 120 && totalExamMinutes - totalArrivingMinutes <= 129) || (totalExamMinutes - totalArrivingMinutes >= 180 && totalExamMinutes - totalArrivingMinutes <= 189) || (totalExamMinutes - totalArrivingMinutes >= 240 && totalExamMinutes - totalArrivingMinutes <= 249))
                {
                    int extraEarlyHours = (totalExamMinutes - totalArrivingMinutes) / 60;
                    int extraEarlyMinutes = (totalExamMinutes - totalArrivingMinutes) % 60;
                    Console.WriteLine("Early");
                    Console.WriteLine($"{extraEarlyHours}:0{extraEarlyMinutes} hours before the start");
                }
                else
                {
                    int extraEarlyHours = (totalExamMinutes - totalArrivingMinutes) / 60;
                    int extraEarlyMinutes = (totalExamMinutes - totalArrivingMinutes) % 60;
                    Console.WriteLine("Early");
                    Console.WriteLine($"{extraEarlyHours}:{extraEarlyMinutes} hours before the start");
                }
            }
            else if (totalExamMinutes < totalArrivingMinutes)
            {
                if (totalArrivingMinutes - totalExamMinutes <= 59)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{totalArrivingMinutes - totalExamMinutes} minutes after the start");
                }
                else if ((totalArrivingMinutes - totalExamMinutes >= 60 && totalArrivingMinutes - totalExamMinutes <= 69) || (totalArrivingMinutes - totalExamMinutes >= 120 && totalArrivingMinutes - totalExamMinutes <= 129) || (totalArrivingMinutes - totalExamMinutes >= 180 && totalArrivingMinutes - totalExamMinutes <= 189) || (totalArrivingMinutes - totalExamMinutes >= 240 && totalArrivingMinutes - totalExamMinutes <= 249))
                {
                    int extraLateHours = (totalArrivingMinutes - totalExamMinutes) / 60;
                    int extraLateMinutes = (totalArrivingMinutes - totalExamMinutes) % 60;
                    Console.WriteLine("Late");
                    Console.WriteLine($"{extraLateHours}:0{extraLateMinutes} hours after the start");
                }
                else
                {
                    int extraLateHours = (totalArrivingMinutes - totalExamMinutes) / 60;
                    int extraLateMinutes = (totalArrivingMinutes - totalExamMinutes) % 60;
                    Console.WriteLine("Late");
                    Console.WriteLine($"{extraLateHours}:{extraLateMinutes} hours after the start");
                }
            }
        }
    }
}
