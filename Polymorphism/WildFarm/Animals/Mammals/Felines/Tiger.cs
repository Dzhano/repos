using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                Weight += food.Quantity * 1.00;
                FoodEaten += food.Quantity;
            }
            else Console.WriteLine($"Tiger does not eat {food.GetType().Name}!");
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
