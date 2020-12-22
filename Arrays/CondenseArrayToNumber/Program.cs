using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            if (num.Length == 1)
            {
                Console.WriteLine(num[0]);
                return;
            }
            int[] arr = new int[num.Length - 1];
            int counter = 0;
            while (arr.Length > 1)
            {
                arr = new int[num.Length - 1 - counter];
                for (int i = 0; i < num.Length - 1 - counter; i++)
                {
                    arr[i] = num[i] + num[i + 1];
                    num[i] = arr[i];
                }
                counter += 1;
            }
            Console.WriteLine(arr[0]);
        }
    }
}
