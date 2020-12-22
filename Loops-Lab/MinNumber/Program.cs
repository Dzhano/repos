using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int minNumber = int.MaxValue;
            while (counter < n)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < minNumber)
                {
                    minNumber = num;
                }
                counter++;
            }
            Console.WriteLine(minNumber);
        }
    }
}
