using System;

namespace DateModifierProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int days = DateModifier.DifferenceBetweenDates(firstDate, secondDate);
            Console.WriteLine(days);
        }
    }
}
