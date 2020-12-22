using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string command = string.Empty;
            int counter = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                int integer = int.Parse(command);
                if (integer < 0 || integer >= array.Length || array[integer] == -1) continue;
                int shoot = array[integer];
                array[integer] = -1;
                counter++;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != -1)
                    {
                        if (array[i] > shoot) array[i] -= shoot;
                        else array[i] += shoot;
                    }
                }
            }
            Console.WriteLine($"Shot targets: {counter} -> {string.Join(" ", array)}");
        }
    }
}
