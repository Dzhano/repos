using System;
using System.Linq;

namespace CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int steps = numbers.Length / 2;
            double leftRacer = 0;
            double rightRacer = 0;
            int rightCounter = numbers.Length - 1;
            for (int i = 0; i < steps; i++)
            {
                if (numbers[i] == 0) leftRacer *= 0.8;
                else leftRacer += numbers[i];
                if (numbers[rightCounter] == 0) rightRacer *= 0.8;
                else rightRacer += numbers[rightCounter];
                rightCounter--;
            }
            if (leftRacer < rightRacer) Console.WriteLine($"The winner is left with total time: {leftRacer}");
            else if (leftRacer > rightRacer) Console.WriteLine($"The winner is right with total time: {rightRacer}");
        }
    }
}
