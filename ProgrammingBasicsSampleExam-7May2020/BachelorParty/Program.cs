using System;
using System.Text.RegularExpressions;

namespace BachelorParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double singerPrice = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int totalGroupsPrice = 0;
            int totalPeople = 0;
            while (command != "The restaurant is full")
            {
                int groupPeople = int.Parse(command);
                int groupPeoplePrice = 0;
                if (groupPeople < 5)
                {
                    groupPeoplePrice = groupPeople * 100;
                }
                else
                {
                    groupPeoplePrice = groupPeople * 70;
                }
                totalGroupsPrice += groupPeoplePrice;
                totalPeople += groupPeople;
                command = Console.ReadLine();
            }
            if (totalGroupsPrice >= singerPrice)
            {
                Console.WriteLine($"You have {totalPeople} guests and {totalGroupsPrice - singerPrice} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {totalPeople} guests and {totalGroupsPrice} leva income, but no singer.");
            }
        }
    }
}
