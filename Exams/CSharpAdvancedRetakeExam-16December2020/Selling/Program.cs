using System;
using System.Linq;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int ver = 0; int hor = 0;
            int pilVer1 = 0; int pilHor1 = 0;
            int pilVer2 = 0; int pilHor2 = 0;
            bool pil1Ready = false;

            int n = int.Parse(Console.ReadLine());
            char[,] bakery = new char[n, n];
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
                    if (input[j] == 'O')
                    {
                        if (!pil1Ready)
                        {
                            pilVer1 = i;
                            pilHor1 = j;
                            pil1Ready = true;
                        }
                        else
                        {
                            pilVer2 = i;
                            pilHor2 = j;
                        }
                    }
                    bakery[i, j] = input[j];
                }
            }

            int money = 0;
            while (money < 50)
            {
                bool failure = false;
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        if (ver - 1 < 0) failure = true;
                        bakery[ver--, hor] = '-';
                        break;
                    case "down":
                        if (ver + 1 >= n) failure = true;
                        bakery[ver++, hor] = '-';
                        break;
                    case "left":
                        if (hor - 1 < 0) failure = true;
                        bakery[ver, hor--] = '-';
                        break;
                    case "right":
                        if (hor + 1 >= n) failure = true;
                        bakery[ver, hor++] = '-';
                        break;
                }
                if (failure)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }
                if (bakery[ver, hor] == 'O')
                {
                    if (ver == pilVer1 && hor == pilHor1)
                    {
                        bakery[ver, hor] = '-';
                        ver = pilVer2;
                        hor = pilHor2;
                    }
                    else if (ver == pilVer2 && hor == pilHor2)
                    {
                        bakery[ver, hor] = '-';
                        ver = pilVer1;
                        hor = pilHor1;
                    }
                }
                else if (bakery[ver, hor] != '-')
                    money += int.Parse(bakery[ver, hor].ToString());
                bakery[ver, hor] = 'S';
            }

            if (money >= 50) Console.WriteLine("Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {money}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(bakery[i, j]);
                Console.WriteLine();
            }
        }
    }
}
