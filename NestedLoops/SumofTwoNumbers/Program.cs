using System;
using System.Diagnostics.Tracing;

namespace SumofTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int beggining = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int counter = 0;
            bool combination = false;
            for (int i = beggining; i <= end; i++)
            {
                for (int b = beggining; b <= end; b++)
                {
                    counter++;
                    if (i + b == magicNum)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {b} = {magicNum})");
                        combination = true;
                        break;
                    }
                }
                if (combination)
                {
                    break;
                }
            }
            if (combination == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
            }
        }
    }
}
