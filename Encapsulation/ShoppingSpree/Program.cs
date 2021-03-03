using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            for (int i = 0; i < 2; i++)
            {
                string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in input)
                {
                    string[] data = item.Split('=');
                    if (data[0] == " ")
                    {
                        Console.WriteLine("Name cannot be empty");
                        return;
                    }
                    int money = int.Parse(data[1]);
                    if (money < 0)
                    {
                        Console.WriteLine("Money cannot be negative");
                        return;
                    }
                    if (i == 0)
                    {
                        Person newPerson = new Person(data[0], money);
                        people.Add(data[0], newPerson);
                    }
                    else if (i == 1)
                    {
                        Product newProduct = new Product(data[0], money);
                        products.Add(data[0], newProduct);
                    }
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (people[info[0]].Money >= products[info[1]].Cost)
                {
                    people[info[0]].Money -= products[info[1]].Cost;
                    people[info[0]].BagOfProducts.Add(products[info[1]]);
                    Console.WriteLine($"{people[info[0]].Name} bought {products[info[1]].Name}");
                }
                else Console.WriteLine($"{people[info[0]].Name} can't afford {products[info[1]].Name}");
            }
            foreach (Person person in people.Values)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    Console.Write($"{person.Name} - ");
                    for (int i = 0; i < person.BagOfProducts.Count - 1; i++)
                        Console.Write(person.BagOfProducts[i].Name + ", ");
                    Console.WriteLine(person.BagOfProducts[person.BagOfProducts.Count - 1].Name);
                }
                else Console.WriteLine($"{person.Name} - Nothing bought");
            }
        }
    }
}
