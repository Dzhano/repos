using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies
                = new Dictionary<string, List<string>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] ID = input.Split(" -> ");
                if (companies.ContainsKey(ID[0])) 
                {
                    if (companies[ID[0]].Contains(ID[1]) == false)
                        companies[ID[0]].Add(ID[1]);
                }
                else companies.Add(ID[0], new List<string>() { ID[1] });
            }
            Dictionary<string, List<string>> sortedCompanies 
                = companies.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var company in sortedCompanies)
            {
                Console.WriteLine(company.Key);
                foreach (string user in company.Value) Console.WriteLine($"-- {user}");
            }
        }
    }
}
