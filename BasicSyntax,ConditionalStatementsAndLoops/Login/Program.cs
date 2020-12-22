using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;
            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }
            for (int i = 1; i <= 4; i++)
            {
                string trying = Console.ReadLine();
                if (trying == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }
                else
                {
                    if (i == 4)
                    {
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
            Console.WriteLine($"User {username} blocked!");
        }
    }
}
