using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }


        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

                name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= 10)
                throw new ArgumentException("Number of toppings should be in range [0..10].");

            toppings.Add(topping);
        }

        public double GetCalories()
        {
            double calories = dough.GetCalories();
            foreach (Topping topping in toppings)
                calories += topping.GetCalories();
            return calories;
        }
    }
}
