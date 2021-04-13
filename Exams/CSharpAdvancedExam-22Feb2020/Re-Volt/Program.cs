using System;
using System.Linq;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int ver = 0; int hor = 0; 
            
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().ToArray();
                for (int j = 0; j < n; j++)
                {
                    if (input[j] == 'f')
                    {
                        ver = i;
                        hor = j;
                    }
                    matrix[i, j] = input[j];
                }
            }

            bool win = false;
            for (int i = 0; i < m; i++)
            {
                bool move = false;
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        if (ver - 1 < 0) move = true;
                        matrix[ver--, hor] = '-';
                        break;
                    case "down":
                        if (ver + 1 >= n) move = true;
                        matrix[ver++, hor] = '-';
                        break;
                    case "left":
                        if (hor - 1 < 0) move = true;
                        matrix[ver, hor--] = '-';
                        break;
                    case "right":
                        if (hor + 1 >= n) move = true;
                        matrix[ver, hor++] = '-';
                        break;
                }

                if (move)
                {
                    switch (direction)
                    {
                        case "up":
                            ver = n - 1;
                            break;
                        case "down":
                            ver = 0;
                            break;
                        case "left":
                            hor = n - 1;
                            break;
                        case "right":
                            hor = 0;
                            break;
                    }
                }

                move = false;

                switch (matrix[ver, hor])
                {
                    case 'B':
                        switch (direction)
                        {
                            case "up":
                                ver--;
                                if (ver < 0) move = true;
                                break;
                            case "down":
                                ver++;
                                if (ver >= n) move = true;
                                break;
                            case "left":
                                hor--;
                                if (hor < 0) move = true;
                                break;
                            case "right":
                                hor++;
                                if (hor >= n) move = true;
                                break;
                        }
                        break;
                    case 'T':
                        switch (direction)
                        {
                            case "up":
                                ver++;
                                if (ver >= n) move = true;
                                break;
                            case "down":
                                ver--;
                                if (ver < 0) move = true;
                                break;
                            case "left":
                                hor++;
                                if (hor >= n) move = true;
                                break;
                            case "right":
                                hor--;
                                if (hor < 0) move = true;
                                break;
                        }
                        break;
                    case 'F':
                        win = true;
                        move = false;
                        break;
                }

                if (move)
                {
                    switch (direction)
                    {
                        case "up":
                            ver = n - 1;
                            break;
                        case "down":
                            ver = 0;
                            break;
                        case "left":
                            hor = n - 1;
                            break;
                        case "right":
                            hor = 0;
                            break;
                    }
                }

                move = false;

                switch (matrix[ver, hor])
                {
                    case 'B':
                        switch (direction)
                        {
                            case "up":
                                ver--;
                                if (ver < 0) move = true;
                                break;
                            case "down":
                                ver++;
                                if (ver >= n) move = true;
                                break;
                            case "left":
                                hor--;
                                if (hor < 0) move = true;
                                break;
                            case "right":
                                hor++;
                                if (hor >= n) move = true;
                                break;
                        }
                        break;
                    case 'T':
                        switch (direction)
                        {
                            case "up":
                                ver++;
                                if (ver >= n) move = true;
                                break;
                            case "down":
                                ver--;
                                if (ver < 0) move = true;
                                break;
                            case "left":
                                hor++;
                                if (hor >= n) move = true;
                                break;
                            case "right":
                                hor--;
                                if (hor < 0) move = true;
                                break;
                        }
                        break;
                    case 'F':
                        win = true;
                        move = false;
                        break;
                }
                matrix[ver, hor] = 'f';

                if (win)
                {
                    Console.WriteLine("Player won!");
                    break;
                }
            }

            if (!win) Console.WriteLine("Player lost!");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(matrix[i, j]);
                Console.WriteLine();
            }
        }
    }
}
