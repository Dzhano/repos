using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                Weight += food.Quantity * 0.40;
                FoodEaten += food.Quantity;
            }
            else Console.WriteLine($"Dog does not eat {food.GetType().Name}!");
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
