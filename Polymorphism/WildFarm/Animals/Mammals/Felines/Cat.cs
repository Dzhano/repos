using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Feed(Food food)
        {
            if (food is Meat || food is Vegetable)
            {
                Weight += food.Quantity * 0.30;
                FoodEaten += food.Quantity;
            }
            else Console.WriteLine($"Cat does not eat {food.GetType().Name}!");
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
