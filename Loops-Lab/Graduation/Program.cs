using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int grades = 1;
            double sum = 0;
            while (grades <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4.00)
                {
                    continue;
                }
                sum += grade;
                grades++;
            }
            double average = sum / 12;
            Console.WriteLine($"{studentName} graduated. Average grade: {average:F2}");
        }
    }
}
