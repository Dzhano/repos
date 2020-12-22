using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int maxNumber = int.MinValue;
            while (counter < n)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > maxNumber)
                {
                    maxNumber = num;
                }
                counter++;
            }
            Console.WriteLine(maxNumber);
        }
    }
}
