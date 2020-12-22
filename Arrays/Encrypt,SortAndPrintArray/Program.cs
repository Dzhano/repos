using System;

namespace Encrypt_SortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int sum = 0;
                foreach (char item in input)
                {
                    int value = item;
                    string letter = item.ToString().ToLower();
                    switch (letter)
                    {
                        case "a":
                        case "o":
                        case "e":
                        case "i":
                        case "u":
                        case "y":
                            sum += value * input.Length;
                            break;
                        default:
                            sum += value / input.Length;
                            break;
                    }
                }
                // Не знам как да продължа нататък...
            }
        }
    }
}
