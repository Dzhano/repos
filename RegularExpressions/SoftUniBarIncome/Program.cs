using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regPerson = new Regex(@"%(?<Person>[A-Z][a-z]+)%");
            Regex regProduct = new Regex(@"<(?<Product>\w+)>");
            Regex regQuantity = new Regex(@"\|(?<Quantity>\d+)\|");
            Regex regPrice = new Regex(@"(?<Price>\d+\.?\d*)\$");
            double totalPrice = 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match person = regPerson.Match(input);
                Match product = regProduct.Match(input);
                Match quantity = regQuantity.Match(input);
                Match priceForOne = regPrice.Match(input);
                if (person.Success && priceForOne.Success && product.Success && quantity.Success)
                {
                    double price = int.Parse(quantity.Groups["Quantity"].Value) 
                        * double.Parse(priceForOne.Groups["Price"].Value);
                    Console.WriteLine($"{person.Groups["Person"]}: {product.Groups["Product"]} - {price:F2}");
                    totalPrice += price;
                }
            }
            Console.WriteLine($"Total income: {totalPrice:F2}");
        }
    }
}
