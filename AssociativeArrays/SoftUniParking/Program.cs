using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registeredUsers
                = new Dictionary<string, string>(); 
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                switch (command[0])
                {
                    case "register":
                        if (registeredUsers.ContainsKey(command[1])) 
                            Console.WriteLine($"ERROR: already registered with plate number {registeredUsers[command[1]]}");
                        else
                        {
                            registeredUsers.Add(command[1], command[2]);
                            Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                        }
                        break;
                    case "unregister":
                        if (registeredUsers.ContainsKey(command[1]))
                        {
                            registeredUsers.Remove(command[1]);
                            Console.WriteLine($"{command[1]} unregistered successfully");
                        }
                        else Console.WriteLine($"ERROR: user {command[1]} not found");
                        break;
                }
            }
            foreach (var person in registeredUsers) Console.WriteLine($"{person.Key} => {person.Value}");
        }
    }
}
