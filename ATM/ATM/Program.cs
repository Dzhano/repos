using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = 10000000;
            Console.WriteLine("Insert your card!");
            Console.WriteLine("Choose one of the following options:");
            Console.WriteLine("withdraw, check balance or deposit");
            string option = Console.ReadLine();

            if (option == "withdraw")
            {
                Console.WriteLine("How much money will you withdraw?");
                int amountToWithdraw = int.Parse(Console.ReadLine());

                if (balance >= amountToWithdraw)
                {
                    Console.Write("PIN code: ");
                    int pinCode = int.Parse(Console.ReadLine());

                    if (pinCode == 1234)
                    {
                        balance -= amountToWithdraw;
                        Console.WriteLine(balance);
                    }
                    else
                    {
                        Console.WriteLine("Invalid pin!");
                    }
                }
                balance -= 2;
                Console.WriteLine($"The current balance now is: {balance} lv");
            }
            else if (option == "check balance")
            {
                Console.Write("PIN code: ");
                int pinCode = int.Parse(Console.ReadLine());

                if (pinCode == 1234)
                {
                    Console.WriteLine($"Your balance is {balance} lv");
                }
                else
                {
                    Console.WriteLine("Invalid pin!");
                }
                balance -= 0.50;
                Console.WriteLine($"The current balance now is: {balance} lv");
            }
            else if (option == "deposit")
            {
                Console.WriteLine("How much money do you want to deposit?");
                int deposit = int.Parse(Console.ReadLine());

                Console.Write("PIN code: ");
                int pinCode = int.Parse(Console.ReadLine());
                if (pinCode == 1234)
                {
                    balance += deposit;
                }
                else
                {
                    Console.WriteLine("Invalid pin!");
                }
                balance -= 1;
                Console.WriteLine($"The current balance now is: {balance} lv");
            }
            else
            {
                Console.WriteLine("Invalid operation!");
            }
            Console.WriteLine("Thanks again for using ower servicers.");
        }
    }
}