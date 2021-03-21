using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<IEmployee> employees = new List<IEmployee>()
            {
                new Employee("Viktor"),
                new Manager("Dzhano", new List<string>()
                { 
                    "Math",
                    "IT",
                    "AI"
                })
            };
            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();
        }
    }
}
