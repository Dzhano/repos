using System;

namespace FixingVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num1 = 30;
                int num2 = 60;
                byte result = Convert.ToByte(num1 * num2);
                Console.WriteLine($"{num1} x {num2} = {result}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
