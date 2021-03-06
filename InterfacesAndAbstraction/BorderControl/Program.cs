using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 04. Border Control
            List<IId> ids = new List<IId>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 3)
                {
                    int citizenAge = int.Parse(data[1]);
                    Citizen newCitizen = new Citizen(data[0], citizenAge, data[2]);
                    ids.Add(newCitizen);
                }
                else if (data.Length == 2)
                {
                    Robot newRobot = new Robot(data[0], data[1]);
                    ids.Add(newRobot);
                }
            }

            string fakeID = Console.ReadLine();
            foreach (var item in ids) 
                if (item.Id.EndsWith(fakeID)) 
                    Console.WriteLine(item.Id); */

            /* 05. Birthday Celebrations
            List<IBirthdate> birthdates = new List<IBirthdate>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (data[0] == "Citizen")
                {
                    int citizenAge = int.Parse(data[2]);
                    Citizen newCitizen = new Citizen(data[1], citizenAge, data[3], data[4]);
                    birthdates.Add(newCitizen);
                }
                else if (data[0] == "Pet")
                {
                    Pet newPet = new Pet(data[1], data[2]);
                    birthdates.Add(newPet);
                }
                else if (data[0] == "Robot") continue;
            }

            string year = Console.ReadLine();
            foreach (var item in birthdates)
                if (item.Birthdate.EndsWith(year))
                    Console.WriteLine(item.Birthdate); */

            // 06. Food Shortage
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int personAge = int.Parse(data[1]);
                if (data.Length == 4)
                {
                    Citizen citizen = new Citizen(data[0], personAge, data[2], data[3]);
                    buyers.Add(citizen);
                }
                else if (data.Length == 3)
                {
                    Rebel rebel = new Rebel(data[0], personAge, data[2]);
                    buyers.Add(rebel);
                }
            }

            string name = string.Empty;
            while ((name = Console.ReadLine()) != "End")
            {
                if (buyers.FirstOrDefault(b => b.Name == name) != null)
                    buyers.FirstOrDefault(b => b.Name == name).BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
