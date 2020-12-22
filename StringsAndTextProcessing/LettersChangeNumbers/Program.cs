using System;
using System.Text;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] texts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            foreach (string input in texts)
            {
                StringBuilder number = new StringBuilder();
                int counter = 1;
                for (int i = 0; i < input.Length; i++)
                {
                    if (i > 0)
                    {
                        if (char.IsDigit(input[i]))
                        {
                            number.Append(input[i]);
                            counter++;
                        }
                        else
                        {
                            double num = double.Parse(number.ToString());
                            if (char.IsUpper(input[i - counter]))
                                num /= input[i - counter] - 64;
                            else num *= input[i - counter] - 96;
                            if (char.IsUpper(input[i]))
                                num -= input[i] - 64;
                            else num += input[i] - 96;
                            sum += num;
                            counter = 1;
                        }
                    }
                }
            }
            Console.WriteLine($"{sum:F2}");
        }
    }
}
