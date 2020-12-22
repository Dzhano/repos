using System;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int explosionPower = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (explosionPower > 0)
                {
                    if (input[i] == '>')
                    {
                        if (i + 1 < input.Length)
                            explosionPower += int.Parse(input[i + 1].ToString());
                    }
                    else
                    {
                        if (i < input.Length)
                        {
                            input = input.Remove(i, 1);
                            i--;
                        }
                        explosionPower--;
                    }
                }
                else if (input[i] == '>') 
                    explosionPower += int.Parse(input[i + 1].ToString());
            }
            Console.WriteLine(input);
        }
    }
}
