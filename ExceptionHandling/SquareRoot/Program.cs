using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0) throw new ArgumentException();
                Console.WriteLine(Math.Pow(number, 0.5));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            Console.WriteLine("Good bye");
        }
    }
}
