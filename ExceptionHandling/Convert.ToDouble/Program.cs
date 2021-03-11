using System;

namespace Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumText = Console.ReadLine();
            try
            {
                double num = System.Convert.ToDouble(inputNumText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
