using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int opening = 0;
            int closing = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                foreach (char item in input)
                {
                    if (item == '(')
                    {
                        opening++;
                        if (opening == closing + 2)
                        {
                            Console.WriteLine("UNBALANCED");
                            return;
                        }
                    }
                    if (item == ')') 
                    {
                        closing++;
                        if (closing == opening + 1)
                        {
                            Console.WriteLine("UNBALANCED");
                            return;
                        }
                    }
                }
            }
            if (opening == closing) Console.WriteLine("BALANCED");
            else Console.WriteLine("UNBALANCED");
        }
    }
}
