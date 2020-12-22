using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            double averageGrade = 0.0;
            double totalGrade = 0.0;
            double totalGradeCounter = 0.0;
            for (int i = 1; i <= n; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                averageGrade += grade;
                if (i == n)
                {
                    averageGrade /= n;
                    totalGradeCounter++;
                    totalGrade += averageGrade;
                    Console.WriteLine($"{presentationName} - {averageGrade:F2}.");
                    presentationName = Console.ReadLine();
                    i = 0;
                    averageGrade = 0.0;
                }
                if ("Finish" == presentationName)
                {
                    totalGrade /= totalGradeCounter;
                    break;
                }
            }
            Console.WriteLine($"Student's final assessment is {totalGrade:F2}.");
        }
    }
}
