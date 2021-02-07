using System;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split()
                .Select(num => int.Parse(num)).ToArray();
            Predicate<int> divisable = num =>
            {
                foreach (int divider in dividers)
                    if (num % divider != 0) return false;
                return true;
            };
            for (int i = 1; i <= n; i++)
                if (divisable(i)) Console.Write(i + " ");
            //  if (dividers.All(num => i % num == 0)) Console.Write(i + " ");  
            // по-кратък вариант, който няма нужда и от „Predicate<int> divisable“
        }
    }
}
