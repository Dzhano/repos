using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>(); 
            List<string> departments = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                Employee employee = new Employee();
                employee.Name = data[0];
                employee.Salary = double.Parse(data[1]);
                employee.Department = data[2];
                if (!departments.Contains(data[2])) departments.Add(data[2]);
                employees.Add(employee);
            }
            string bestDepartment = string.Empty;
            double bestAverageSalary = 0;
            foreach (string department in departments)
            {
                double current = 0;
                double counter = 0;
                foreach (Employee person in employees) 
                    if (person.Department == department)
                    {
                        counter++;
                        current += person.Salary;
                    }
                current /= counter;
                if (current > bestAverageSalary)
                {
                    bestAverageSalary = current;
                    bestDepartment = department;
                }
            }
            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            List<Employee> best = employees.FindAll(x => x.Department == bestDepartment);
            best.OrderBy(x => x.Salary);
            best.Reverse(); // Поради нейзвестна причина кодът не работи както трябва на някои места. Тук нещо работата се прецаква.
            foreach (Employee human in best) Console.WriteLine($"{human.Name} {human.Salary:F2}");
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
}
