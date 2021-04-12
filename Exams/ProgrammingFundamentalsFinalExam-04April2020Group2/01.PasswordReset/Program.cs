using System;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder password = new StringBuilder();
            password.Append(Console.ReadLine());
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] input = command.Split();
                switch (input[0])
                {
                    case "TakeOdd":
                        StringBuilder newPassword = new StringBuilder();
                        for (int i = 1; i < password.Length; i += 2) 
                            newPassword.Append(password[i]);
                        password = newPassword;
                        Console.WriteLine(newPassword);
                        break;
                    case "Cut":
                        password.Remove(int.Parse(input[1]), int.Parse(input[2]));
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        if (password.ToString().Contains(input[1]))
                        {
                            password.Replace(input[1], input[2]);
                            Console.WriteLine(password);
                        }
                        else Console.WriteLine("Nothing to replace!");
                        break;
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
