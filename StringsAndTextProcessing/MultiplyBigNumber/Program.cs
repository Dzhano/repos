using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string big = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            if (big == "0" || n == 0)
            {
                Console.WriteLine(0);
                return;
            }
            StringBuilder huge = new StringBuilder();
            int temp = 0;
            foreach (char m in big.Reverse())
            {
                int number = int.Parse(m.ToString());
                int result = number * n + temp;
                int restDigit = result % 10;
                temp = result / 10;
                huge.Insert(0, restDigit);
            }
            if (temp > 0) huge.Insert(0, temp);
            Console.WriteLine(huge);
        }
    }
}
