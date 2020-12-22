using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int factorial = 1;
            int sum = 0;
            int num = int.Parse(number);

            int length = number.Length;
            for (int i = 0; i < length; i++)
            {
                int digit = int.Parse(number[i].ToString());
                if (digit == 0)
                {
                    factorial = 1;
                }
                for (int j = 1; j <= digit; j++)
                {
                    factorial *= j;
                }
                sum += factorial;
                factorial = 1;
            }
            if (sum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
