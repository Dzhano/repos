using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Start")
                {
                    break;
                }
                double coin = double.Parse(command);
                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2 )
                {
                    sum += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
            }
            while (true)
            {
                string product = Console.ReadLine();
                if (product == "End")
                {
                    break;
                }
                else if (product == "Nuts")
                {
                    if (sum < 2.0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        sum -= 2.0;
                        Console.WriteLine("Purchased nuts");
                    }
                }
                else if (product == "Water")
                {
                    if (sum < 0.7)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        sum -= 0.7;
                        Console.WriteLine("Purchased water");
                    }
                }
                else if (product == "Crisps")
                {
                    if (sum < 1.5)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        sum -= 1.5;
                        Console.WriteLine("Purchased crisps");
                    }
                }
                else if (product == "Soda")
                {
                    if (sum < 0.8)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        sum -= 0.8;
                        Console.WriteLine("Purchased soda");
                    }
                }
                else if (product == "Coke")
                {
                    if (sum < 1.0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        sum -= 1.0;
                        Console.WriteLine("Purchased coke");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
            Console.WriteLine($"Change: {sum:F2}");
        }
    }
}
