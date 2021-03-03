using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name { get; set; }
        public int Money { get; set; }
        public List<Product> BagOfProducts { get; set; }
    }
}
