using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            //Не знам защо не работи.
            List<Person> people = new List<Person>();
            string[] inputPeople = Console.ReadLine().Split(";");
            foreach (string somebody in inputPeople)
            {
                string[] dataPerson = somebody.Split("=");
                Person human = new Person();
                human.Name = dataPerson[0];
                human.Money = double.Parse(dataPerson[1]);
                people.Add(human);
            }
            List<Product> products = new List<Product>();
            string[] inputProducts = Console.ReadLine().Split(";");
            foreach (string item in inputProducts)
            {
                string[] dataProduct = item.Split("=");
                Product something = new Product();
                something.Name = dataProduct[0];
                something.Cost = double.Parse(dataProduct[1]);
                products.Add(something);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split();
                Person person = people.Find(x => x.Name == data[0]);
                Product product = products.Find(x => x.Name == data[1]);
                if (person.Money >= product.Cost)
                {
                    person.Money -= product.Cost;
                    person.Products.Add(product.Name);
                }
                else Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
            foreach (Person someone in people) 
                if (someone.Products.Count > 0)
                    Console.WriteLine($"{someone.Name} - {string.Join(", ", someone.Products)}");
                else Console.WriteLine($"{someone.Name} – Nothing bought");
        }
    }

    class Person
    {
        public string Name { get; set; }
        public double Money { get; set; }
        public List<string> Products { get; set; } // Тук явно е проблема.
    }

    class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
