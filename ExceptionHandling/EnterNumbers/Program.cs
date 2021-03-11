using System;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            while (true)
            {
                try
                {
                    ReadNumber(start, end);
                }
                catch (Exception)
                {
                    continue;
                }
                break;
            }
        }

        static void ReadNumber(int start, int end)
        {
            for (int i = 0; i < 10; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < start || number > end)
                    throw new ArgumentException();
            }
        }
    }
}
