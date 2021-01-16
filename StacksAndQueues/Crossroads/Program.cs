using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int safePasses = 0;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    int green = greenLight;
                    int leftGreen = 0;
                    int free = freeWindow;
                    int left = 0;
                    while (green > 0)
                    {
                        if (cars.Count > 0)
                        {
                            bool window = false;
                            if (green - cars.Peek().Length >= 0)
                            {
                                green -= cars.Peek().Length;
                                cars.Dequeue();
                                safePasses++;
                            }
                            else
                            {
                                window = true;
                                leftGreen = green;
                                green -= cars.Peek().Length;
                                left -= green;
                            }
                            if (window)
                            {
                                if (free - left >= 0)
                                {
                                    cars.Dequeue();
                                    safePasses++;
                                }
                                else
                                {
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{cars.Peek()} was hit at " +
                                        $"{cars.Peek().Substring(leftGreen + free, 1)}.");
                                    return;
                                }
                            }
                        }
                        else break;
                    }
                }
                else cars.Enqueue(command);
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{safePasses} total cars passed the crossroads.");
        }
    }
}
