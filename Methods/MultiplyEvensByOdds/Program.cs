using System;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));
            int result = GetMultipleOfEvenAndOdds(num);
            Console.WriteLine(result);
        }

        static int GetMultipleOfEvenAndOdds(int number)
        {
            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);
            int multiple = evenSum * oddSum;
            return multiple;
        }

        static int GetSumOfEvenDigits(int number)
        {
            string num = number.ToString();
            int even = 0;
            for (int i = 0; i < num.Length; i++)
            {
                int digit = int.Parse(num[i].ToString());
                if (digit % 2 == 0)
                {
                    even += digit;
                }
            }
            return even;
        }

        static int GetSumOfOddDigits(int number)
        {
            string num = number.ToString();
            int odd = 0;
            for (int i = 0; i < num.Length; i++)
            {
                int digit = int.Parse(num[i].ToString());
                if (digit % 2 != 0)
                {
                    odd += digit;
                }
            }
            return odd;
        }
    }
}
