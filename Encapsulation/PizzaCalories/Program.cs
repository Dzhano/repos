using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughInput = Console.ReadLine().Split(); // Dough {doughFlourType} {doughBakingTechnique} {doughWeight}
            string doughFlourType = doughInput[1];
            string doughBakingTechnique = doughInput[2];
            int doughWeight = int.Parse(doughInput[3]);
            try
            {
                Dough dough = new Dough(doughFlourType, doughBakingTechnique, doughWeight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string input = string.Empty;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingInput = input.Split(); // Topping {toppingType} {toppingWeight}
                    string toppingType = toppingInput[1];
                    int toppingWeight = int.Parse(toppingInput[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizzaName} - {pizza.GetCalories():F2} Calories.");
            }
            catch (Exception exception)
                when (exception is ArgumentException || exception is InvalidOperationException)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
