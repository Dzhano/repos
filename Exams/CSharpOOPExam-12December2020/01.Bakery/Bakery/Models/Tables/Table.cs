using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;

            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();

            IsReserved = false;
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set 
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => PricePerPerson * NumberOfPeople;

        public void Clear()
        {
            //Removes all of the ordered drinks and food and finally frees the table and sets the count of people to 0.
            IsReserved = false;
            foodOrders.Clear();
            drinkOrders.Clear();
            numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            //Returns the bill for all of the ordered drinks and food.
            decimal totalPrice = 0;
            totalPrice += foodOrders.Sum(f => f.Price);
            totalPrice += drinkOrders.Sum(d => d.Price);
            totalPrice += Price;
            return totalPrice;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Table: {TableNumber}");
            text.AppendLine($"Type: {this.GetType().Name}");
            text.AppendLine($"Capacity: {Capacity}");
            text.Append($"Price per Person: {PricePerPerson}");
            return text.ToString();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
