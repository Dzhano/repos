using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            int takenSeats = 0;
            int studentSeats = 0;
            int standardSeats = 0;
            int kidsSeats = 0;
            while (movieName != "Finish")
            {
                int seats = int.Parse(Console.ReadLine());
                string ticketType = Console.ReadLine(); //student, standard or kid
                while (ticketType != "End")
                {
                    if (ticketType == "student")
                    {
                        studentSeats++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardSeats++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidsSeats++;
                    }
                    takenSeats++;
                    if (takenSeats == seats)
                    {
                        break;
                    }
                    ticketType = Console.ReadLine(); //student, standard or kid
                }
                double percentageFull = takenSeats * 1.0 / seats * 100;
                takenSeats = 0;
                Console.WriteLine($"{movieName} - {percentageFull:F2}% full.");
                movieName = Console.ReadLine();
            }
            int totalTakenSeats = studentSeats + standardSeats + kidsSeats;


            Console.WriteLine($"Total tickets: {totalTakenSeats}");
            Console.WriteLine($"{studentSeats * 1.0 / totalTakenSeats * 100:F2}% student tickets.");
            Console.WriteLine($"{standardSeats * 1.0 / totalTakenSeats * 100:F2}% standard tickets.");
            Console.WriteLine($"{kidsSeats * 1.0 / totalTakenSeats * 100:F2}% kids tickets.");
        }
    }
}
