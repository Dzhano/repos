using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 17; i <= n; i++)
            {
                string num = i.ToString();
                TopNumber(num);
            }
        }

        static void TopNumber(string num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                int number = int.Parse(num[i].ToString());
                if (number % 2 != 0)
                {
                    int digits = DigitSum(num);
                    if (digits % 8 == 0)
                    {
                        Console.WriteLine(num);
                        break;
                    }
                }
            }
        }

        static int DigitSum(string num)
        {
            int digits = 0;
            for (int i = 0; i < num.Length; i++)
            {
                int number = int.Parse(num[i].ToString());
                digits += number;
            }
            return digits;
        }
    }
}
