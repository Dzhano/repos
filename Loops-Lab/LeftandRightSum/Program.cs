using System;

namespace LeftandRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int num = 0;
            int number = 0;
            for (int i = 1; i <= 2; i++)
            {
                int z = 0;
                for (int y = 1; y <= n; y++)
                {
                    int num1 = int.Parse(Console.ReadLine());
                    z += num1;
                }
                if (i == 1)
                {
                    num = z;
                }
                else if (i == 2)
                {
                    number = z;
                }
            }
            if (num == number)
            {
                Console.WriteLine($"Yes, sum = {num}");
            }
            else
            {
                int diff = Math.Abs(number - num);
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
