using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetMoney = Math.Round(double.Parse(Console.ReadLine()), 2);
            int padawanStudents = int.Parse(Console.ReadLine());
            double sabresPrice = Math.Round(double.Parse(Console.ReadLine()), 2);
            double robePrice = Math.Round(double.Parse(Console.ReadLine()), 2);
            double beltPrice = Math.Round(double.Parse(Console.ReadLine()), 2);

            int freeBelts = 0;
            for (int i = 1; i <= padawanStudents; i++)
            {
                if (i % 6 == 0)
                {
                    freeBelts += 1;
                }
            }
            int numberBelts = padawanStudents - freeBelts;
            double numberLightsabers = Math.Ceiling(1.10 * padawanStudents);
            double totalPrice = Math.Round((sabresPrice * numberLightsabers) + (robePrice * padawanStudents) + (beltPrice * numberBelts), 2);

            if (totalPrice > budgetMoney)
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice - budgetMoney):F2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
        }
    }
}
