using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());

            int peopleMusala = 0;
            int peopleMonblan = 0;
            int peopleKilimanjaro = 0;
            int peopleK2 = 0;
            int peopleEverest = 0;
            int totalPeople = 0;
            for (int i = 1; i <= groups; i++)
            {
                int people = int.Parse(Console.ReadLine());
                if (people <= 5)
                {
                    peopleMusala += people;
                }
                else if (people >= 6 && people <= 12)
                {
                    peopleMonblan += people;
                }
                else if (people >= 13 && people <= 25)
                {
                    peopleKilimanjaro += people;
                }
                else if (people >= 26 && people <= 40)
                {
                    peopleK2 += people;
                }
                else if (people >= 41)
                {
                    peopleEverest += people;
                }
                totalPeople += people;
            }
            Console.WriteLine($"{(peopleMusala * 100.0) / (totalPeople * 1.0):F2}%");
            Console.WriteLine($"{(peopleMonblan * 100.0) / (totalPeople * 1.0):F2}%");
            Console.WriteLine($"{(peopleKilimanjaro * 100.0) / (totalPeople * 1.0):F2}%");
            Console.WriteLine($"{(peopleK2 * 100.0) / (totalPeople * 1.0):F2}%");
            Console.WriteLine($"{(peopleEverest * 100.0) / (totalPeople * 1.0):F2}%");
        }
    }
}
