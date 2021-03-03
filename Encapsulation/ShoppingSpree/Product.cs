using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
        public string Name { get; set; }
        public int Cost { get; set; }
    }
}
