using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliesAdding = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> lilies = new Stack<int>(liliesAdding);
            int[] rosesAdding = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Queue<int> roses = new Queue<int>(rosesAdding);
            int wreaths = 0;
            int leftFlowers = 0;
            bool success = false;
            while (lilies.Count > 0 && roses.Count > 0)
            {
                int lilie = lilies.Pop();
                int rose = roses.Dequeue();
                while (lilie + rose >= 15)
                {
                    if (lilie + rose > 15) lilie -= 2;
                    else if (lilie + rose == 15)
                    {
                        lilie = 0;
                        rose = 0;
                        wreaths++;
                    }
                }
                if (lilie + rose > 0 && lilie + rose < 15)
                {
                    leftFlowers += lilie + rose;
                    lilie = 0;
                    rose = 0;
                }
            }
            if (leftFlowers > 0) wreaths += leftFlowers / 15;
            if (wreaths >= 5) success = true;
            if (success) Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            else Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
        }
    }
}
