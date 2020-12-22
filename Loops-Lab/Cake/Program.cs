using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int cakeSize = width * lenght;
            int piecesCake = 0;
            int takenPieces = 0;
            while (takenPieces < cakeSize)
            {
                string command = Console.ReadLine();
                if (command != "STOP")
                {
                    piecesCake = int.Parse(command);
                    takenPieces += piecesCake;
                }
                else
                {
                    break;
                }
            }
            if (takenPieces >= cakeSize)
            {
                Console.WriteLine($"No more cake left! You need {takenPieces - cakeSize} pieces more.");
            }
            else
            {
                Console.WriteLine($"{cakeSize - takenPieces} pieces are left.");
            }
        }
    }
}
