using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Feed(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                Weight += food.Quantity * 0.15;
                FoodEaten += food.Quantity;
            }
            else Console.WriteLine($"Mouse does not eat {food.GetType().Name}!");
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
