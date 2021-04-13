using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] effectsInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] casingsInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> bombEffects = new Queue<int>(effectsInput);
            Stack<int> bombCasings = new Stack<int>(casingsInput);

            int daturaBombs = 0; // 40
            int cherryBombs = 0; // 60
            int smokeDecoyBombs = 0; // 120

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                int bombEffect = bombEffects.Peek();
                int bombCasing = bombCasings.Pop();

                switch (bombEffect + bombCasing)
                {
                    case 40:
                        daturaBombs++;
                        bombEffects.Dequeue();
                        break;
                    case 60:
                        cherryBombs++;
                        bombEffects.Dequeue();
                        break;
                    case 120:
                        smokeDecoyBombs++;
                        bombEffects.Dequeue();
                        break;
                    default:
                        bombCasings.Push(bombCasing - 5);
                        break;
                }

                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoyBombs >= 3)
                    break;
            }


            if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoyBombs >= 3)
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            else Console.WriteLine("You don't have enough materials to fill the bomb pouch.");

            if (bombEffects.Count > 0) Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            else  Console.WriteLine("Bomb Effects: empty");

            if (bombCasings.Count > 0) Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            else Console.WriteLine("Bomb Casings: empty");

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");
        }
    }
}
