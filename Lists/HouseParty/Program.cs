using System;
using System.Collections.Generic;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] message = Console.ReadLine().Split();
                if (message.Length == 3)
                {
                    if (guests.Contains(message[0])) Console.WriteLine($"{message[0]} is already in the list!");
                    else guests.Add(message[0]);
                }
                else if(message.Length == 4)
                {
                    if (guests.Contains(message[0])) guests.Remove(message[0]);
                    else Console.WriteLine($"{message[0]} is not in the list!");
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, guests));
        }
    }
}
