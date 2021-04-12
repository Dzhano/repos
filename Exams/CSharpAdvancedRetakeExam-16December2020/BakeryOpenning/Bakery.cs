using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            employees = new Dictionary<string, Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        private Dictionary<string, Employee> employees;

        public int Count => employees.Count;


        public void Add(Employee employee) => employees.Add(employee.Name, employee);

        public bool Remove(string name) => employees.Remove(name);

        public Employee GetOldestEmployee() 
        {
            List<Employee> sorted = employees.Values.OrderByDescending(e => e.Age).ToList();
            return sorted[0];
        }

        public Employee GetEmployee(string name) => employees.Values.FirstOrDefault(e => e.Name == name);

        public string Report()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Employees working at Bakery {Name}");
            foreach (Employee employee in employees.Values)
                builder.AppendLine(employee.ToString());
            return builder.ToString().TrimEnd();
        }
    }
}
