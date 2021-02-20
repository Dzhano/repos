using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = 0; // verticalPosition   // -"up" and +"down"
            int h = 0; // horisontalPosition // -"left" and +"right"
            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n,n];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    territory[i, j] = input[j];
                    if (input[j] == 'B')
                    {
                        v = i;
                        h = j;
                    }
                }
            }
            int polinationedFlowers = 0;
            string command = string.Empty;
            bool lost = false;
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":
                        territory[v, h] = '.';
                        if (v - 1 < 0) lost = true;
                        else
                        {
                            v--;
                            if (territory[v, h] == 'O')
                            {
                                if (v - 1 < 0) lost = true;
                                else
                                {
                                    territory[v, h] = '.';
                                    v--;
                                }
                            }
                            if (territory[v, h] == 'f') polinationedFlowers++;
                            territory[v, h] = 'B';
                        }
                        break;
                    case "down":
                        territory[v, h] = '.';
                        if (v + 1 >= n) lost = true;
                        else
                        {
                            v++;
                            if (territory[v, h] == 'O')
                            {
                                if (v + 1 >= n) lost = true;
                                else
                                {
                                    territory[v, h] = '.';
                                    v++;
                                }
                            }
                            if (territory[v, h] == 'f') polinationedFlowers++;
                            territory[v, h] = 'B';
                        }
                        break;
                    case "left":
                        territory[v, h] = '.';
                        if (h - 1 < 0) lost = true;
                        else
                        {
                            h--;
                            if (territory[v, h] == 'O')
                            {
                                if (h - 1 < 0) lost = true;
                                else
                                {
                                    territory[v, h] = '.';
                                    h--;
                                }
                            }
                            if (territory[v, h] == 'f') polinationedFlowers++;
                            territory[v, h] = 'B';
                        }
                        break;
                    case "right":
                        territory[v, h] = '.';
                        if (h + 1 >= n) lost = true;
                        else
                        {
                            h++;
                            if (territory[v, h] == 'O')
                            {
                                if (h + 1 >= n) lost = true;
                                else
                                {
                                    territory[v, h] = '.';
                                    h++;
                                }
                            }
                            if (territory[v, h] == 'f') polinationedFlowers++;
                            territory[v, h] = 'B';
                        }
                        break;
                }
                if (lost)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
            }
            if (polinationedFlowers < 5) Console.WriteLine($"The bee couldn't pollinate the flowers" +
                $", she needed {5 - polinationedFlowers} flowers more");
            else Console.WriteLine($"Great job, the bee managed to pollinate {polinationedFlowers} flowers!");
            for (int l = 0; l < n; l++)
            {
                for (int y = 0; y < n; y++)
                    Console.Write(territory[l,y]);
                Console.WriteLine();
            }
        }
    }
}
