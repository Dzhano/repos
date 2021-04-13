using System;
using System.Linq;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int ver = 0; int hor = 0;
            int burrowVer1 = 0; int burrowHor1 = 0;
            int burrowVer2 = 0; int burrowHor2 = 0;
            bool burrow1Ready = false;

            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().ToArray();
                for (int j = 0; j < n; j++) 
                {
                    if (input[j] == 'S')
                    {
                        ver = i;
                        hor = j;
                    }
                    if (input[j] == 'B')
                    {
                        if (!burrow1Ready)
                        {
                            burrowVer1 = i;
                            burrowHor1 = j;
                            burrow1Ready = true;
                        }
                        else
                        {
                            burrowVer2 = i;
                            burrowHor2 = j;
                        }
                    }
                    territory[i, j] = input[j];
                }
            }

            int food = 0;

            while (food < 10)
            {
                bool failure = false;
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        if (ver - 1 < 0) failure = true;
                        territory[ver--, hor] = '.';
                        break;
                    case "down":
                        if (ver + 1 >= n) failure = true;
                        territory[ver++, hor] = '.';
                        break;
                    case "left":
                        if (hor - 1 < 0) failure = true;
                        territory[ver, hor--] = '.';
                        break;
                    case "right":
                        if (hor + 1 >= n) failure = true;
                        territory[ver, hor++] = '.';
                        break;
                }
                if (failure)
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (territory[ver, hor] == 'B')
                {
                    if (ver == burrowVer1 && hor == burrowHor1)
                    {
                        territory[ver, hor] = '.';
                        ver = burrowVer2;
                        hor = burrowHor2;
                    }
                    else if (ver == burrowVer2 && hor == burrowHor2)
                    {
                        territory[ver, hor] = '.';
                        ver = burrowVer1;
                        hor = burrowHor1;
                    }
                }
                else if (territory[ver, hor] == '*') food++;
                territory[ver, hor] = 'S';
            }

            if (food >= 10) Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {food}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(territory[i, j]);
                Console.WriteLine();
            }
        }
    }
}
