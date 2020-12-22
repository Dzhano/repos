using System;
using System.Diagnostics.Tracing;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            if (command == "stop")
            {
                Environment.Exit(0);
            }
            double num = double.Parse(command);

            double sumPN = 0;
            double sumNPN = 0;
            while (num >= -2147483648 && num <= 2147483647)
            {
                int counter = 0;
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                for (int i = 1; i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        counter += 1;
                    }
                }
                if (counter > 2)
                {
                    sumNPN += num;
                }
                else
                {
                    sumPN += num;
                }
                command = Console.ReadLine();
                if (command == "stop")
                {
                    break;
                }
                num = double.Parse(command);
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPN}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNPN}");
        }
    }
}
