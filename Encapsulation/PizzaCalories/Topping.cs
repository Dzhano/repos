using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType; // Meat, Veggies, Cheese or a Sauce
        private int weight;

        public Topping(string toppingType, int weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }


        public string ToppingType // Meat, Veggies, Cheese or a Sauce
        {
            get => this.toppingType;
            set
            {
                string type = value.ToLower();
                if (type != "meat" && type != "veggies" && type != "cheese" && type != "sauce")
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                toppingType = value;
            }
        }
        public int Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");

                weight = value;
            }
        }

        public double GetCalories()
        {
            double calories = 2 * Weight;
            calories *= GetToppingTypeCalories();
            return calories;
        }

        private double GetToppingTypeCalories()
        {
            string type = ToppingType.ToLower();
            /*
            meat - 1.2;
            veggies - 0.8; 
            cheese - 1.1;
            sauce - 0.9;
            */

            if (type == "meat") return 1.2;
            else if (type == "veggies") return 0.8;
            else if (type == "cheese") return 1.1;
            return 0.9;
        }
    }
}
