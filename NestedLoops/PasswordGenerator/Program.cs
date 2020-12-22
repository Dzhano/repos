using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            char f = ' ';
            char g = ' ';
            for (int a = 1; a <= n; a++)
            {
                for (int b = 1; b <= n; b++)
                {
                    for (int c = 1; c <= l; c++)
                    {
                        for (int d = 1; d <= l; d++)
                        {
                            for (int e = 1; e <= n; e++)
                            {
                                switch (c)
                                {
                                    case 1:
                                        f = 'a';
                                        break;
                                    case 2:
                                        f = 'b';
                                        break;
                                    case 3:
                                        f = 'c';
                                        break;
                                    case 4:
                                        f = 'd';
                                        break;
                                    case 5:
                                        f = 'e';
                                        break;
                                    case 6:
                                        f = 'f';
                                        break;
                                    case 7:
                                        f = 'g';
                                        break;
                                    case 8:
                                        f = 'h';
                                        break;
                                    case 9:
                                        f = 'i';
                                        break;
                                }

                                switch (d)
                                {
                                    case 1:
                                        g = 'a';
                                        break;
                                    case 2:
                                        g = 'b';
                                        break;
                                    case 3:
                                        g = 'c';
                                        break;
                                    case 4:
                                        g = 'd';
                                        break;
                                    case 5:
                                        g = 'e';
                                        break;
                                    case 6:
                                        g = 'f';
                                        break;
                                    case 7:
                                        g = 'g';
                                        break;
                                    case 8:
                                        g = 'h';
                                        break;
                                    case 9:
                                        g = 'i';
                                        break;
                                }

                                if (e > a && e > b)
                                {
                                    Console.Write($"{a}{b}{f}{g}{e} ");
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}