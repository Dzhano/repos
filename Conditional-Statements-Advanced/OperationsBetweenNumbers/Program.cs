using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            string operatorSign = Console.ReadLine();
            double result = 0;
            bool canotDivideByZero = false;
            string evenOrOdd = "";

            switch (operatorSign)
            {
                case "+":
                    result = num1 + num2;
                    break;

                case "-":
                    result = num1 - num2;
                    break;

                case "*":
                    result = num1 * num2;
                    break;

                case "/":
                    if (num2 == 0)
                    {
                        canotDivideByZero = true;
                    }
                    else
                    { // for making int into double value :) //
                        result = 1.0 * num1 / num2;
                    }
                    break;

                case "%":
                    if (num2 == 0)
                    {
                        canotDivideByZero = true;
                    }
                    else
                    {
                        result = num1 % num2;
                    }
                    break;
            }

            if (result % 2 == 0)
            {
                evenOrOdd = "even";
            }
            else
            {
                evenOrOdd = "odd";
            }

            if (operatorSign == "+" || operatorSign == "-" || operatorSign == "*")
            {
                Console.WriteLine($"{num1} {operatorSign} {num2} = {result} - {evenOrOdd}");
            }
            else if (canotDivideByZero)
            {
                Console.WriteLine($"Cannot divide {num1} by zero");
            }
            else if (operatorSign == "/")
            {
                Console.WriteLine($"{num1} {operatorSign} {num2} = {result:f2}");
            }
            else if (operatorSign == "%")
            {
                Console.WriteLine($"{num1} {operatorSign} {num2} = {result}");
            }

        }
    }
}
