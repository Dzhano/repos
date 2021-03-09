using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                Weight += food.Quantity * 0.25;
                FoodEaten += food.Quantity;
            }
            else Console.WriteLine($"Owl does not eat {food.GetType().Name}!");
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
