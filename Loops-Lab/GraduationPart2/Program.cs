using System;

namespace GraduationPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int grades = 1;
            int badGrades = 0;
            double sum = 0;
            while (grades <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4.00)
                {
                    badGrades += 1;
                    if (badGrades > 1)
                    {
                        break;
                    }
                    continue;
                }
                sum += grade;
                grades++;
            }
            double average = sum / 12;
            if (grades < 12)
            {
                Console.WriteLine($"{studentName} has been excluded at {grades} grade");
            }
            else
            {
                Console.WriteLine($"{studentName} graduated. Average grade: {average:F2}");
            }
        }
    }
}
